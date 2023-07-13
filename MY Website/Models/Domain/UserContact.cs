using System.ComponentModel.DataAnnotations;

namespace MY_Website.Models.Domain
{
    public class UserContact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
    }
}
