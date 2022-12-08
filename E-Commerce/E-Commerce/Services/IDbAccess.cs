using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    public interface IDbAccess<TEntity,in TPK> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
         Task<TEntity> GetByIdAsync(TPK id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPK id, TEntity entity);
        Task<bool> DeleteAsync(TPK id);

    }
}
