using System.ComponentModel.DataAnnotations;
namespace MY_Website.Models
{
    public class LoginUserViewModel
    {
        //Login
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        [Display(Name = "Username")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool IsRemember { get; set; }
    }
}
