using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.IsisMtt.X509;

namespace ParlikeWebApi.Models
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }
        public DbSet<Catogory> Catogories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCatogory> CourseCatogories { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //catogory <1-n> catogory 
            modelBuilder.Entity<Catogory>()
                        .HasOne(c => c.Parent)
                        .WithMany(c => c.Children)
                        .HasForeignKey(c => c.ParentId)
                        .OnDelete(DeleteBehavior.Restrict);
            //catogory <n-n> course: catogory <1-n> CourseCatogory <n-1> course
            //catogory <1-n> CourseCatogory
            modelBuilder.Entity<Catogory>()
                        .HasMany(c => c.CourseCatogories)
                        .WithOne(cc => cc.Catogory)
                        .HasForeignKey(cc => cc.CatogoryId)
                        .OnDelete(DeleteBehavior.Restrict);
            //CourseCatogory <n-1> course
            modelBuilder.Entity<CourseCatogory>()
                        .HasOne(cc => cc.Course)
                        .WithMany(c => c.CourseCatogories)
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
            //set composit key for CourseCatogory table
            modelBuilder.Entity<CourseCatogory>()
                        .HasKey(cc=> new {cc.CatogoryId , cc.CourseId});
            //set composit key for CourseCatogory table
            modelBuilder.Entity<TeacherCourse>()
                        .HasKey(tc=> new {tc.CourseId , tc.TeacherId});
        }
    }
}