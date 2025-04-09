using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Models
{
    public class AptitRankView
    {
        public int AptitUserID { get; set; }

        public int AptitReplyID { get; set; }

        public int? Point { get; set; }
         public int? Cnt { get; set; }

         public string USER_NAME { get; set; }

         public string TITLE { get; set; }
    }
}
