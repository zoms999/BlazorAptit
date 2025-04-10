using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BlazorAptit.Models;
using Microsoft.Extensions.Configuration;

namespace BlazorAptit.Services
{
    public class StatisticsService
    {
        private readonly string _connectionString;

        public StatisticsService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<string>> GetGroupNamesAsync()
        {
            var groupNames = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"
                        SELECT 
                            [Group_Name]
                        FROM [dbo].[AptitGroup]
                        GROUP BY [Group_Name]
                        ORDER BY [Group_Name]";

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            groupNames.Add(reader["Group_Name"].ToString());
                        }
                    }
                }
            }

            return groupNames;
        }

        public async Task<List<GenderGroupStatistics>> GetGenderGroupStatisticsAsync(string targetGroupName)
        {
            var statistics = new List<GenderGroupStatistics>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"
                    -- Set the Group Name for the overall entity
                    DECLARE @TargetGroupName NVARCHAR(100) = @TargetGroupNameParam; 

                    -- Common Table Expression block STARTS here
                    WITH UnpivotedScores AS (
                        -- Unpivot scores from AptitAnswer for Stage 16
                        SELECT
                            a.AptitUserID,
                            CAST(REPLACE(up.QuestionKey, 'AQ_', '') AS INT) AS AptitReplyID,
                            up.Point
                        FROM careeredu99_otag.dbo.AptitAnswer a
                        INNER JOIN careeredu99_otag.dbo.AptitUser U ON a.AptitUserID = U.ID
                        CROSS APPLY (
                            VALUES ('AQ_1',a.AQ_1),('AQ_2',a.AQ_2),('AQ_3',a.AQ_3),('AQ_4',a.AQ_4),('AQ_5',a.AQ_5),('AQ_6',a.AQ_6),('AQ_7',a.AQ_7),('AQ_8',a.AQ_8),('AQ_9',a.AQ_9),('AQ_10',a.AQ_10),
                                ('AQ_11',a.AQ_11),('AQ_12',a.AQ_12),('AQ_13',a.AQ_13),('AQ_14',a.AQ_14),('AQ_15',a.AQ_15),('AQ_16',a.AQ_16),('AQ_17',a.AQ_17),('AQ_18',a.AQ_18),('AQ_19',a.AQ_19),('AQ_20',a.AQ_20)
                        ) AS up (QuestionKey, Point)
                        WHERE a.Stage = 16
                        AND up.Point IS NOT NULL
                        AND U.Group_Name = @TargetGroupName -- Filter for the target group name
                    ),
                    RankedUserScores AS (
                        -- Rank scores per user
                        SELECT
                            ups.AptitUserID, ups.AptitReplyID, ups.Point,
                            ROW_NUMBER() OVER (PARTITION BY ups.AptitUserID ORDER BY ups.Point DESC, ups.AptitReplyID ASC) as rn
                        FROM UnpivotedScores ups
                    ),
                    BaseUserResult AS (
                        -- Get base user info including Gender
                        SELECT
                            U.ID AS UserID, U.Group_Name, U.Group_City,
                            U.User_Gender, -- 성별 정보 추가
                            R.TITLE AS Primary_Aptitude_Type
                        FROM RankedUserScores RUS
                        JOIN careeredu99_otag.dbo.AptitUser AS U ON RUS.AptitUserID = U.ID
                        JOIN careeredu99_otag.dbo.AptitReply AS R ON RUS.AptitReplyID = R.AptitReplyID
                        WHERE RUS.rn = 1
                        AND U.Group_Name = @TargetGroupName
                        AND R.TITLE IS NOT NULL
                        -- Ensure User_Gender is valid for analysis
                        AND U.User_Gender IS NOT NULL AND LTRIM(RTRIM(U.User_Gender)) <> ''
                    ),
                    OverallGroupTotal AS (
                        -- Total users within the group name having valid Gender
                        SELECT COUNT(UserID) AS TotalCount
                        FROM BaseUserResult
                    ),
                    UserPrimaryResultForGenderGroup AS (
                        -- Prepare for grouping by Gender
                        SELECT
                            UserID, Group_Name, Group_City, User_Gender, Primary_Aptitude_Type
                        FROM BaseUserResult
                    )
                    -- **** Main SELECT using CTEs ****
                    , GenderGroupCounts AS (
                        -- Count users per aptitude within each Gender
                        SELECT
                            UPR.Group_Name, UPR.Group_City, UPR.User_Gender, UPR.Primary_Aptitude_Type,
                            COUNT(UPR.UserID) AS Aptitude_Count_In_Gender,
                            -- 해당 성별 그룹 내 총 사용자 수
                            SUM(COUNT(UPR.UserID)) OVER (PARTITION BY UPR.Group_Name, UPR.User_Gender) AS Total_Users_In_Gender,
                            -- 전체 그룹 내 총 사용자 수 (유효 성별자 기준)
                            OGT.TotalCount AS Total_Users_In_Overall_Group
                        FROM UserPrimaryResultForGenderGroup UPR
                        CROSS JOIN OverallGroupTotal OGT
                        GROUP BY
                            UPR.Group_Name, UPR.Group_City, UPR.User_Gender, UPR.Primary_Aptitude_Type, OGT.TotalCount
                    )
                    , RankedByGenderGroup AS (
                        -- Rank aptitudes within each Gender group
                        SELECT
                            Group_Name, Group_City, User_Gender, Primary_Aptitude_Type,
                            Aptitude_Count_In_Gender, Total_Users_In_Gender, Total_Users_In_Overall_Group,
                            ROW_NUMBER() OVER (PARTITION BY Group_Name, User_Gender ORDER BY Aptitude_Count_In_Gender DESC, Primary_Aptitude_Type ASC) AS Rank_In_Gender,
                            -- 해당 성별 그룹 내 비율 계산
                            CASE WHEN Total_Users_In_Gender > 0 THEN CAST(Aptitude_Count_In_Gender * 100.0 / Total_Users_In_Gender AS DECIMAL(5, 1)) ELSE 0 END AS Pct_In_Gender,
                            -- 전체 그룹 대비 비율 계산 (유효 성별자 기준)
                            CASE WHEN Total_Users_In_Overall_Group > 0 THEN CAST(Aptitude_Count_In_Gender * 100.0 / Total_Users_In_Overall_Group AS DECIMAL(5, 1)) ELSE 0 END AS Pct_In_Overall_Group
                        FROM GenderGroupCounts
                    )
                    -- Final selection: Top 3 aptitudes per Gender group
                    SELECT
                        RC.Group_Name,
                        RC.User_Gender,            -- 분석 기준: 성별
                        RC.Rank_In_Gender,         -- 성별 내 순위
                        RC.Primary_Aptitude_Type,
                        RC.Pct_In_Gender,          -- 성별 내 비율 (%)
                        RC.Pct_In_Overall_Group,   -- 전체 그룹 대비 비율 (%)
                        RC.Aptitude_Count_In_Gender, -- 해당 성별, 해당 적성 인원수
                        RC.Total_Users_In_Gender,  -- 해당 성별 총 인원수
                        RC.Total_Users_In_Overall_Group -- 전체 그룹 총 인원수 (유효 성별자 기준)
                    FROM RankedByGenderGroup RC
                    WHERE RC.Rank_In_Gender <= 3 -- 각 성별 그룹별 상위 3개 결과만 표시
                    ORDER BY
                        RC.Group_Name,
                        RC.User_Gender, -- 성별 순서 정렬
                        RC.Rank_In_Gender;
                    ";

                    command.Parameters.AddWithValue("@TargetGroupNameParam", targetGroupName);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            statistics.Add(new GenderGroupStatistics
                            {
                                Group_Name = reader["Group_Name"].ToString(),
                                User_Gender = reader["User_Gender"].ToString(),
                                Rank_In_Gender = Convert.ToInt32(reader["Rank_In_Gender"]),
                                Primary_Aptitude_Type = reader["Primary_Aptitude_Type"].ToString(),
                                Pct_In_Gender = Convert.ToDecimal(reader["Pct_In_Gender"]),
                                Pct_In_Overall_Group = Convert.ToDecimal(reader["Pct_In_Overall_Group"]),
                                Aptitude_Count_In_Gender = Convert.ToInt32(reader["Aptitude_Count_In_Gender"]),
                                Total_Users_In_Gender = Convert.ToInt32(reader["Total_Users_In_Gender"]),
                                Total_Users_In_Overall_Group = Convert.ToInt32(reader["Total_Users_In_Overall_Group"])
                            });
                        }
                    }
                }
            }

            return statistics;
        }
    }
} 