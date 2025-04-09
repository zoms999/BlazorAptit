using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAptit.Models.Dapper
{
    public interface IAptitRepository
    {
        List<AptitQuestion> GetAllAptitQuestions();
        Task<List<Order>> GetQuestionByID(int? ID);
        Task<List<AptitQuestion>> GetAllAptitQuestionsAsyns();
        Task<List<AptitResultUserView> > GetGroupByID(string groupID);
        Task<List<AptitGroup>> GetAllAptitUsers();
        Task<List<AptitUser>> GetAllUserList();
        Task<List<AptitResult>> GetUsersResult(int AptitAnswerID);
        Task<List<AptitReply>> GetUsersReply(int AptitUserID);
        Task<List<UserReplyView>> GetUsersReplyView(int AptitUserID);
        Task<bool> EditAsync(string id, Order value);
        bool Edit(string id, Order model);
        Task<List<AptitResult>> GetAllAptitResultManagesAsyns();
        Task<List<ResultContent>> GetResultManagesByID(int? ID);
        Task<List<ResultContent>> GetReplyManagesByID(int? ID);
        Task<List<AptitReply>> GetAllAptitReplyManagesAsyns();
        Task<bool> EditResultManagesAsync(string id, ResultContent value);
        Task<bool> EditReplyManagesAsync(string id, ResultContent value);
        Task<List<AptitGroup>> GetAllGroupList();
        Task<bool> EditGroupListAsync(AptitGroup model);
        Task<List<AptitGroup>> GetAllTodayGroupList(DateTime? today);
        Task<List<AptitUser>> 오늘검사단체(DateTime? today);
        Task<List<AptitRankView>> 성향유형전체통계(int rank);
        Task<List<AptitUserQue>> GetResultScore(int AptitUserID);
        Task<bool> UpdateResultScoreAsync(AptitUserQue model);
        Task<string> GetPwd(string email);
        Task<bool> UserEdit(AptitUser value);
        Task<string> GetGroupMemberLoginCheck(string userid, string userpw);

        Task<bool> SetUserRankInsert(int aptituserid);

    }
}
