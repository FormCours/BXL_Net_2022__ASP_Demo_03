using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_03_Modele.DAL.Interfaces
{
    public interface IRepository<TKey, TEntity>
    {
        // Create
        TKey Insert(TEntity entity);

        // Read
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();

        // Update
        bool Update(TKey id, TEntity entity);

        // Delete
        bool Delete(TKey id);
    }
}
