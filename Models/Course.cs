using System.ComponentModel.DataAnnotations;

namespace ParlikeWebApi.Models
{
    public class Course:ISqlEntity
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public required string Name { get; set; }
        [MaxLength(1000)]
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public ICollection<CourseCategory>? CourseCategories { get; set; }
        public ICollection<Episode>? Episodes { get; set; }
        public  ICollection<TeacherCourse> TeacherCourses { get; set; }=new List<TeacherCourse>();
        public ICollection<Subscribe>? Subscribes { get; set; }
        //Fk


    }
}