using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.IsisMtt.X509;

namespace ParlikeWebApi.Models
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //category <1-n> category 
            modelBuilder.Entity<Category>()
                        .HasOne(c => c.Parent)
                        .WithMany(c => c.Children)
                        .HasForeignKey(c => c.ParentId)
                        .OnDelete(DeleteBehavior.Restrict);
            //category <n-n> course: category <1-n> CourseCategory <n-1> course
            //category <1-n> CourseCategory
            modelBuilder.Entity<Category>()
                        .HasMany(c => c.CourseCategories)
                        .WithOne(cc => cc.Category)
                        .HasForeignKey(cc => cc.CategoryId)
                        .OnDelete(DeleteBehavior.Restrict);
            //CourseCategory <n-1> course
            modelBuilder.Entity<CourseCategory>()
                        .HasOne(cc => cc.Course)
                        .WithMany(c => c.CourseCategories)
                        .HasForeignKey(cc => cc.CourseId)
                        .OnDelete(DeleteBehavior.Restrict);
            //course <1-n> episode
            modelBuilder.Entity<Course>()
                        .HasMany(c => c.Episodes)
                        .WithOne(e=> e.Course)
                        .HasForeignKey(e=>e.CourseId)
                        .OnDelete(DeleteBehavior.Restrict);
            //course <n-n> teacher: course <1-n> teacherCourse <n-1> teacher
                    //course <1-n> teacherCourse
            modelBuilder.Entity<Course>()
                        .HasMany(c=>c.TeacherCourses)
                        .WithOne(tc=>tc.Course)
                        .HasForeignKey(tc=>tc.CourseId)
                        .OnDelete(DeleteBehavior.Restrict);
                    //teacherCourse <n-1> teacher
            modelBuilder.Entity<TeacherCourse>()
                        .HasOne(tc=>tc.Teacher)
                        .WithMany(t=>t.TeacherCourses)
                        .HasForeignKey(tc=>tc.TeacherId)
                        .OnDelete(DeleteBehavior.Restrict);
            //course <n-n> User: course <1-n> subscribe <n-1> user
                    //course <1-n> subscribe
            modelBuilder.Entity<Course>()
                        .HasMany(c=>c.Subscribes)
                        .WithOne(s=>s.Course)
                        .HasForeignKey(s=>s.CourseId)
                        .OnDelete(DeleteBehavior.Restrict);
                    //subscribe <n-1> user
            modelBuilder.Entity<Subscribe>()
                        .HasOne(s=>s.User)
                        .WithMany(u=>u.Subscribes)
                        .HasForeignKey(s=>s.UserId)
                        .OnDelete(DeleteBehavior.Restrict);
            //set composit key for CourseCategory table
            modelBuilder.Entity<CourseCategory>()
                        .HasKey(cc=> new {cc.CategoryId , cc.CourseId});
            //set composit key for CourseCategory table
            modelBuilder.Entity<TeacherCourse>()
                        .HasKey(tc=> new {tc.CourseId , tc.TeacherId});
            //set composit key for Subscribe table
            modelBuilder.Entity<Subscribe>()
                        .HasKey(s=> new {s.CourseId , s.UserId});
            
        }
    }
}