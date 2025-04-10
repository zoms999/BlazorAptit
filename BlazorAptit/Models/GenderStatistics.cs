using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Models
{
    public class GenderGroupStatistics
    {
        public string Group_Name { get; set; }
        public string User_Gender { get; set; }
        public int Rank_In_Gender { get; set; }
        public string Primary_Aptitude_Type { get; set; }
        public decimal Pct_In_Gender { get; set; }
        public decimal Pct_In_Overall_Group { get; set; }
        public int Aptitude_Count_In_Gender { get; set; }
        public int Total_Users_In_Gender { get; set; }
        public int Total_Users_In_Overall_Group { get; set; }
    }
} 