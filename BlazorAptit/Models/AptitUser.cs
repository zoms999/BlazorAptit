using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Models
{
    public class AptitGroup
    {
        //[Key]
        //public int ID { get; set; }
        [MaxLength(40)]
        [Key]
        public string Group_ID { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "* 단체명을 입력해 주세요.")]
        public string Group_Name { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "* 지역을 입력해 주세요.")]
        public string Group_City { get; set; }

        [MaxLength(20)]
        public string CheckType { get; set; }

        [MaxLength(4)]
        [Required(ErrorMessage = "* 패스워드를 입력해 주세요.")]
        public string Password { get; set; }

        //신청인원
        public int RegCount { get; set; }

         //완료인원
        public int CompletCount { get; set; }

        public int PaymentCount { get; set; }

         [MaxLength(30)]
        public string Manage_Name { get; set; }

        [MaxLength(30)]
        public string Manage_Tel1 { get; set; }

         [MaxLength(30)]
        public string Manage_Tel2 { get; set; }
        public int Payment { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? Created { get; set; }
       
        //public string AptitUserID { get; set; }
        //public AptitUser aptitUser { get; set;}
        public ICollection<AptitUser> AptitUsers { get; set; }

        // 입금완료여부
        public string PaymentComplet { get; set; }
        public DateTime? PaymentDate{ get; set; }
        


    }
      
    public class AptitUser
    {
        [Key]
        public int ID { get; set; }

         [MaxLength(50)]
        [Required(ErrorMessage = "* 이메일을 입력해 주세요.")]
        public string User_Email { get; set; }

       
        [MaxLength(40)]
        [ForeignKey("Group")]
        public string Group_ID { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "* 지역을 입력해 주세요.")]
        public string Group_City { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "* 기관(학교)명을 입력해 주세요.")]
        public string Group_Name { get; set; }

        [MaxLength(4)]
        [Required(ErrorMessage = "* 패스워드를 입력해 주세요.")]
        public string User_Password { get; set; }

        [MaxLength(4)]
        [Required(ErrorMessage = "* 패스워드를 확인해 주세요.")]
        [Compare("User_Password", ErrorMessage = "패스워드가 일치하지 않습니다.")]
        public string User_Password2 { get; set; }


        [MaxLength(30)]
        [Required(ErrorMessage = "* 이름을 입력해 주세요.")]
        public string User_Name { get; set; }

         [MaxLength(10)]
        [Required(ErrorMessage = "* 나이를 입력해 주세요.")]
        public string User_Age { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "* 성별를 선택해 주세요.")]
        public  string? User_Gender { get; set; }

        [MaxLength(20)]
        public string User_Grade { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "* 전공을 선택해 주세요.")]
        public string User_Edu { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "* 직업을 선택해 주세요.")]
        public string User_Job { get; set; }

        [Range(1, 20,  ErrorMessage = "숫자만 입력해 주세요.")]
        [ValidLastDeliveryDate(ErrorMessage = "* (반)을 입력해 주세요.")]
        [MaxLength(20)]
        public string? User_Class { get; set; }

        [MaxLength(20)]
        //[Required(ErrorMessage = "* 전공를 입력해 주세요.")]
        public string? User_Finish { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "회원가입약관의 내용에 동의하셔야 회원가입 하실 수 있습니다.")]
        //[RegularExpression("True", ErrorMessage = "회원가입약관의 내용에 동의하셔야 회원가입 하실 수 있습니다.")]
        //[Compare("agree11", ErrorMessage = "회원가입약관의 내용에 동의하셔야 회원가입 하실 수 있습니다.")]

        [Display(Name = "Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "회원가입약관의 내용에 동의하셔야 검사를 시작하실 수 있습니다.")]
        public bool agree11 { get; set; }

        public DateTime? Created { get; set; }

        //public int AptitAnswerID { get; set; }
        public ICollection<AptitAnswer> AptitAnswers { get; set; }

        public AptitAnswer aptitAnswer { get; set;}
        public AptitUser()
        {
            AptitAnswers = new HashSet<AptitAnswer>();
        }

         public AptitGroup Group { get; set;}


    }

    public class AptitAnswer
    {
        [Key]
        public int AptitAnswerID { get; set; }
        [ForeignKey("AptitUserID")]
        public int AptitUserID { get; set; }
     
        public int AQ_1 { get; set; }
        public int AQ_2 { get; set; }
        public int AQ_3 { get; set; }
        public int AQ_4 { get; set; }
        public int AQ_5 { get; set; }
        public int AQ_6 { get; set; }
        public int AQ_7 { get; set; }
        public int AQ_8 { get; set; }
        public int AQ_9 { get; set; }
        public int AQ_10 { get; set; }
        public int AQ_11 { get; set; }
        public int AQ_12 { get; set; }
        public int AQ_13 { get; set; }
        public int AQ_14 { get; set; }
        public int AQ_15 { get; set; }
        public int AQ_16 { get; set; }
        public int AQ_17 { get; set; }
        public int AQ_18 { get; set; }
        public int AQ_19 { get; set; }
        public int AQ_20 { get; set; }

      
        public int Stage { get; set; }
        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public AptitUser AptitUsers { get; set; }



    }




    public class AptitUserQue
    {
        [Key]
        public int AptitUserID { get; set; }

        [Key ]
        public int AptitQuestionID { get; set; }

        public int AQ_1 { get; set; }
        public int AQ_2 { get; set; }
        public int AQ_3 { get; set; }
        public int AQ_4 { get; set; }
        public int AQ_5 { get; set; }
        public int AQ_6 { get; set; }
        public int AQ_7 { get; set; }
        public int AQ_8 { get; set; }
        public int AQ_9 { get; set; }
        public int AQ_10 { get; set; }
        public int AQ_11 { get; set; }
        public int AQ_12 { get; set; }
        public int AQ_13 { get; set; }
        public int AQ_14 { get; set; }
        public int AQ_15 { get; set; }
        public int AQ_16 { get; set; }
        public int AQ_17 { get; set; }
        public int AQ_18 { get; set; }
        public int AQ_19 { get; set; }
        public int AQ_20 { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public int Stage_Score { get; set; }

        public int Rank { get; set; }

        public AptitUser AptitUsers { get; set; }

    }

    public class AptitQuestion
    {
        public int ID { get; set; }

        public string  QuestionType  { get; set; }
        public string QUE_1 { get; set; }
        public string QUE_2 { get; set; }
        public string QUE_3 { get; set; }
        public string QUE_4 { get; set; }
        public string QUE_5 { get; set; }
        public string QUE_6 { get; set; }
        public string QUE_7 { get; set; }
        public string QUE_8 { get; set; }
        public string QUE_9 { get; set; }
        public string QUE_10 { get; set; }
        public string QUE_11 { get; set; }
        public string QUE_12 { get; set; }
        public string QUE_13 { get; set; }
        public string QUE_14 { get; set; }
        public string QUE_15 { get; set; }
        public string QUE_16 { get; set; }
        public string QUE_17 { get; set; }
        public string QUE_18 { get; set; }
        public string QUE_19 { get; set; }
        public string QUE_20 { get; set; }

        public List<QuizItem> quiz = new List<QuizItem> {
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 그렇다", "그렇다", "약간 그렇다", "별로 그렇지 않다", "아니다", "전혀 아니다" },
                    AnswerIndex = 1,
                    Score = 3
                },
            
        };
       

    }


    public class AptitResult
    {
        public int AptitResultID { get; set; }

        public int Point { get; set;}
        public string TITLE { get; set; }
        public string CONTENT_MAIN { get; set; }
        public string CONTENT_1 { get; set; }
        public string CONTENT_1_1 { get; set; }
        public string CONTENT_2 { get; set; }
        public string CONTENT_2_1 { get; set; }
        public string CONTENT_3 { get; set; }
        public string CONTENT_3_1 { get; set; }
        public string CONTENT_4 { get; set; }
        public string CONTENT_4_1 { get; set; }
        public string CONTENT_5 { get; set; }
        public string CONTENT_5_1 { get; set; }
        public string CONTENT_6 { get; set; }
        public string CONTENT_6_1 { get; set; }

 //   [AptitResultID] [int] NOT NULL,
	//[TITLE] NVARCHAR (20),
	//CONTENT_MAIN NVARCHAR (MAX),
	//CONTENT_1 NVARCHAR (100),
	//CONTENT_1_1 NVARCHAR (300),
	//CONTENT_2 NVARCHAR (100),
	//CONTENT_2_1 NVARCHAR (300),
	//CONTENT_3 NVARCHAR (100),
	//CONTENT_3_1 NVARCHAR (300),
	//CONTENT_4 NVARCHAR (100),
	//CONTENT_4_1 NVARCHAR (300),
	//CONTENT_5 NVARCHAR (100),
	//CONTENT_5_1 NVARCHAR (300),
	//CONTENT_6 NVARCHAR (100),
	//CONTENT_6_1 NVARCHAR (300),
    }
    public class Order
    {
        public int ID { get; set; }
        public string COL_NM { get; set; }
        public string VAL { get; set; }

        //[Required]
        //[FileValidation(new[] { ".png", ".jpg" })]
        //public IBrowserFile Picture { get; set; }
    }


    public class ResultContent
    {
        public int ID { get; set; }

        public int ROW { get; set; }
        public string COL_NM { get; set; }
        public string VAL { get; set; }

    }
    public class FileValidationAttribute : ValidationAttribute
    {
        public FileValidationAttribute(string[] allowedExtensions)
        {
            AllowedExtensions = allowedExtensions;
        }
        private string[] AllowedExtensions { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = (IBrowserFile)value;

            var extension = System.IO.Path.GetExtension(file.Name);

            if (!AllowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
            {
                return new ValidationResult($"File must have one of the following extensions: {string.Join(", ", AllowedExtensions)}.", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }

    }

    public class ValidLastDeliveryDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (Models.AptitUser)validationContext.ObjectInstance;

            if (model.User_Job == "A" || model.User_Job == "B" || model.User_Job == "C")
            {
                 if(model.User_Class == null || model.User_Class == "")
                    return new ValidationResult ("(반)을 입력해 주세요.");
                 else
                    return ValidationResult.Success;
            }
            
            else
            {
                return ValidationResult.Success;
            }
        }
    }



}
