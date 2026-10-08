using System.ComponentModel.DataAnnotations;

namespace ParlikeWebApi.Models
{
    public class Category
    {
        public int Id {get; set;}
        [MaxLength(250)]
        public required string Name {get; set;}
        public required DateTime CreatedAt {get; set;}
        public ICollection<CourseCategory>? CourseCategories {get; set;}
        public ICollection<Category>? Children {get; set;}=new List<Category>();
        //FK:Selef-Refrence
        public int? ParentId {get; set;}
        public Category? Parent {get; set;}
        
    }
}