using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ParlikeWebApi.Models
{
    public class Episode
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public required string Title { get; set; }
        [MaxLength(250)]
        public required string VideoLink { get; set; }
        public required TimeOnly PriodTime { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public ICollection<Episode> Children { get; set; } = new List<Episode>();
        //FK:Selef-Refrence
        public int? ParentId { get; set; }
        public Episode? Parent { get; set; }
        //fk
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        

    }
}