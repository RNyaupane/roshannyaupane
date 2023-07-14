using System.ComponentModel.DataAnnotations;

namespace MY_Website.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage ="Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Enter Message")]
        public string Message { get; set; }
    }
}
