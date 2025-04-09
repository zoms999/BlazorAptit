using Syncfusion.Blazor.PdfViewerServer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BlazorAptit.Models
{
  
    public class AptitResultUserView
    {
        public int ID { get; set; }

        public string User_Email { get; set; }

        public string Group_ID { get; set; }

        public string Group_City { get; set; }

    
        public string Group_Name { get; set; }

        public string User_Password { get; set; }

        public string User_Password2 { get; set; }


        public string User_Name { get; set; }

        public string User_Age { get; set; }

        public string? User_Gender { get; set; }

        public string User_Grade { get; set; }

        public string User_Edu { get; set; }

        public string User_Job { get; set; }

        public string? User_Class { get; set; }

        public string? User_Finish { get; set; }

       
        public DateTime? Created { get; set; }

        public string Stage { get; set; }

        public string USERRANKS { get; set; }

    }

}
