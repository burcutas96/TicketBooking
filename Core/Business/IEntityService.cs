using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public interface IEntityService<T> where  T : BaseEntity, new()
    {
        List<T> GetAll();
        void Update(T entity);
        void Delete(int id);
        void Add(T entity);
    }
}
