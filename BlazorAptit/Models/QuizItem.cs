using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Models
{
    public class QuizItem
    {
        public string Question { get; set; }
        public List<string> Choices { get; set; }
        public int AnswerIndex { get; set; }
        public int Score { get; set; }


        public QuizItem()
        {
            Choices = new List<string>();
        }

    }
}
