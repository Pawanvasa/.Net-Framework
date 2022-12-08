using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataAccess.DataAccess
{
    /// <summary>
    /// A Generic Interface 
    /// TEntity will always be a class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="inTPk"></typeparam>
    internal interface IDbAccess<TEntity, in TPk> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TPk id);
        TEntity Create(TEntity entity);
        TEntity Update(TPk id, TEntity entity);
        void Delete(TPk id);
    }
}
