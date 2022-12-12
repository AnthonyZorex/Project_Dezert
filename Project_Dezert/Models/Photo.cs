using System.ComponentModel.DataAnnotations;

namespace Project_Dezert.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string Image { get; set; }
    }
}
