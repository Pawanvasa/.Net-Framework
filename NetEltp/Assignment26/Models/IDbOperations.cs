using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment26.Models
{
    public interface IDbOperations<TEntity, in TPk> where TEntity : Staff
    {
        Dictionary<int, Staff> GetAll();
        Staff Get(TPk id);
        void Create(TPk id,TEntity entity);
        void Update(TPk id, TEntity entity);
        void Delete(TPk id);
    }
}
