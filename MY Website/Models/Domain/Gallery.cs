using System.ComponentModel.DataAnnotations;

namespace MY_Website.Models.Domain
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        
        public string ImagePath { get; set; }
    }
}
