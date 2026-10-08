using ParlikeWebApi.Models;

namespace ParlikeWebApi.Repositories.Repository;
public class TeacherRepository (SqlContext sqlContext): BaseRepository<Teacher>(sqlContext), ITeacherRepository
{
   
}