using ParlikeWebApi.Models;

namespace ParlikeWebApi.Repositories.Repository;
public class CategoryRepository(SqlContext sqlContext):BaseRepository<Category>(sqlContext)
{
   
}