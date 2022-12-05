using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project_Dezert.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Column("Login")]
        [Required(ErrorMessage = "Email id is required")]
        public string Login { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("Age")]
        public int Age { get; set; }
        [Column("PhoneNumber")]

        public string PhoneNumber { get; set; }
        [Column("Name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
        public string Name { get; set; }
        [Column("Sername")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
        public string Sername { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("Country")]
        public string Country { get; set; }
    }
}
