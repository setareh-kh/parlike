using System.ComponentModel.DataAnnotations;

namespace ParlikeWebApi.Models
{
    public enum UserType
    {
        Admin,
        Student
    }
    public class User
    {
        public int Id { get; set; }
        [ MaxLength(250)]
        public string? Name { get; set; }
        [MaxLength(250)]
        public  string? Family { get; set; }
        [Required, MaxLength(250)]
        public required string Mobile { get; set; }
        [MaxLength(250)] 
        public string VerifyCode { get; set; } = null!;
        public DateTime ExpiresCode { get; set; }
        public DateTime UpdatedCode { get; set; }
        public required UserType Type { get; set; }
        [Required]
        public required DateTime CreateAt { get; set; }
        public ICollection<Subscribe>? Subscribes { get; set; }

    }
}
