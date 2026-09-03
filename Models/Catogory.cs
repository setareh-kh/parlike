using System.ComponentModel.DataAnnotations;

namespace ParlikeWebApi.Models
{
    public class Catogory
    {
        public int Id {get; set;}
        [MaxLength(250)]
        public required string Name {get; set;}
        public required DateTime CreatedAt {get; set;}
        public ICollection<CourseCatogory>? CourseCatogories {get; set;}
        public ICollection<Catogory>? Children {get; set;}=new List<Catogory>();
        //FK:Selef-Refrence
        public int? ParentId {get; set;}
        public Catogory? Parent {get; set;}
        
    }
}