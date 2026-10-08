using ParlikeWebApi.Models;

namespace ParlikeWebApi.Repositories.Repository;
public class UserRepository (SqlContext sqlContext): BaseRepository<User>(sqlContext), IUserRepository
{
   
}