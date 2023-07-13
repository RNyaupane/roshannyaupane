using System.ComponentModel.DataAnnotations;

namespace MY_Website.Models.Domain
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

    }
}
