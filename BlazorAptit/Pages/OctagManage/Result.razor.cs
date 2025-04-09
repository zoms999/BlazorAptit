using BlazorAptit.Models;
using BlazorAptit.Models.Dapper;
using BlazorAptit.Models.EfCore;
using BlazorDemos.Data.FileFormats.PDF;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using OfficeOpenXml;
using Syncfusion.Blazor.Charts;
using Syncfusion.Blazor.Grids;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace BlazorAptit.Pages.OctagManage
{
    public partial class Result
    {

        SfGrid<AptitResultUserView> SubGrid;

        [Inject]
        public IRepository RepositoryAsync { get; set; }

        [Inject]
        public IAptitRepository AptitRepository { get; set; }

        [Inject]
        public IOctRepository OctRepository { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

         [Inject]
        Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment { get; set; }

         [Inject] public IJSRuntime JS { get; set; }

        protected List<InstituteListView> InstituteListResult{ get; set; }

        List<AptitResultUserView> Users = new List<AptitResultUserView>();

        List<AptitReply> AptitReplys = new List<AptitReply>();
        List<UserReplyView> userReplyViews = new List<UserReplyView>();


        
        public IEnumerable<AptitResultUserView> GridData { get; set; }



        public ObservableCollection<AptitResultUserView> ObservableData { get; set; }
        
        public string SelectedGroupID { get; set; }
        public int? RowIndex { get; set; } = 1;

        public int AptitAnswerID { get; set; }

        public int AptitUserID { get; set; }

        public void AddRecord()
        {
        }
        public void UpdateRecord()
        {
            if (ObservableData.Count() != 0)
            {
                var name = ObservableData.First();
                name.User_Name = "Record Updated";
            }
        }

        public void DeleteRecord()
        {
            if (ObservableData.Count() != 0)
            {
                ObservableData.Remove(ObservableData.First());
            }
        }

        protected override async Task OnInitializedAsync()
        {

            InstituteListResult = await OctRepository.GetInstituteList();
            //ObservableData = new ObservableCollection<AptitUser>(aptitUsers);
        }
        public async void RowSelecthandler(RowSelectEventArgs<InstituteListView> Args)
        {
            //SelectedGroupID = Args.Data.Group_ID;
            
            //Users = await AptitRepository.GetGroupByID(SelectedGroupID);
            //GridData = this.Users;

            //ObservableData = new ObservableCollection<AptitResultUserView>(Users);
            
            //
        }

        private string documentPath;
        private bool isShowPdfViewer;
        private string DocumentPath { get; set; }

        private async Task OnShowWorkOrder()
        {

               
        }


        public async Task CommandClickHandler(CommandClickEventArgs<InstituteListView> args)
        {
            //NavigationManager.NavigateTo($"/AptitManage/ResultDetail/{args.RowData.ID}/{args.RowData.AptitAnswerID}");

            if (args.CommandColumn.ButtonOption.Content.Equals("Excel결과"))
            {
                var anp_seq = args.RowData.anp_seq;

                var instituteListResult = await OctRepository.GetInstituteList();
                //회원정보
                var personInformation = await OctRepository.GetPersonInformation(anp_seq);
                //성향진단
                var personalityDiagnosis = await OctRepository.GetPersonalityDiagnosis(anp_seq);
                //성향분선
                var questions = await OctRepository.GetQuestions(anp_seq);
                var questionExplains = await OctRepository.GetQuestionExplains(anp_seq);
                var scoreExplanations = await OctRepository.GetScoreExplanations(anp_seq);
                var tendencyAndJobDescription = await OctRepository.GetTendencyAndJobDescription(anp_seq);
                var recommendedJobs = await OctRepository.GetRecommendedJobs(anp_seq);
                var jobsWithMajor = await OctRepository.GetJobsWithMajor(anp_seq);
                var talents = await OctRepository.GetTalents(anp_seq);
                var talentScores = await OctRepository.GetTalentScores(anp_seq);
                var jobTalents = await OctRepository.GetJobTalents(anp_seq);
                var jobMajorList = await OctRepository.GetJobMajorList(anp_seq);
                var tendencyStudy = await OctRepository.GetTendencyStudy(anp_seq);
                var studyWayRecommendations = await OctRepository.GetStudyWayRecommendations(anp_seq);
                var optimalStudyInvestmentRecommendations = await OctRepository.GetOptimalStudyInvestmentRecommendations(anp_seq);
                var optimalStudyGuidanceRecommendations = await OctRepository.GetOptimalStudyGuidanceRecommendations(anp_seq);
                var optimalStudyGuidanceRecommendations2 = await OctRepository.GetOptimalStudyGuidanceRecommendations2(anp_seq);
                var tendencySubjectRankings = await OctRepository.GetTendencySubjectRankings(anp_seq);
                //var strongTendencySubjectList = await OctRepository.GetStrongTendencySubjectList(anp_seq);
                var recommendedDutyList = await OctRepository.GetRecommendedDutyList(anp_seq);
                var preferences = await OctRepository.GetPreferences(anp_seq);
                var jobs = await OctRepository.GetJobs(anp_seq);
                var jobs2 = await OctRepository.GetJobs2(anp_seq, "");
                var jobsRimg3 = await OctRepository.GetJobsRimg3(anp_seq);

                using (var package = new ExcelPackage())
                {
                    var consolidatedSheet = package.Workbook.Worksheets.Add("Consolidated Data");

                    consolidatedSheet.Cells["A1"].Value = "회원정보";
                    var sheet1StartRow = 2;
                    PopulateSheet1(consolidatedSheet, personInformation, sheet1StartRow);

                    // Add Sheet2 data with title
                    var sheet2StartRow = sheet1StartRow + 3; // Add a gap between sections
                    consolidatedSheet.Cells[sheet2StartRow, 1].Value = "성향진단";
                    PopulateSheetDiagnosis(consolidatedSheet, personalityDiagnosis, sheet2StartRow + 1);

                    // Add Sheet3 data with title
                    var sheet3StartRow = sheet2StartRow + 4; // Add a gap between sections
                    consolidatedSheet.Cells[sheet3StartRow, 1].Value = "성향분석";
                    PopulateSheet2(consolidatedSheet, questions, sheet3StartRow + 1);

                    var sheet5StartRow = sheet3StartRow + 8; // Add a gap between sections
                    consolidatedSheet.Cells[sheet5StartRow, 1].Value = "사고력";
                    PopulateSheet4(consolidatedSheet, scoreExplanations, sheet5StartRow + 1);

                    var sheet6StartRow = sheet5StartRow + 12; // Add a gap between sections
                    consolidatedSheet.Cells[sheet6StartRow, 1].Value = "1.성향적합직업학과";
                    PopulateSheet5(consolidatedSheet, tendencyAndJobDescription, sheet6StartRow + 1);

                    var sheet7StartRow = sheet6StartRow + 5; // Add a gap between sections
                    consolidatedSheet.Cells[sheet7StartRow, 1].Value = "2.성향적합직업학과";
                    PopulateSheet6(consolidatedSheet, recommendedJobs, sheet7StartRow + 1);

                    var sheet8StartRow = sheet7StartRow + 10; // Add a gap between sections
                    consolidatedSheet.Cells[sheet8StartRow, 1].Value = "3.성향적합직업학과";
                    PopulateSheetJobsWithMajo(consolidatedSheet, jobsWithMajor, sheet8StartRow + 1);

                    var sheet9StartRow = sheet8StartRow + 10; // Add a gap between sections
                    consolidatedSheet.Cells[sheet9StartRow, 1].Value = "1.역량진단";
                    PopulateSheet8(consolidatedSheet, talentScores, sheet9StartRow + 1);

                    var sheet10StartRow = sheet9StartRow + 10; // Add a gap between sections
                    consolidatedSheet.Cells[sheet10StartRow, 1].Value = "2.역량적합직업";
                    PopulateSheet9(consolidatedSheet, jobTalents, sheet10StartRow + 1);


                    var sheet11StartRow = sheet10StartRow + 10; // Add a gap between sections
                    consolidatedSheet.Cells[sheet11StartRow, 1].Value = "3.역량적합직업학과";
                    PopulateSheet10(consolidatedSheet, jobMajorList, sheet11StartRow + 1);


                    var sheet12StartRow = sheet11StartRow + 10; // Add a gap between sections
                    consolidatedSheet.Cells[sheet12StartRow, 1].Value = "직무";
                    PopulateSheetRecommendedDutyList(consolidatedSheet, recommendedDutyList, sheet12StartRow + 1);

                    var sheet13StartRow = sheet12StartRow + 10; // Add a gap between sections
                    consolidatedSheet.Cells[sheet13StartRow, 1].Value = "선호도";
                    PopulateSheet16(consolidatedSheet, preferences, sheet13StartRow + 1);

                    // Add Sheet1
                    //var sheet1 = package.Workbook.Worksheets.Add("회원정보");
                    //PopulateSheet1(sheet1, personInformation);
                    //// Populate Sheet1 with data from instituteListResult
                    //var sheet2 = package.Workbook.Worksheets.Add("성향진단");
                    //PopulateSheetDiagnosis(sheet2, personalityDiagnosis);
                    //// Add Sheet2
                    //var sheet3 = package.Workbook.Worksheets.Add("성향분석");
                    //PopulateSheet2(sheet3, questions);

                    //var sheet3 = package.Workbook.Worksheets.Add("사고력");
                    //PopulateSheet3(sheet3, questionExplains);
                    //var sheet4 = package.Workbook.Worksheets.Add("1.성향적합직업학과");
                    //PopulateSheet4(sheet4, scoreExplanations);
                    //var sheet5 = package.Workbook.Worksheets.Add("2.성향적합직업학과");
                    //PopulateSheet5(sheet5, tendencyAndJobDescription);
                    //var sheet6 = package.Workbook.Worksheets.Add("3.성향적합직업학과");
                    //PopulateSheet6(sheet6, recommendedJobs);
                    //var sheet7 = package.Workbook.Worksheets.Add("1.역량진단");
                    //PopulateSheet7(sheet7, talents);
                    //var sheet8 = package.Workbook.Worksheets.Add("2.역량진단");
                    //PopulateSheet8(sheet8, talentScores);
                    //var sheet9 = package.Workbook.Worksheets.Add("3.역량적합직업");
                    //PopulateSheet9(sheet9, jobTalents);
                    //var sheet10 = package.Workbook.Worksheets.Add("4.역량적합직업학과");
                    //PopulateSheet10(sheet10, jobMajorList);
                    //var sheet11 = package.Workbook.Worksheets.Add("학습");
                    //PopulateSheet11(sheet11, tendencyStudy);

                    // Save the Excel package to a stream
                    var stream = new MemoryStream();
                    package.SaveAs(stream);

                    // Set the position of the stream back to the beginning
                    stream.Position = 0;

                    // Trigger the download of the Excel file with the specified sheet name
                    var sheetName = "Sheet1"; // You can dynamically set this based on user choice
                    var fileName = $"{personInformation.School}_{personInformation.PName}.xlsx";
                    await JS.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(stream.ToArray()));
                }
            }
        }

        private void PopulateSheet1<T>(ExcelWorksheet sheet, T data, int startRow)
        {
            // Example: Populate the sheet with data of generic type T
            // You need to adjust this based on the actual structure of your data
            // For simplicity, assuming data is an object with properties
            var properties = typeof(T).GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                var propertyValue = properties[i].GetValue(data, null);
                sheet.Cells[startRow, i + 1].Value = propertyValue != null ? propertyValue.ToString() : null;
            }
        }
        private void PopulateSheetDiagnosis(ExcelWorksheet sheet, PersonalityDiagnosis data, int startRow)
        {
            if (data != null)
            {
                sheet.Cells[startRow, 1].Value = data.Tnd1;
                sheet.Cells[startRow, 2].Value = data.Tnd2;
                sheet.Cells[startRow, 3].Value = data.Tnd3;
            }
        }

        private void PopulateSheet2(ExcelWorksheet sheet, List<QuestionInfo> data, int startRow)
        {
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[startRow + i, 1].Value = data[i].QuaName;
                    sheet.Cells[startRow + i, 2].Value = data[i].QuestionExplanation;
                }
            }
        }
        private void PopulateSheet4(ExcelWorksheet sheet, List<ScoreExplanation> data, int startRow)
        {
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[startRow + i, 1].Value = data[i].QuaName;
                    sheet.Cells[startRow + i, 2].Value = data[i].Score;
                    sheet.Cells[startRow + i, 3].Value = data[i].Explain;
                }
            }
        }
        private void PopulateSheet5(ExcelWorksheet sheet, TendencyModel data, int startRow)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null)
            {
                sheet.Cells[startRow, 1].Value = data.Tendency;
                sheet.Cells[startRow, 2].Value = data.TndJob;
            }
        }
        private void PopulateSheet6(ExcelWorksheet sheet, List<RecommendedJobModel> data, int startRow)
        {
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[startRow + i, 1].Value = data[i].JobName;
                    sheet.Cells[startRow + i, 2].Value = data[i].JobOutline;
                    sheet.Cells[startRow + i, 3].Value = data[i].JobMainBusiness;
                }
            }
        }
        private void PopulateSheetJobsWithMajo(ExcelWorksheet sheet, List<JobWithMajorModel> data, int startRow)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[startRow + i, 1].Value = data[i].JobName;
                    sheet.Cells[startRow + i, 2].Value = data[i].Major;
                }
            }
        }
        private void PopulateSheet8(ExcelWorksheet sheet, List<TalentScoreModel> data, int startRow)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[startRow + i, 1].Value = data[i].TalentName;
                    sheet.Cells[startRow + i, 2].Value = data[i].TalentScore;
                    sheet.Cells[startRow + i, 3].Value = data[i].Explanation;
                }
            }
        }
        private void PopulateSheet9(ExcelWorksheet sheet, List<TalentJobModel> data, int startRow)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[startRow + i, 1].Value = data[i].TalentName;
                    sheet.Cells[startRow + i, 2].Value = data[i].TalentOutline;
                    sheet.Cells[startRow + i, 3].Value = data[i].MainBusiness;
                }
            }
        }
        private void PopulateSheet10(ExcelWorksheet sheet, List<JobMajorModel> data, int startRow)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[startRow + i, 1].Value = data[i].JobName;
                    sheet.Cells[startRow + i, 2].Value = data[i].Majors;
                }
            }
        }

        private void PopulateSheetRecommendedDutyList(ExcelWorksheet sheet, List<RecommendedDutyModel> data, int startRow)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[startRow + i, 1].Value = data[i].DutyName;
                    sheet.Cells[startRow + i, 2].Value = data[i].DutyOutline;
                    sheet.Cells[startRow + i, 3].Value = data[i].DutyDepartment;
                }
            }
        }
        private void PopulateSheet16(ExcelWorksheet sheet, PreferenceModel data, int startRow)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null)
            {
                sheet.Cells[startRow, 1].Value = data.Name1;
                sheet.Cells[startRow, 2].Value = data.QCount1;
                sheet.Cells[startRow, 3].Value = data.Rate1;
                sheet.Cells[startRow, 4].Value = data.Name2;
                sheet.Cells[startRow, 5].Value = data.QCount2;
                sheet.Cells[startRow, 6].Value = data.Rate2;
                sheet.Cells[startRow, 7].Value = data.Name3;
                sheet.Cells[startRow, 8].Value = data.QCount3;
                sheet.Cells[startRow, 9].Value = data.Rate3;
                sheet.Cells[startRow, 10].Value = data.Explanation1;
                sheet.Cells[startRow, 11].Value = data.Explanation2;
                sheet.Cells[startRow, 12].Value = data.Explanation3;
            }
        }





        private void PopulateSheet7(ExcelWorksheet sheet, TalentModel data, int startRow)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null)
            {
                sheet.Cells[startRow, 1].Value = data.Talents;
            }
        }




        private void PopulateSheet(ExcelWorksheet sheet, PersonInformation data)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null)
            {
                sheet.Cells["A1"].Value = data.Id;
                sheet.Cells["B1"].Value = data.PName;
                sheet.Cells["C1"].Value = data.Birthdate;
                sheet.Cells["D1"].Value = data.Sex;
                sheet.Cells["E1"].Value = data.Cellphone;
                sheet.Cells["F1"].Value = data.Contact;
                sheet.Cells["G1"].Value = data.Email;
                sheet.Cells["H1"].Value = data.Education;
                sheet.Cells["I1"].Value = data.School;
                sheet.Cells["J1"].Value = data.SchoolYear;
                sheet.Cells["K1"].Value = data.SchoolMajor;
                sheet.Cells["L1"].Value = data.Job;
                sheet.Cells["M1"].Value = data.Age;
                sheet.Cells["N1"].Value = data.JobName;
                sheet.Cells["O1"].Value = data.JobDetail;
            }
        }

        private void PopulateSheetDiagnosis(ExcelWorksheet sheet, PersonalityDiagnosis data)
        {
            if (data != null )
            {
                sheet.Cells["A1"].Value = data.Tnd1;
                sheet.Cells["B1"].Value = data.Tnd2;
                sheet.Cells["C1"].Value = data.Tnd3;
            }
        }

        private void PopulateSheet2(ExcelWorksheet sheet, List<QuestionInfo> data)
        {
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[i + 1, 1].Value = data[i].QuaName;
                    sheet.Cells[i + 1, 2].Value = data[i].QuestionExplanation;
                }
            }
        }

        private void PopulateSheet3(ExcelWorksheet sheet, List<QuestionExplanation> data)
        {
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[i + 1, 1].Value = data[i].QuExplain;
                }
            }
        }
        
     
        
        
    
        
        private void PopulateSheet11(ExcelWorksheet sheet, TendencyStudyModel data)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null)
            {
                sheet.Cells["A1"].Value = data.Tendency1;
                sheet.Cells["B1"].Value = data.Tendency1Study;
                sheet.Cells["C1"].Value = data.Tendency1Way;
                sheet.Cells["D1"].Value = data.Tendency2;
                sheet.Cells["E1"].Value = data.Tendency2Study;
                sheet.Cells["F1"].Value = data.Tendency2Way;
                sheet.Cells["G1"].Value = data.Tendency1Row;
                sheet.Cells["H1"].Value = data.Tendency2Col;
            }
        }
        private void PopulateSheet12(ExcelWorksheet sheet, List<StudyWayModel> data)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[i + 1, 1].Value = data[i].StudyName;
                    sheet.Cells[i + 1, 1].Value = data[i].StudyRate;
                    sheet.Cells[i + 1, 1].Value = data[i].StudyColor;
                }
            }
        }
        private void PopulateSheet13(ExcelWorksheet sheet, List<TendencySubjectModel> data)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[i + 1, 1].Value = data[i].SubjectRank;
                    sheet.Cells[i + 1, 1].Value = data[i].SubjectGroup;
                    sheet.Cells[i + 1, 1].Value = data[i].SubjectChoice;
                    sheet.Cells[i + 1, 1].Value = data[i].Subject;
                    sheet.Cells[i + 1, 1].Value = data[i].SubjectExplain;
                    sheet.Cells[i + 1, 1].Value = data[i].Tendency1;
                    sheet.Cells[i + 1, 1].Value = data[i].SubjectRank2;
                }
            }
        }
        private void PopulateSheet14(ExcelWorksheet sheet, List<StrongTendencySubjectModel> data)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[i + 1, 1].Value = data[i].SubjectRank;
                    sheet.Cells[i + 1, 1].Value = data[i].SubjectGroup;
                    sheet.Cells[i + 1, 1].Value = data[i].SubjectChoice;
                    sheet.Cells[i + 1, 1].Value = data[i].Subject;
                    sheet.Cells[i + 1, 1].Value = data[i].SubjectExplain;
                    sheet.Cells[i + 1, 1].Value = data[i].Tendency1;
                }
            }
        }
        private void PopulateSheet15(ExcelWorksheet sheet, List<RecommendedDutyModel> data)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[i + 1, 1].Value = data[i].DutyName;
                    sheet.Cells[i + 1, 1].Value = data[i].DutyOutline;
                    sheet.Cells[i + 1, 1].Value = data[i].DutyDepartment;
                }
            }
        }
        
        private void PopulateSheet16(ExcelWorksheet sheet, List<JobModel> data)
        {
            // Example: Populate the sheet with data from PersonInformation
            // You need to adjust this based on the actual structure of your data
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[i + 1, 1].Value = data[i].QualificationName;
                    sheet.Cells[i + 1, 1].Value = data[i].JobName;
                    sheet.Cells[i + 1, 1].Value = data[i].JobOutline;
                    sheet.Cells[i + 1, 1].Value = data[i].MainBusiness;
                    sheet.Cells[i + 1, 1].Value = data[i].MajorNames;
                }
            }
        }

        private void PopulateSheet(ExcelWorksheet sheet, List<PersonInformation> data)
        {
            // Example: Populate the sheet with data from YourDataType
            // You need to adjust this based on the actual structure of your data
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[i + 1, 1].Value = data[i].Id;
                    sheet.Cells[i + 1, 2].Value = data[i].PName;
                    // Repeat for other properties as needed
                }
            }
        }
        private void PopulateSheet1<T>(ExcelWorksheet sheet, T data)
        {
            // Example: Populate the sheet with data of generic type T
            // You need to adjust this based on the actual structure of your data
            // For simplicity, assuming data is an object with properties
            var properties = typeof(T).GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                var propertyValue = properties[i].GetValue(data, null);
                sheet.Cells[1, i + 1].Value = propertyValue != null ? propertyValue.ToString() : null;
            }
        }
        private void AddSheet<T>(ExcelPackage package, string sheetName, IEnumerable<T> data)
        {
            var sheet = package.Workbook.Worksheets.Add(sheetName);
            sheet.Cells.LoadFromCollection(data, true);
        }

        // Your existing repository and data retrieval methods...
        // Make sure to replace these with your actual implementation

       


        public void SubRowSelecthandler(RowSelectEventArgs<InstituteListView> Args)
        {
           //int  SelValue = Args.Data.AptitAnswerID;
        }

       

        public async void GeneratePDF(MouseEventArgs args)
        {	   
            //RearrangePagesService service = new RearrangePagesService(hostingEnvironment, );
            //MemoryStream documentStream = service.CreatePdfDocument();
            //await JS.SaveAs("Helloworld.pdf", documentStream.ToArray());        
        }
            
       
       
    }
         
}
