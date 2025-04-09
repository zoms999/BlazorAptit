using Dapper;
using Microsoft.Data.SqlClient;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Models.Dapper
{
    public class AptitRepository : IAptitRepository
    {
        private readonly IDbConnection db;

        public AptitRepository(string connectionString)
        {
            this.db = new SqlConnection(connectionString);
        }
        public AptitRepository()
        {
        }

        public bool Edit(string id, Order model)
        {
            try
            {
                var sql = "Update  AptitQuestion SET " + model.COL_NM + "=" + model.VAL + " WHERE ID = " + model.ID;
                db.Execute(sql, model);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Task<bool> EditAsync(string id, Order model)
        {
            var sql = "Update  AptitQuestion SET " + model.COL_NM + "= N'" + model.VAL + "' WHERE ID = " + model.ID;
            db.ExecuteAsync(sql, model);

            return Task.FromResult(true) ;
        }

        public List<AptitQuestion> GetAllAptitQuestions()
        {
            throw new NotImplementedException();
        }


        public async Task<List<AptitQuestion>> GetAllAptitQuestionsAsyns()
        {
            string sql = "Select * From AptitQuestion Order By ID";
            return db.QueryAsync<AptitQuestion>(sql).Result.ToList();

        }

        public async Task<List<Order>> GetQuestionByID(int? ID)
        {
            var parameters = new DynamicParameters(new { ID = ID });
            return db.QueryAsync<Order>("GetQuestionByID", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
        }

        public async Task<List<AptitResultUserView>> GetGroupByID(string groupID)
        {
            //string sql = "Select A.[ID]" +
            //    " ,A.[User_Email], A.[Group_ID] ,A.[Group_Name],A.[User_Password],A.[User_Name] ,A.[User_Edu] ,A.[User_Finish],A.[Created]" +
            //    " , AptitAnswers.[Stage] " +
            //    " From AptitUser A INNER JOIN AptitAnswer AptitAnswers ON A.ID = AptitAnswers.AptitUserID   WHERE Group_ID='" + groupID +"'";
            //return db.QueryAsync<AptitUser >(sql).Result.ToList();


            var parameters = new DynamicParameters(new { GroupID = groupID });
            return db.QueryAsync<AptitResultUserView>("GetResultByGroupID", parameters, commandType: CommandType.StoredProcedure).Result.ToList();

        }

        public async Task<List<AptitGroup>> GetAllAptitUsers()
        {
            string sql = "Select Group_ID, Group_Name ,[Manage_Name],[Manage_Tel1],[Manage_Tel2],[RegCount],[CompletCount] From AptitGroup order by Created DESC";
            return db.QueryAsync<AptitGroup>(sql).Result.ToList();
        }
        
        public async Task<List<AptitUser>> GetAllUserList()
        {
            string sql = "Select *  From AptitUser  A INNER JOIN AptitAnswer B on A.ID = B.AptitUserID  ORDER BY ID DESC ";
            //return db.QueryAsync<AptitUser>(sql).Result.ToList();

            var result = db.QueryAsync<AptitUser, AptitAnswer, AptitUser>(sql,
            (a, b) => { 
                a.aptitAnswer = b;
                return a ; }, splitOn: "ID,AptitUserID" );

            return result.Result.ToList();

        }

       


        

        public async Task<List<AptitResult>> GetUsersResult(int AptitAnswerID)
        {
            var parameters = new DynamicParameters(new { AptitAnswerID = AptitAnswerID });
            return db.QueryAsync<AptitResult>("GetResult", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
            
        }


         public async Task<List<AptitReply>> GetUsersReply(int AptitUserID)
        {
            var parameters = new DynamicParameters(new { AptitUserID = AptitUserID });
            return db.QueryAsync<AptitReply >("GetUsersReply", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
            
        }

          public async Task<List<UserReplyView>> GetUsersReplyView(int AptitUserID)
        {
            var parameters = new DynamicParameters(new { AptitUserID = AptitUserID });
            return db.QueryAsync<UserReplyView >("GetUsersReply", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
            
        }


        public async Task<List<AptitResult>> GetAllAptitResultManagesAsyns()
        {
            string sql = "Select * From AptitResult Order By AptitResultID";
            return db.QueryAsync<AptitResult>(sql).Result.ToList();

        }

        
        public async Task<List<AptitReply>> GetAllAptitReplyManagesAsyns()
        {
            string sql = "Select * From AptitReply Order By AptitReplyID";
            return db.QueryAsync<AptitReply>(sql).Result.ToList();

        }


         public async Task<List<ResultContent>> GetResultManagesByID(int? ID)
        {
            var parameters = new DynamicParameters(new { ID = ID });
            return db.QueryAsync<ResultContent>("GetResultManagesByID", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
        }

         public async Task<List<ResultContent>> GetReplyManagesByID(int? ID)
        {
            var parameters = new DynamicParameters(new { ID = ID });
            return db.QueryAsync<ResultContent>("GetReplyManagesByID", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
        }


         public Task<bool> EditResultManagesAsync(string id, ResultContent model)
        {
            var sql = "Update  AptitResult SET " + model.COL_NM + "= N'" + model.VAL + "' WHERE AptitResultID = " + model.ID;
            db.ExecuteAsync(sql, model);

            return Task.FromResult(true) ;
        }


         public Task<bool> EditReplyManagesAsync(string id, ResultContent model)
        {
            var sql = "Update  AptitReply SET " + model.COL_NM + "= N'" + model.VAL + "' WHERE AptitReplyID = " + model.ID;
            db.ExecuteAsync(sql, model);

            return Task.FromResult(true) ;
        }


        public async Task<List<AptitGroup>> GetAllGroupList()
        {
            //string sql = "Select *  From AptitGroup  A INNER JOIN AptitUser B on A.Group_ID = B.Group_ID  ORDER BY A.ID DESC ";
            //return db.QueryAsync<AptitUser>(sql).Result.ToList();

            //var result = db.QueryAsync<AptitGroup, AptitUser, AptitGroup>(sql,
            //(a, b) => { 
            //    a.aptitUser = b;
            //    return a ; }, splitOn: "Group_ID,Group_ID" );
             string sql = "Select * From AptitGroup  ORDER BY [Created] DESC";
            return db.QueryAsync<AptitGroup>(sql).Result.ToList();

           // return result.Result.ToList();

        }

        public async Task<List<AptitGroup>> GetAllTodayGroupList(DateTime? today)
        {

            // string sql = "Select * From AptitGroup WHERE CONVERT(CHAR(10), Created, 23)  = CONVERT(CHAR(10), '"+ today +"', 23)   Order by Created DESC ";

            //  string sql = "Select * From AptitGroup WHERE CONVERT(CHAR(10), Created, 23)  = CONVERT(CHAR(10), Getdate(), 23)   Order by Created DESC ";

            string sql = " Select * From AptitGroup WHERE CONVERT(CHAR(7), Created, 23)  = CONVERT(CHAR(7), Getdate(), 23)   Order by Created DESC  ";
            return db.QueryAsync<AptitGroup>(sql).Result.ToList();

           // return result.Result.ToList();

        }


        public async Task<List<AptitUser>> 오늘검사단체(DateTime? today)
        {
            // string sql = "Select * From AptitUser WHERE CONVERT(CHAR(10), Created, 23)  = CONVERT(CHAR(10), '"+ today +"', 23)   Order by Created DESC ";
            string sql = "Select * From AptitUser WHERE CONVERT(CHAR(7), Created, 23)  = CONVERT(CHAR(7), Getdate(), 23)   Order by Created DESC ";
            return db.QueryAsync<AptitUser>(sql).Result.ToList();
        }
        

         public Task<bool> EditGroupListAsync(AptitGroup model)
        {
            //db.ExecuteAsync(sql, model);
            try
            {
                
                 db.Execute("AptitGroup_Insert", model, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
            }
            

            return Task.FromResult(true) ;
        }



        
        public async Task<List<AptitRankView>> 성향유형전체통계(int rank)
        {
            var parameters = new DynamicParameters(new { RANK = rank });
            return db.QueryAsync<AptitRankView>("AptitRank_Total",parameters, commandType: CommandType.StoredProcedure).Result.ToList();
            
        }






        public async Task<List<AptitUserQue>> GetResultScore(int AptitUserID)
        {
            string sql = "Select *  From AptitUserQue WHERE AptitUserID = '" + AptitUserID + "' ORDER BY [AptitQuestionID] ";
            //return db.QueryAsync<AptitUser>(sql).Result.ToList();

            return db.QueryAsync<AptitUserQue>(sql).Result.ToList();

        }


        public Task<bool> UpdateResultScoreAsync(AptitUserQue model)
        {
            //db.ExecuteAsync(sql, model);
            try
            {
                var parameters = new DynamicParameters(new { AptitUserID = model.AptitUserID , AptitQuestionID = model.AptitQuestionID, Stage_Score = model.Stage_Score });
                db.Execute("AptitUserQue_Update", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
            }

            return Task.FromResult(true);
        }

        public async Task<string> GetPwd(string email)
        {
            string sql = "Select User_Password From [AptitUser] WHERE [User_Email] = '" + email + "' ";
            //var pwd = db.QueryAsync<string>(sql).Result;

            return db.QueryAsync<string>(sql).Result.FirstOrDefault();
        }



        public Task<bool> UserEdit(AptitUser model)
        {
            var sql = "Update  [AptitUser] SET [User_Name] = N'" + model.User_Name + "' WHERE [User_Email] = '" + model.User_Email + "'  AND [ID] = " + model.ID ;
            db.ExecuteAsync(sql, model);

            return Task.FromResult(true);
        }

        public async Task<string> GetGroupMemberLoginCheck(string userid, string userpw)
        {
            string sql = "Select * From AptitGroup WHERE [Group_ID] = '" + userid + "' AND  [Password] = '" + userpw + "' ";
            return db.QueryAsync<string>(sql).Result.FirstOrDefault();
        }


        public Task<bool> SetUserRankInsert(int aptituserid)
        {
            try
            {
                var parameters = new DynamicParameters(new { AptitUserID = aptituserid });
                db.Execute("SetUserRankInsert", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
            }

            return Task.FromResult(true);
        }


    }
}
