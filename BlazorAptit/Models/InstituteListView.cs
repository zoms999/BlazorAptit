namespace BlazorAptit.Models
{
    public class InstituteListView
    {
        public int ins_seq { get; set; }
        public string ins_name { get; set; }
        public string ac_id { get; set; } // ac_id를 문자열로 변경
        public string pe_name { get; set; }
        public string pe_cellphone { get; set; }
        public int anp_seq { get; set; }
        public string anp_start_date { get; set; }
        public string anp_end_date { get; set; }
    }

    public class PersonInformation
    {
        public string Id { get; set; }
        public string PName { get; set; }
        public string Birthdate { get; set; }
        public string Sex { get; set; }
        public string Cellphone { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string School { get; set; }
        public int? SchoolYear { get; set; }
        public string SchoolMajor { get; set; }
        public string Job { get; set; }
        public int? Age { get; set; }
        public string JobName { get; set; }
        public string JobDetail { get; set; }
    }

    public class PersonalityDiagnosis
    {
        public string Tnd1 { get; set; }
        public string Tnd2 { get; set; }
        public string Tnd3 { get; set; }
    }


    public class QuestionInfo
    {
        public string QuaName { get; set; }
        public string QuestionExplanation { get; set; }
    }

    public class QuestionExplanation
    {
        public string QuExplain { get; set; }
    }

    public class ScoreExplanation
    {
        public string QuaName { get; set; }
        public int Score { get; set; }
        public string Explain { get; set; }
    }
    public class TendencyModel
    {
        public string Tendency { get; set; }
        public string TndJob { get; set; }
    }
    public class RecommendedJobModel
    {
        public string JobName { get; set; }
        public string JobOutline { get; set; }
        public string JobMainBusiness { get; set; }
    }
    public class JobWithMajorModel
    {
        public string JobName { get; set; }
        public string Major { get; set; }
    }
    public class TalentModel
    {
        public string Talents { get; set; }
    }
    public class TalentScoreModel
    {
        public string TalentName { get; set; }
        public int TalentScore { get; set; }
        public string Explanation { get; set; }
    }
    public class TalentJobModel
    {
        public string TalentName { get; set; }
        public string TalentOutline { get; set; }
        public string MainBusiness { get; set; }
    }
    public class JobMajorModel
    {
        public string JobName { get; set; }
        public string Majors { get; set; }
    }

    public class TendencyStudyModel
    {
        public string Tendency1 { get; set; }
        public string Tendency1Study { get; set; }
        public string Tendency1Way { get; set; }
        public string Tendency2 { get; set; }
        public string Tendency2Study { get; set; }
        public string Tendency2Way { get; set; }
        public int Tendency1Row { get; set; }
        public int Tendency2Col { get; set; }
    }

    public class StudyWayModel
    {
        public string StudyName { get; set; }
        public int StudyRate { get; set; }
        public string StudyColor { get; set; }
    }

    public class TendencySubjectModel
    {
        public string SubjectRank { get; set; }
        public string SubjectGroup { get; set; }
        public string SubjectChoice { get; set; }
        public string Subject { get; set; }
        public string SubjectExplain { get; set; }
        public string Tendency1 { get; set; }
        public int SubjectRank2 { get; set; }
    }


    public class StrongTendencySubjectModel
    {
        public string SubjectRank { get; set; }
        public string SubjectGroup { get; set; }
        public string SubjectChoice { get; set; }
        public string Subject { get; set; }
        public string SubjectExplain { get; set; }
        public string Tendency1 { get; set; }
    }

    public class RecommendedDutyModel
    {
        public string DutyName { get; set; }
        public string DutyOutline { get; set; }
        public string DutyDepartment { get; set; }
    }

    public class PreferenceModel
    {
        public string Name1 { get; set; }
        public int QCount1 { get; set; }
        public int Rate1 { get; set; }
        public string Name2 { get; set; }
        public int QCount2 { get; set; }
        public int Rate2 { get; set; }
        public string Name3 { get; set; }
        public int QCount3 { get; set; }
        public int Rate3 { get; set; }
        public string Explanation1 { get; set; }
        public string Explanation2 { get; set; }
        public string Explanation3 { get; set; }
    }

    public class JobModel
    {
        public string QualificationName { get; set; }
        public string JobName { get; set; }
        public string JobOutline { get; set; }
        public string MainBusiness { get; set; }
        public string MajorNames { get; set; }
    }


}
