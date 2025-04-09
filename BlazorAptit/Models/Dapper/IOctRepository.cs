using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAptit.Models.Dapper
{
    public interface IOctRepository
    {
        Task<object> GetUserList();
        Task<object> GetUserListDetail(string pe_seq);
        Task<object> GetUserInfo(string ac_id);
        Task<object> GetEnterList();
        Task<object> GetEnterInfo(string ins_seq);
        Task<object> GetUserResultList();
        Task<object> GetEnterResultUserList(string ins_seq, string tur_seq);
        Task<object> GetQuestionExplain();
        Task<object> GetJobList();
        Task<object> GetMajorList();
        Task<object> GetDutyList();
        Task<object> GetCommonCode();
        Task<object> updateJob(JobUpdateModel model);
        Task<object> updateMajor(MajorionUpdateModel model);
        Task<object> updateDuty(DutyUpdateModel model);
        Task<object> updateQuestion(QuestionUpdateModel model);

        Task<object> selectQuestionData();
        Task<object> updateQuestionData(QuestionUpdateDataModel model);



        Task<List<InstituteListView>> GetInstituteList();
        Task<PersonInformation> GetPersonInformation(int anpSeq);

        Task<PersonalityDiagnosis> GetPersonalityDiagnosis(int anpSeq);
        Task<List<QuestionInfo>> GetQuestions(int anpSeq);
        Task<List<QuestionExplanation>> GetQuestionExplains(int anpSeq);
        Task<List<ScoreExplanation>> GetScoreExplanations(int anpSeq);
        Task<TendencyModel> GetTendencyAndJobDescription(int anpSeq);
        Task<List<RecommendedJobModel>> GetRecommendedJobs(int anpSeq);
        Task<List<JobWithMajorModel>> GetJobsWithMajor(int anpSeq);
        Task<TalentModel> GetTalents(int anpSeq);
        Task<List<TalentScoreModel>> GetTalentScores(int anpSeq);
        Task<List<TalentJobModel>> GetJobTalents(int anpSeq);
        Task<List<JobMajorModel>> GetJobMajorList(int anpSeq);
        Task<TendencyStudyModel> GetTendencyStudy(int anpSeq);
        Task<List<StudyWayModel>> GetStudyWayRecommendations(int anpSeq);
        Task<List<StudyWayModel>> GetOptimalStudyInvestmentRecommendations(int anpSeq);
        Task<List<StudyWayModel>> GetOptimalStudyGuidanceRecommendations(int anpSeq);
        Task<List<StudyWayModel>> GetOptimalStudyGuidanceRecommendations2(int anpSeq);
        Task<List<TendencySubjectModel>> GetTendencySubjectRankings(int anpSeq);
        Task<List<StrongTendencySubjectModel>> GetStrongTendencySubjectList(int anpSeq);
        Task<List<RecommendedDutyModel>> GetRecommendedDutyList(int anpSeq);
        Task<PreferenceModel> GetPreferences(int anpSeq);
        Task<List<JobModel>> GetJobs(int anpSeq);
        Task<List<JobModel>> GetJobs2(int anpSeq, string rejKind);
        Task<List<JobModel>> GetJobsRimg3(int anpSeq);

    }
}