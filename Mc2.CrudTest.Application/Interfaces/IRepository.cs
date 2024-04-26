using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        Task<TKey> Create(TEntity model);
        Task<TKey> Update(TEntity model);
        Task Delete(TEntity model);
        Task<TEntity> GetById(TKey id);
    }
}
