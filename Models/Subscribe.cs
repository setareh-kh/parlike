namespace ParlikeWebApi.Models
{
    public class Subscribe
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; }= null!;
        public decimal Price{ get; set; }
        public  DateTime CreatedAt { get; set; }
        public  DateTime? UpdatedAt { get; set; }
    }
}