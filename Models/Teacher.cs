using System.ComponentModel.DataAnnotations;

namespace ParlikeWebApi.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public required string Name { get; set; }
        [MaxLength(250)]
        public required string Family { get; set; }
        [MaxLength(250)]
        public required string Email { get; set; }
        [MaxLength(250)]
        public required string Mobile { get; set; }
        [MaxLength(250)]
        public required string Title { get; set; }
        [MaxLength(250)]
        public required string SubTitle { get; set; }
        [MaxLength(1000)]
        public string? bio { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public ICollection <TeacherCourse> TeacherCourses { get; set; }=new List<TeacherCourse>();
    }
}