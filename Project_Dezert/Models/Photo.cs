using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Project_Dezert.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        //public List<IFormFile> ImageFile { get; set; }
        //public List<IFormFile> VideoUpload { get; set; }
        public int? UserId { get; set; }
        public Users User { get; set; }
    }
}
