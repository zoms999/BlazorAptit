using System.ComponentModel.DataAnnotations;

namespace BlazorAptit.Models
{
    public class AptitUserView
    {
        [Key]

        [Required(ErrorMessage = "* 이메일을 입력해 주세요.")]
        public string User_Email { get; set; }

        [MaxLength(6)]
        [Required(ErrorMessage = "* 패스워드를 입력해 주세요.")]
        public string User_Password { get; set; }
       

    }

    public class AptitGroupView
    {
        [Key]

        [Required(ErrorMessage = "* 아이디를 입력해 주세요.")]
        public string Group_ID { get; set; }


        [Required(ErrorMessage = "* 패스워드를 입력해 주세요.")]
        public string Password { get; set; }
       

    }

}
