namespace Project_Dezert.Models
{
    public class Friends
    {
        public int Id { get; set; }
        public int yourID { get; set; }
        public int? UserId { get; set; }
        public Users User { get; set; }
        public string? Messager { get; set; }

    }
}
