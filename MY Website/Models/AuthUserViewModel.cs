using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MY_Website.Models
{
    public class AuthUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Name")]
        [Display(Name ="Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        [Display(Name ="Email Address")]
        [Remote(action: "IsEmailExit",controller:"Users")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name ="Enter Password")]
        public string Password { get; set;}

        [Required(ErrorMessage = "Please Enter Password")]
        [Compare("Password",ErrorMessage ="Password Doesnot Match")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Active")]
        public bool IsActive { get; set; }

    }
}
