using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Models
{
    public class QuestionUpdateModel
    {
        public string que_explain { get; set; }
        public string qua_code { get; set; }
        public int que_switch { get; set; }
    }
    public class QuestionUpdateDataModel
    {
        public string qu_explain { get; set; }
        public string qu_code { get; set; }

    }
    public class JobUpdateModel
    {
        public string jo_name { get; set; }
        public string jo_outline { get; set; }
        public string jo_use { get; set; }
        public string jo_mainbusiness { get; set; }
        public string jo_code { get; set; }
    }
    public class MajorionUpdateModel
    {
        public string ma_name { get; set; }
        public string ma_explain { get; set; }
        public string ma_use { get; set; }
        public string ma_code { get; set; }
    }
    public class DutyUpdateModel
    {
        public string du_name { get; set; }
        public string du_use { get; set; }
        public string du_outline { get; set; }
        public string du_department { get; set; }
        public string du_code { get; set; }
    }
}
