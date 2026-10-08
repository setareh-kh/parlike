using Microsoft.EntityFrameworkCore.Query;
using ParlikeWebApi.Models;

namespace ParlikeWebApi.Repositories.Repository;
public class CourseRepository(SqlContext sqlContext): BaseRepository<Course>(sqlContext),ICourseRepository
{
   
}