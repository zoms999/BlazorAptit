using blazor_griddata;
using Dapper;
using Microsoft.Data.SqlClient;
using Npgsql;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using SkiaSharp;
using Syncfusion.Blazor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlazorAptit.Models.Dapper
{
    public class OctRepository : IOctRepository
    {

        private readonly IDbConnection db;
        public OctRepository(string connectionString)
        {
            this.db = new NpgsqlConnection(connectionString);
        }
        public async Task<object> GetUserList()
        {
            var parameters = new DynamicParameters();
            string sql = "";
            sql += "select ";
            sql += "mp.pe_name , ";
            sql += "mp.pe_cellphone , ";
            sql += "ma.ac_insert_date , ";
            sql += "ma.ac_expire_date , ";
            sql += "ma.pe_seq , ";
            sql += "ma.ac_id ";
            sql += "from mwd_account ma ";
            sql += "inner join mwd_person mp ";
            sql += "on ma.pe_seq = mp.pe_seq ";
            sql += "order by ma.ac_insert_date desc; ";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> GetUserListDetail(string pe_seq)
        {
            var parameters = new DynamicParameters();
            string sql = "";
            sql += "select  ";
            sql += "mp2.pd_name , ";
            sql += "mi.ins_name , ";
            sql += "map2.anp_start_date , ";
            sql += "map2.anp_end_date , ";
            sql += "mit.tur_count  ";
            sql += "from mwd_person mp  ";
            sql += "inner join mwd_account ma on ma.pe_seq = mp.pe_seq  ";
            sql += "left join mwd_institute_member mim on mp.pe_seq = mim.pe_seq  ";
            sql += "left join mwd_institute mi on mim.ins_seq = mi.ins_seq ";
            sql += "inner join mwd_choice_result mcr on ma.ac_gid = mcr.ac_gid  ";
            sql += "inner join mwd_product mp2 on mp2.pd_num = mcr.pd_num  ";
            sql += "inner join mwd_answer_progress map2 on map2.ac_gid =ma.ac_gid  ";
            sql += "left join mwd_institute_turn mit on mit.ins_seq = mim.ins_seq and mim.tur_seq = mit.tur_seq  ";
            sql += "where mp.pe_seq = '" + pe_seq + "' ";
            sql += "group by mp2.pd_name ,mi.ins_name ,map2.anp_start_date ,map2.anp_end_date ,mit.tur_count; ";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> GetUserInfo(string ac_id)
        {
            var parameters = new DynamicParameters();
            string sql = "";
            sql += "select ac_id, ";
            sql += "ac_pw, ";
            sql += "ac_use, ";
            sql += "ac_insert_date, ";
            sql += "ac_leave_date, ";
            sql += "ac_gid, ";
            sql += "ins_seq, ";
            sql += "ma.pe_seq, ";
            sql += "ac_expire_date, ";
            sql += "ac_terms_use, ";
            sql += "ac_terms_person, ";
            sql += "ac_terms_event, ";
            sql += "pe_name, ";
            sql += "pe_birth_year, ";
            sql += "pe_birth_month, ";
            sql += "pe_birth_day, ";
            sql += "pe_sex, ";
            sql += "pe_cellphone, ";
            sql += "pe_contact, ";
            sql += "pe_email, ";
            sql += "pe_postcode, ";
            sql += "pe_road_addr, ";
            sql += "pe_jibun_addr, ";
            sql += "pe_detail_addr, ";
            sql += "pe_extra_addr, ";
            sql += "pe_ur_education, ";
            sql += "pe_ur_job, ";
            sql += "pe_school_name, ";
            sql += "pe_school_major, ";
            sql += "pe_school_year, ";
            sql += "pe_job_name, ";
            sql += "pe_job_detail, ";
            sql += "mcc.coc_code_name, ";
            sql += "mcc2.coc_code_name  ";
            sql += "from mwd_account ma  ";
            sql += "inner join mwd_person mp on mp.pe_seq = ma.pe_seq  ";
            sql += "inner join mwd_common_code mcc on mcc.coc_code = mp.pe_ur_education  ";
            sql += "inner join mwd_common_code mcc2 on mcc2.coc_code = mp.pe_ur_job ";
            sql += "where ma.ac_id = '" + ac_id + "'; ";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> GetEnterList()
        {
            var parameters = new DynamicParameters();
            string sql = "";
            sql += "select  ";
            sql += "mi.ins_name , ";
            sql += "mi.ins_tel1 , ";
            sql += "mi.ins_ceo , ";
            sql += "mi.ins_manager1_name , ";
            sql += "mi.ins_manager1_team , ";
            sql += "mi.ins_manager1_position , ";
            sql += "ma.ac_insert_date , ";
            sql += "ma.ac_expire_date , ";
            sql += "mit.tur_count , ";
            sql += "mit.tur_req_sum , ";
            sql += "mit.tur_use_sum , ";
            sql += "ma.ins_seq , ";
            sql += "mit.tur_seq  ";
            sql += "from mwd_account ma  ";
            sql += "inner join mwd_institute mi on ma.ins_seq = mi.ins_seq  ";
            sql += "inner join mwd_institute_turn mit on ma.ins_seq = mit.ins_seq  ";
            sql += "order by ma.ac_insert_date desc; ";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> GetEnterInfo(string ins_seq)
        {
            var parameters = new DynamicParameters();
            string sql = "";
            sql += "select  ";
            sql += "mi.ins_license_num, ";
            sql += "mi.ins_identity_num, ";
            sql += "mi.ins_ceo, ";
            sql += "mi.ins_postcode, ";
            sql += "mi.ins_road_addr, ";
            sql += "mi.ins_jibun_addr, ";
            sql += "mi.ins_detail_addr, ";
            sql += "mi.ins_extra_addr, ";
            sql += "mi.ins_name, ";
            sql += "mi.ins_tel1, ";
            sql += "mi.ins_tel2, ";
            sql += "mi.ins_fax1, ";
            sql += "mi.ins_business, ";
            sql += "mi.ins_business_detail, ";
            sql += "mi.ins_manager1_name, ";
            sql += "mi.ins_manager1_cellphone, ";
            sql += "mi.ins_manager1_email, ";
            sql += "mi.ins_manager2_name, ";
            sql += "mi.ins_manager2_cellphone, ";
            sql += "mi.ins_manager2_email, ";
            sql += "mi.ins_seq, ";
            sql += "mi.ins_bill_email, ";
            sql += "mi.ins_manager1_team, ";
            sql += "mi.ins_manager1_position, ";
            sql += "mi.ins_manager2_team, ";
            sql += "mi.ins_manager2_position, ";
            sql += "mi.ins_url_code, ";
            sql += "ma.ac_id , ";
            sql += "ma.ac_pw , ";
            sql += "ma.ac_insert_date , ";
            sql += "ma.ac_expire_date  ";
            sql += "from mwd_institute mi  ";
            sql += "inner join mwd_account ma on mi.ins_seq = ma.ins_seq  ";
            sql += "where mi.ins_seq = '" + ins_seq + "'; ";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> GetUserResultList()
        {
            var parameters = new DynamicParameters();
            string sql = "";
            sql += "select a.pe_name ,mp2.pd_name ,a.ac_id ,a.pe_cellphone ,a.ac_insert_date ,a.ac_leave_date ,a.ac_expire_date ,a.ac_gid   ";
            sql += "from ( ";
            sql += "	select  ";
            sql += "	mp.pe_name ,mcr.pd_kind ,ac_id ,mp.pe_cellphone ,ac_insert_date ,ac_leave_date ,ac_expire_date ,ma.ac_gid  ";
            sql += "	from mwd_account ma  ";
            sql += "	inner join mwd_choice_result mcr  ";
            sql += "	on ma.ac_gid = mcr.ac_gid  ";
            sql += "	inner join mwd_person mp  ";
            sql += "	on ma.pe_seq = mp.pe_seq  ";
            sql += "	where mcr.ins_seq is null   ";
            sql += "	and mcr.tur_seq  is null  ";
            sql += "	and mcr.cr_paymentdate is not null  ";
            sql += "	order by ac_insert_date desc ";
            sql += ") a ";
            sql += "inner join mwd_product mp2  ";
            sql += "on a.pd_kind = mp2.pd_kind ";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> GetEnterResultUserList(string ins_seq, string tur_seq)
        {
            var parameters = new DynamicParameters();
            string sql = "";
            sql += "select mp.pe_name ,ma.ac_id ,mp.pe_cellphone ,map2.anp_start_date ,map2.anp_end_date ,map2.anp_seq ,map2.ac_gid from mwd_choice_result mcr  ";
            sql += "inner join mwd_answer_progress map2 on mcr.cr_seq = map2.cr_seq and map2.ac_gid = mcr.ac_gid  ";
            sql += "inner join mwd_account ma on ma.ac_gid = mcr.ac_gid  ";
            sql += "inner join mwd_person mp on mp.pe_seq = ma.pe_seq  ";
            sql += "where mcr.ins_seq = '" + ins_seq  + "' and mcr.tur_seq ='" + tur_seq  + "' ";
            sql += "order by map2.anp_start_date desc ,map2.anp_end_date desc; ";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> GetQuestionExplain()
        {
            var parameters = new DynamicParameters();
            string sql = "select * from mwd_question_explain mqe order by qua_code, que_switch";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> GetJobList()
        {
            var parameters = new DynamicParameters();
            string sql = "select * from mwd_job mj order by jo_code";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> GetMajorList()
        {
            var parameters = new DynamicParameters();
            string sql = "select * from mwd_major mm order by ma_code";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> GetDutyList()
        {
            var parameters = new DynamicParameters();
            string sql = "select * from mwd_duty md order by du_code";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> GetCommonCode()
        {
            var parameters = new DynamicParameters();
            string sql = "select * from mwd_common_code mcc";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> updateMajor(MajorionUpdateModel model)
        {
            var parameters = new DynamicParameters();
            string sql = " UPDATE public.mwd_major ";
            sql += " SET ma_name='" + model.ma_name + "', ma_explain='" + model.ma_explain + "', ma_use='" + model.ma_use + "' ";
            sql += " WHERE ma_code='" + model.ma_code + "' ;";
            await db.ExecuteAsync(sql);
            return await GetMajorList();
        }
        public async Task<object> updateDuty(DutyUpdateModel model)
        {
            var parameters = new DynamicParameters();
            string sql = " UPDATE public.mwd_duty ";
            sql += " SET du_name='" + model.du_name + "', du_use='" + model.du_use + "', du_outline='" + model.du_outline + "', du_department='" + model.du_department + "' ";
            sql += " WHERE du_code='" + model.du_code + "' ;";
            await db.ExecuteAsync(sql);
            return await GetDutyList();
        }
        public async Task<object> updateJob(JobUpdateModel model)
        {
            var parameters = new DynamicParameters();
            string sql = " UPDATE public.mwd_job ";
            sql += " SET jo_name = '" + model.jo_name + "', jo_outline = '" + model.jo_outline + "', jo_use = '" + model.jo_use + "', jo_mainbusiness = '" + model.jo_mainbusiness + "' ";
            sql += " WHERE jo_code = '" + model.jo_code + "' ;";
            await db .ExecuteAsync(sql);
            return await GetJobList();
        }
        public async Task<object> updateQuestion(QuestionUpdateModel model)
        {
            var parameters = new DynamicParameters();
            string sql = " UPDATE public.mwd_question_explain ";
            sql += " SET que_explain='" + model.que_explain + "' ";
            sql += " WHERE qua_code='" + model.qua_code + "' AND que_switch=" + model.que_switch + " ;";
            await db.ExecuteAsync(sql);
            return await GetQuestionExplain();
        }
        public async Task<object> selectQuestionData()
        {
            var parameters = new DynamicParameters();
            string sql = " select mq.qu_code,mq.qu_explain from mwd_question mq where qu_kind1 ='tnd'and qu_qusyn != 'N'; ";
            return db.QueryAsync<object>(sql, parameters, commandType: CommandType.Text).Result.ToList();
        }
        public async Task<object> updateQuestionData(QuestionUpdateDataModel model)
        {
            var parameters = new DynamicParameters();
            string sql = " update mwd_question ";
            sql += " SET qu_explain='" + model.qu_explain + "' ";
            sql += " WHERE qu_code='" + model.qu_code + "'; ";
            await db.ExecuteAsync(sql);
            return await selectQuestionData();
        }



        public async Task<List<InstituteListView>> GetInstituteList()
        {
            try
            {
                var parameters = new DynamicParameters();
               // parameters.Add("search_ins_name", searchInsName);

                string sql = @"
            SELECT 
                ins.ins_seq,
                ins.ins_name,
                ac.ac_id,
                pe.pe_name,
                pe.pe_cellphone,
                anp.anp_seq,
                TO_CHAR(anp.anp_start_date, 'YYYY-MM-DD') AS anp_start_date,
                COALESCE(TO_CHAR(anp.anp_end_date, 'YYYY-MM-DD'), '') AS anp_end_date
            FROM 
                mwd_account ac
                JOIN mwd_person pe ON ac.pe_seq = pe.pe_seq
                JOIN mwd_institute_member insm ON pe.pe_seq = insm.pe_seq
                JOIN mwd_answer_progress anp ON ac.ac_gid = anp.ac_gid
                JOIN mwd_choice_result cr ON anp.cr_seq = cr.cr_seq
                JOIN mwd_institute ins ON insm.ins_seq = ins.ins_seq
        
            ORDER BY 
                ins.ins_seq desc , ac_id asc";


                //WHERE
                //ins.ins_name LIKE '%' || @search_ins_name || '%'

                var result = await db.QueryAsync<InstituteListView>(sql, parameters, commandType: CommandType.Text);
                return result.ToList();
            }
            catch (Exception ex)
            {
                // 예외가 발생한 경우 여기서 처리
                // ex 변수를 이용하여 예외 정보를 확인할 수 있습니다.
                Console.WriteLine($"An error occurred: {ex.Message}");
                // 필요한 경우 예외를 다시 throw하거나 다른 처리를 수행할 수 있습니다.
                throw;
            }
        }

        //회원정보
        public async Task<PersonInformation> GetPersonInformation(int anpSeq)
        {
            try
            {
                string sql = @"
                SELECT 
                    ac.ac_id AS Id,
                    pe.pe_name AS PName,
                    pe.pe_birth_year || '년 ' || pe.pe_birth_month || '월 ' || pe.pe_birth_day || '일' AS Birthdate,
                    CASE 
                        WHEN pe.pe_sex = 'M' THEN '남'
                        ELSE '여'
                    END AS Sex,
                    pe.pe_cellphone AS Cellphone,
                    pe.pe_contact AS Contact,
                    pe.pe_email AS Email,
                    COALESCE(ec.ename, '') AS Education,
                    pe.pe_school_name AS School,
                    pe.pe_school_year AS SchoolYear,
                    pe.pe_school_major AS SchoolMajor,
                    COALESCE(jc.jname, '') AS Job,
                    CAST(EXTRACT(YEAR FROM AGE(CAST(LPAD(CAST(pe.pe_birth_year AS TEXT), 4, '0') || LPAD(CAST(pe.pe_birth_month AS TEXT), 2, '0') || LPAD(CAST(pe.pe_birth_day AS TEXT), 2, '0') AS DATE))) AS INT) AS Age,
                    pe.pe_job_name AS JobName,
                    pe.pe_job_detail AS JobDetail
                FROM 
                    mwd_answer_progress ap
                    JOIN mwd_account ac ON ac.ac_gid = ap.ac_gid
                    JOIN mwd_person pe ON pe.pe_seq = ac.pe_seq
                    LEFT OUTER JOIN (
                        SELECT coc_code ecode, coc_code_name ename
                        FROM mwd_common_code
                        WHERE coc_group = 'UREDU'
                    ) ec ON pe.pe_ur_education = ec.ecode
                    LEFT OUTER JOIN (
                        SELECT coc_code jcode, coc_code_name jname
                        FROM mwd_common_code
                        WHERE coc_group = 'URJOB'
                    ) jc ON pe.pe_ur_job = jc.jcode
                WHERE 
                    ap.anp_seq = @AnpSeq";

                var parameters = new { AnpSeq = anpSeq };

                // Execute the query
                var result = await db.QueryFirstAsync<PersonInformation>(sql, parameters, commandType: CommandType.Text);
                return result;

            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }


        //성향진단
        public async Task<PersonalityDiagnosis> GetPersonalityDiagnosis(int anpSeq)
        {
            try
            {
                string sql = @"
                SELECT max(CASE 
			            WHEN rk = 1
				            THEN tnd
			            END) AS Tnd1
	            ,max(CASE 
			            WHEN rk = 2
				            THEN tnd
			            END) AS Tnd2
	            ,max(CASE 
			            WHEN rk = 3
				            THEN tnd
			            END) AS Tnd3
            FROM (
	            SELECT replace(qa.qua_name, '형', '') AS tnd
		            ,1 AS rk
	            FROM mwd_resval rv
		            ,mwd_question_attr qa
	            WHERE rv.anp_seq = @AnpSeq
		            AND qa.qua_code = rv.rv_tnd1
	            UNION
	            SELECT replace(qa.qua_name, '형', '') AS tnd
		            ,2 AS rk
	            FROM mwd_resval rv
		            ,mwd_question_attr qa
	            WHERE rv.anp_seq = @AnpSeq
		            AND qa.qua_code = rv.rv_tnd2
		        UNION
	            SELECT replace(qa.qua_name, '형', '') AS tnd
		            ,3 AS rk
	            FROM mwd_resval rv
		            ,mwd_question_attr qa
	            WHERE rv.anp_seq = @AnpSeq
		            AND qa.qua_code = rv.rv_tnd3
		
	            ) t ";

                var parameters = new { AnpSeq = anpSeq };

                // Execute the query
                var result = await db.QueryFirstAsync<PersonalityDiagnosis>(sql, parameters, commandType: CommandType.Text);
                return result;

            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }


        public async Task<List<QuestionInfo>> GetQuestions(int anpSeq)
        {
            try
            {
                string sql = @"
                SELECT qa.qua_name, REPLACE(qe.que_explain, '당신', '' || '님') AS QuestionExplanation
                FROM mwd_resval rv
                    JOIN mwd_question_explain qe ON (rv.rv_tnd1 = qe.qua_code OR rv.rv_tnd2 = qe.qua_code OR rv.rv_tnd3 = qe.qua_code)
                    JOIN mwd_question_attr qa ON qe.qua_code = qa.qua_code
                WHERE rv.anp_seq = @AnpSeq";

                var parameters = new { AnpSeq = anpSeq };

                // Execute the query
                var result = await db.QueryAsync<QuestionInfo>(sql, parameters, commandType: CommandType.Text);
                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        // 성향분석
        public async Task<List<QuestionExplanation>> GetQuestionExplains(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
                SELECT qu.qu_explain as qu_explain
                FROM mwd_answer an
                    , mwd_question qu
	                ,(
                        SELECT qua_code
                            , sc1_rank
                        FROM mwd_score1 sc1
                        WHERE anp_seq = @anp_seq
                            AND sc1_step = 'tnd'
                            AND sc1_rank <= 3
		                ) sc1
                WHERE an.anp_seq = @anp_seq
                    AND qu.qu_code = an.qu_code
                    AND qu.qu_use = 'Y'
                    AND qu.qu_qusyn = 'Y'
                    AND qu.qu_kind1 = 'tnd'
                    AND an.an_wei >= 4
                    AND qu.qu_kind2 = sc1.qua_code
                ORDER BY an.an_wei DESC , sc1_rank";

                var result = await db.QueryAsync<QuestionExplanation>(sql, parameters, commandType: CommandType.Text);
                return result.ToList() ;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //사고력
        public async Task<List<ScoreExplanation>> GetScoreExplanations(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT qa.qua_name as quaName
	            ,round(sc1.sc1_rate * 100) AS score
	            ,replace(qe.que_explain, '당신', '' || '님') AS explain
            FROM mwd_score1 sc1
	            ,mwd_question_attr qa
	            ,mwd_question_explain qe
            WHERE sc1.anp_seq = @anp_seq
	            AND sc1.sc1_step = 'thk'
	            AND qa.qua_code = sc1.qua_code
	            AND qe.qua_code = qa.qua_code
	            AND qe.que_switch = CASE 
		            WHEN sc1.sc1_rate * 100 BETWEEN 80
				            AND 100
			            THEN 1
		            WHEN sc1.sc1_rate * 100 BETWEEN 51
				            AND 79
			            THEN 2
		            ELSE 3
		            END
            ORDER BY sc1.sc1_rank";

                var result = await db.QueryAsync<ScoreExplanation>(sql, parameters, commandType: CommandType.Text);
                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        // 1.성향적합직업학과
        public async Task<TendencyModel> GetTendencyAndJobDescription(int anpSeq)
        {
            try
            {

                string sql = @"
                    SELECT REPLACE(
                        (SELECT qua_name FROM mwd_question_attr, mwd_resval WHERE anp_seq = @AnpSeq AND qua_code = rv_tnd1) || 
                        (SELECT qua_name FROM mwd_question_attr, mwd_resval WHERE anp_seq = @AnpSeq AND qua_code = rv_tnd2), '형', '') AS Tendency,
                        STRING_AGG(jo.jo_name, ', ') AS TndJob
                    FROM (
                        SELECT rej_code
                        FROM mwd_resjob
                        WHERE anp_seq = @AnpSeq
                            AND rej_kind = 'rtnd'
                            AND rej_rank <= 7
                    ) j
                    JOIN mwd_job jo ON jo.jo_code = j.rej_code";

                var parameters = new { AnpSeq = anpSeq };

                // Execute the query
                var result = await db.QueryFirstAsync<TendencyModel>(sql, parameters, commandType: CommandType.Text);
                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //2.성향적합직업학과
        public async Task<List<RecommendedJobModel>> GetRecommendedJobs(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT jo.jo_name as JobName, jo.jo_outline as JobOutline, jo.jo_mainbusiness as JobMainBusiness
            FROM mwd_resjob rj
            JOIN mwd_job jo ON jo.jo_code = rj.rej_code
            WHERE rj.anp_seq = @anp_seq
                AND rj.rej_kind = 'rtnd'
                AND rj.rej_rank <= 7
            ORDER BY rj.rej_rank";

                var result = await db.QueryAsync<RecommendedJobModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //3.성향적합직업학과
        public async Task<List<JobWithMajorModel>> GetJobsWithMajor(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT jo.jo_name as JobName, string_agg(ma.ma_name, ', ' ORDER BY ma.ma_name) AS Major
            FROM mwd_resjob rj
            JOIN mwd_job jo ON jo.jo_code = rj.rej_code
            JOIN mwd_job_major_map jmm ON jmm.jo_code = rj.rej_code
            JOIN mwd_major ma ON ma.ma_code = jmm.ma_code
            WHERE rj.anp_seq = @anp_seq
                AND rj.rej_kind = 'rtnd'
                AND rj.rej_rank <= 7
            GROUP BY jo.jo_code, rj.rej_rank
            ORDER BY rj.rej_rank";

                var result = await db.QueryAsync<JobWithMajorModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        // 1.역량진단
        public async Task<TalentModel> GetTalents(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT string_agg(qa.qua_name, ', ' ORDER BY sc1.sc1_rank) AS Talents
            FROM mwd_question_attr qa
            JOIN mwd_score1 sc1 ON sc1.qua_code = qa.qua_code
            WHERE anp_seq = @anp_seq
                AND sc1_step = 'tal'
                AND sc1_rank <= 5";

                var result = await db.QueryFirstOrDefaultAsync<TalentModel>(sql, parameters, commandType: CommandType.Text);

                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //1.역량진단
        public async Task<List<TalentScoreModel>> GetTalentScores(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
                       SELECT qa.qua_name as TalentName
	            ,round(sc1.sc1_rate * 100) AS TalentScore
	            ,replace(qe.que_explain, '당신', '' || '님') AS Explanation
            FROM mwd_score1 sc1
	            ,mwd_question_attr qa
	            ,mwd_question_explain qe
            WHERE sc1.anp_seq = @anp_seq
	            AND sc1.sc1_step = 'tal'
	            AND qa.qua_code = sc1.qua_code
	            AND qe.qua_code = qa.qua_code
	            AND sc1.sc1_rank <= 5
            ORDER BY sc1.sc1_rank";

                var result = await db.QueryAsync<TalentScoreModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //2. 역량적합직업
        public async Task<List<TalentJobModel>> GetJobTalents(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT jo.jo_name AS TalentName
                ,jo.jo_outline AS TalentOutline
                ,jo.jo_mainbusiness AS MainBusiness
            FROM mwd_resjob rj
                JOIN mwd_job jo ON jo.jo_code = rj.rej_code
            WHERE rj.anp_seq = @anp_seq
                AND rj.rej_kind = 'rtal'
                AND rj.rej_rank <= 7
            ORDER BY rj.rej_rank";

                var result = await db.QueryAsync<TalentJobModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //3. 역량적합직업학과
        public async Task<List<JobMajorModel>> GetJobMajorList(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT jo.jo_name AS JobName
                ,string_agg(ma.ma_name, ', ' ORDER BY ma.ma_name) AS Majors
            FROM mwd_resjob rj
                JOIN mwd_job jo ON jo.jo_code = rj.rej_code
                JOIN mwd_job_major_map jmm ON jmm.jo_code = rj.rej_code
                JOIN mwd_major ma ON ma.ma_code = jmm.ma_code
            WHERE rj.anp_seq = @anp_seq
                AND rj.rej_kind = 'rtal'
                AND rj.rej_rank <= 7
            GROUP BY jo.jo_code, rj.rej_rank
            ORDER BY rj.rej_rank";

                var result = await db.QueryAsync<JobMajorModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //학습
        public async Task<TendencyStudyModel> GetTendencyStudy(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT 
                (
                    SELECT replace(qa.qua_name, '형', '')
                    FROM mwd_question_attr qa
                    WHERE qa.qua_code = rv.rv_tnd1
                ) AS Tendency1,
                replace(ts1.tes_study_tendency, '당신', '' || '님') AS Tendency1Study,
                replace(ts1.tes_study_way, '당신', '' || '님') AS Tendency1Way,
                (
                    SELECT replace(qa.qua_name, '형', '')
                    FROM mwd_question_attr qa
                    WHERE qa.qua_code = rv.rv_tnd2
                ) AS Tendency2,
                replace(ts2.tes_study_tendency, '당신', '' || '님') AS Tendency2Study,
                replace(ts2.tes_study_way, '당신', '' || '님') AS Tendency2Way,
                cast(substring(rv.rv_tnd1, 4, 2) AS INT) - 10 AS Tendency1Row,
                cast(substring(rv.rv_tnd2, 4, 2) AS INT) - 10 AS Tendency2Col
            FROM mwd_resval rv
                JOIN mwd_tendency_study ts1 ON ts1.qua_code = rv.rv_tnd1
                JOIN mwd_tendency_study ts2 ON ts2.qua_code = rv.rv_tnd2
            WHERE anp_seq = @anp_seq";

                var result = await db.QueryFirstOrDefaultAsync<TendencyStudyModel>(sql, parameters, commandType: CommandType.Text);

                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //적합한 학습법1  최적학습 투자비율 추천1
        public async Task<List<StudyWayModel>> GetStudyWayRecommendations(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT 
                sr.sw_kindname AS StudyName,
                cast(sr.sw_rate * 100 AS INT) AS StudyRate,
                sr.sw_color AS StudyColor
            FROM mwd_resval rv
                JOIN mwd_studyway_rate sr ON sr.qua_code = rv.rv_tnd1
            WHERE rv.anp_seq = @anp_seq
                AND sr.sw_type = 'S'
            ORDER BY sr.sw_kind";

                var result = await db.QueryAsync<StudyWayModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //최적학습 투자비율 추천2
        public async Task<List<StudyWayModel>> GetOptimalStudyInvestmentRecommendations(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT 
                sr.sw_kindname AS StudyName,
                cast(sr.sw_rate * 100 AS INT) AS StudyRate,
                sr.sw_color AS StudyColor
            FROM mwd_resval rv
                JOIN mwd_studyway_rate sr ON sr.qua_code = rv.rv_tnd2
            WHERE rv.anp_seq = @anp_seq
                AND sr.sw_type = 'S'
            ORDER BY sr.sw_kind";

                var result = await db.QueryAsync<StudyWayModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //적합한 학습법2    최적 학습지도비율 추천1
        public async Task<List<StudyWayModel>> GetOptimalStudyGuidanceRecommendations(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT 
                sr.sw_kindname AS StudyName,
                cast(sr.sw_rate * 100 AS INT) AS StudyRate,
                sr.sw_color AS StudyColor
            FROM mwd_resval rv
                JOIN mwd_studyway_rate sr ON sr.qua_code = rv.rv_tnd1
            WHERE rv.anp_seq = @anp_seq
                AND sr.sw_type = 'W'
            ORDER BY sr.sw_kind";

                var result = await db.QueryAsync<StudyWayModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //적합한 학습법2    최적 학습지도비율 추천2
        public async Task<List<StudyWayModel>> GetOptimalStudyGuidanceRecommendations2(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT 
                sr.sw_kindname AS StudyName,
                cast(sr.sw_rate * 100 AS INT) AS StudyRate,
                sr.sw_color AS StudyColor
            FROM mwd_resval rv
                JOIN mwd_studyway_rate sr ON sr.qua_code = rv.rv_tnd1
            WHERE rv.anp_seq = @anp_seq
                AND sr.sw_type = 'W'
            ORDER BY sr.sw_kind";

                var result = await db.QueryAsync<StudyWayModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //교과목  적성적합 교과목순위
        public async Task<List<TendencySubjectModel>> GetTendencySubjectRankings(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT subject AS srank
	,tsm_subject_group AS sgroup
	,tsm_subject_choice AS schoice
	,tsm_subject AS subject
	,tsm_subject_explain AS sexplain
	,qua_name AS tnd1
	,rank() OVER (
		PARTITION BY tsm_subject_group
		,tsm_subject_choice ORDER BY cast(subject AS INT)
		) AS srank2
FROM (
	SELECT CASE 
			WHEN rv.rv_tnd1 = 'tnd11000'
				THEN sm.tsm_communication_type /*소통형 */
			WHEN rv.rv_tnd1 = 'tnd12000'
				THEN sm.tsm_creation_type /*창조형 */
			WHEN rv.rv_tnd1 = 'tnd13000'
				THEN sm.tsm_practical_type /*실용형 */
			WHEN rv.rv_tnd1 = 'tnd14000'
				THEN sm.tsm_sports_type /*운동형 */
			WHEN rv.rv_tnd1 = 'tnd15000'
				THEN sm.tsm_norm_type /*규범형 */
			WHEN rv.rv_tnd1 = 'tnd16000'
				THEN sm.tsm_inference_type /*추리형 */
			WHEN rv.rv_tnd1 = 'tnd17000'
				THEN sm.tsm_production_type /*제작형 */
			WHEN rv.rv_tnd1 = 'tnd18000'
				THEN sm.tsm_life_type /*생명형 */
			WHEN rv.rv_tnd1 = 'tnd19000'
				THEN sm.tsm_analysis_type /*분석형 */
			WHEN rv.rv_tnd1 = 'tnd20000'
				THEN sm.tsm_observation_type /*관찰형 */
			WHEN rv.rv_tnd1 = 'tnd21000'
				THEN sm.tsm_principle_type /*원리형 */
			WHEN rv.rv_tnd1 = 'tnd22000'
				THEN sm.tsm_service_type /*봉사형 */
			WHEN rv.rv_tnd1 = 'tnd23000'
				THEN sm.tsm_education_type /*교육형 */
			WHEN rv.rv_tnd1 = 'tnd24000'
				THEN sm.tsm_multiplex_type /*복합형 */
			WHEN rv.rv_tnd1 = 'tnd25000'
				THEN sm.tsm_adventurous_type /*진취형 */
			END AS subject
		,sm.tsm_subject_group
		,sm.tsm_subject_choice
		,sm.tsm_subject
		,sm.tsm_subject_explain
		,sm.tsm_subject_code
		,qa.qua_name
		,sm.tsm_subject_group_code
		,sm.tsm_subject_choice_code
	FROM mwd_resval rv
		,mwd_tendency_subject_map sm
		,mwd_question_attr qa
	WHERE anp_seq = @anp_seq
		AND sm.tsm_use = 'Y'
		AND qa.qua_code = rv.rv_tnd1
	) t
ORDER BY tsm_subject_group_code
	,tsm_subject_choice_code
	,cast(subject AS INT)
	,tsm_subject_code;";

                var result = await db.QueryAsync<TendencySubjectModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        // 교과목  강한 적성별 교과목 리스트
        public async Task<List<StrongTendencySubjectModel>> GetStrongTendencySubjectList(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT 
                subject AS SubjectRank,
                tsm_subject_group AS SubjectGroup,
                tsm_subject_choice AS SubjectChoice,
                tsm_subject AS Subject,
                tsm_subject_explain AS SubjectExplain,
                qua_name AS Tendency1
            FROM (
                SELECT 
                    CASE 
                        WHEN rv.rv_tnd1 = 'tnd11000' THEN sm.tsm_communication_type
                        WHEN rv.rv_tnd1 = 'tnd12000' THEN sm.tsm_creation_type
                        WHEN rv.rv_tnd1 = 'tnd13000' THEN sm.tsm_practical_type
                        WHEN rv.rv_tnd1 = 'tnd14000' THEN sm.tsm_sports_type
                        WHEN rv.rv_tnd1 = 'tnd15000' THEN sm.tsm_norm_type
                        WHEN rv.rv_tnd1 = 'tnd16000' THEN sm.tsm_inference_type
                        WHEN rv.rv_tnd1 = 'tnd17000' THEN sm.tsm_production_type
                        WHEN rv.rv_tnd1 = 'tnd18000' THEN sm.tsm_life_type
                        WHEN rv.rv_tnd1 = 'tnd19000' THEN sm.tsm_analysis_type
                        WHEN rv.rv_tnd1 = 'tnd20000' THEN sm.tsm_observation_type
                        WHEN rv.rv_tnd1 = 'tnd21000' THEN sm.tsm_principle_type
                        WHEN rv.rv_tnd1 = 'tnd22000' THEN sm.tsm_service_type
                        WHEN rv.rv_tnd1 = 'tnd23000' THEN sm.tsm_education_type
                        WHEN rv.rv_tnd1 = 'tnd24000' THEN sm.tsm_multiplex_type
                        WHEN rv.rv_tnd1 = 'tnd25000' THEN sm.tsm_adventurous_type
                    END AS Subject,
                    sm.tsm_subject_group,
                    sm.tsm_subject_choice,
                    sm.tsm_subject,
                    sm.tsm_subject_explain,
                    sm.tsm_subject_code,
                    qa.qua_name
                FROM mwd_resval rv
                    JOIN mwd_tendency_subject_map sm ON qa.qua_code = rv.rv_tnd1 AND sm.tsm_use = 'Y'
                    JOIN mwd_question_attr qa ON qa.qua_code = rv.rv_tnd1
                WHERE anp_seq = @anp_seq
            ) t
            ORDER BY CAST(subject AS INT), tsm_subject_code";

                var result = await db.QueryAsync<StrongTendencySubjectModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        // 직무  적합직무군 
        public async Task<List<RecommendedDutyModel>> GetRecommendedDutyList(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT 
                du_name AS DutyName,
                du_outline AS DutyOutline,
                du_department AS DutyDepartment
            FROM mwd_resduty rd
                JOIN mwd_duty du ON du.du_code = rd.red_code
            WHERE anp_seq = @anp_seq
                AND red_kind = 'rtnd'
                AND rd.red_rank <= 5
            ORDER BY rd.red_rank";

                var result = await db.QueryAsync<RecommendedDutyModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //선호도
        public async Task<PreferenceModel> GetPreferences(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT 
                max(CASE WHEN rk2 = 1 THEN qua_name END) AS Name1,
                max(CASE WHEN rk2 = 1 THEN sc1_qcnt END) AS QCount1,
                max(CASE WHEN rk2 = 1 THEN rrate END) AS Rate1,
                max(CASE WHEN rk2 = 2 THEN qua_name END) AS Name2,
                max(CASE WHEN rk2 = 2 THEN sc1_qcnt END) AS QCount2,
                max(CASE WHEN rk2 = 2 THEN rrate END) AS Rate2,
                max(CASE WHEN rk2 = 3 THEN qua_name END) AS Name3,
                max(CASE WHEN rk2 = 3 THEN sc1_qcnt END) AS QCount3,
                max(CASE WHEN rk2 = 3 THEN rrate END) AS Rate3,
                max(CASE WHEN rk2 = 1 THEN que_explain END) AS Explanation1,
                max(CASE WHEN rk2 = 2 THEN que_explain END) AS Explanation2,
                max(CASE WHEN rk2 = 3 THEN que_explain END) AS Explanation3
            FROM (
                SELECT 
                    qa.qua_name,
                    sc1.sc1_qcnt,
                    round(sc1.sc1_resrate * 100) AS rrate,
                    row_number() OVER (PARTITION BY sc1.sc1_rank) AS rk,
                    sc1.sc1_rank rk2,
                    qe.que_explain
                FROM mwd_score1 sc1
                    JOIN mwd_question_attr qa ON qa.qua_code = sc1.qua_code
                    JOIN mwd_question_explain qe ON qe.qua_code = qa.qua_code
                WHERE sc1.anp_seq = @anp_seq
                    AND sc1.sc1_step = 'img'
                    AND sc1.sc1_rank <= 3
                    AND qe.que_switch = 1
                ORDER BY sc1.sc1_rank
            ) t
            WHERE rk = 1";

                var result = await db.QueryFirstOrDefaultAsync<PreferenceModel>(sql, parameters, commandType: CommandType.Text);

                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //선호도
        public async Task<List<JobModel>> GetJobs(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);

                string sql = @"
            SELECT 
                qa.qua_name AS QualificationName,
                jo.jo_name AS JobName,
                jo.jo_outline AS JobOutline,
                jo.jo_mainbusiness AS MainBusiness,
                string_agg(ma.ma_name, ', ' ORDER BY ma.ma_name) AS MajorNames
            FROM mwd_job jo
                JOIN mwd_job_major_map jmm ON jmm.jo_code = jo.jo_code
                JOIN mwd_major ma ON ma.ma_code = jmm.ma_code
                LEFT OUTER JOIN mwd_resjob rj ON rj.rej_code = jo.jo_code
                LEFT OUTER JOIN mwd_question_attr qa ON qa.qua_code = rj.rej_quacode
            WHERE rj.anp_seq = @anp_seq
                AND rj.rej_kind = 'rimg1'
                AND rj.rej_rank <= 5
            GROUP BY rj.rej_kind, qa.qua_code, jo.jo_code, rj.rej_rank
            ORDER BY rj.rej_kind";

                var result = await db.QueryAsync<JobModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //선호도
        public async Task<List<JobModel>> GetJobs2(int anpSeq, string rejKind)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);
                parameters.Add("rej_kind", rejKind);

                string sql = @"
            SELECT 
                qa.qua_name AS QualificationName,
                jo.jo_name AS JobName,
                jo.jo_outline AS JobOutline,
                jo.jo_mainbusiness AS MainBusiness,
                string_agg(ma.ma_name, ', ' ORDER BY ma.ma_name) AS MajorNames
            FROM mwd_job jo
                JOIN mwd_job_major_map jmm ON jmm.jo_code = jo.jo_code
                JOIN mwd_major ma ON ma.ma_code = jmm.ma_code
                LEFT OUTER JOIN mwd_resjob rj ON rj.rej_code = jo.jo_code
                LEFT OUTER JOIN mwd_question_attr qa ON qa.qua_code = rj.rej_quacode
            WHERE rj.anp_seq = @anp_seq
                AND rj.rej_kind = 'rimg2'
                AND rj.rej_rank <= 5
            GROUP BY rj.rej_kind, qa.qua_code, jo.jo_code, rj.rej_rank
            ORDER BY rj.rej_kind";

                var result = await db.QueryAsync<JobModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }
        }
        //선호도
        public async Task<List<JobModel>> GetJobsRimg3(int anpSeq)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("anp_seq", anpSeq);
                parameters.Add("rej_kind", "rimg3");

                string sql = @"
            SELECT 
                qa.qua_name AS QualificationName,
                jo.jo_name AS JobName,
                jo.jo_outline AS JobOutline,
                jo.jo_mainbusiness AS MainBusiness,
                string_agg(ma.ma_name, ', ' ORDER BY ma.ma_name) AS MajorNames
            FROM mwd_job jo
                JOIN mwd_job_major_map jmm ON jmm.jo_code = jo.jo_code
                JOIN mwd_major ma ON ma.ma_code = jmm.ma_code
                LEFT OUTER JOIN mwd_resjob rj ON rj.rej_code = jo.jo_code
                LEFT OUTER JOIN mwd_question_attr qa ON qa.qua_code = rj.rej_quacode
            WHERE rj.anp_seq = @anp_seq
                AND rj.rej_kind = 'rimg3'
                AND rj.rej_rank <= 5
            GROUP BY rj.rej_kind, qa.qua_code, jo.jo_code, rj.rej_rank
            ORDER BY rj.rej_kind";

                var result = await db.QueryAsync<JobModel>(sql, parameters, commandType: CommandType.Text);

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Throw or handle the exception as needed
                throw;
            }

        }
    }
}
