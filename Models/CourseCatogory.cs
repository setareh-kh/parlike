namespace ParlikeWebApi.Models
{
    public class CourseCatogory
    {
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int CatogoryId { get; set; }
        public Catogory? Catogory { get; set; }
    }
}