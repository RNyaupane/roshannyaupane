using System.ComponentModel.DataAnnotations; 

namespace MY_Website.Models
{
    public class GalleryViewModal
    {

        [Required(ErrorMessage ="Please Select Image")]
        [Display(Name ="Choose Image")]
        public IFormFile Image{ get; set; }

    }
}
