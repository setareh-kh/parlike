using ParlikeWebApi.Models;

namespace ParlikeWebApi.Repositories.Repository;
public class EpisodeRepository(SqlContext sqlContext): BaseRepository<Episode>(sqlContext)
{
   
}