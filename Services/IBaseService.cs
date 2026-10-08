using System.Linq.Expressions;
using ParlikeWebApi.Dtos.Response;
using ParlikeWebApi.Models;

namespace ParlikeWebApi.Services;

public interface IBaseService<TEntity> where TEntity : class, ISqlEntity
{
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);

    Task<List<TEntity>> WhereAsync(
        Expression<Func<TEntity, bool>> predicate);
    
    static StandardResponse NotFound() =>
        new() { Success = false, Object = false, Message = "NotFound" };

    static StandardResponse Success(object obj) =>
        new() { Success = true, Object = obj };
    
    Task<bool> SaveChanges();
    Task<IEnumerable<TEntity>?> GetAll();
    Task<TEntity?> GetAsync(int id);
}