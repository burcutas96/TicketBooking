using Core.Entities;
using Core.Utilities.Result;

namespace Core.Business
{
    public interface IEntityService<T> where  T : BaseEntity, new()
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> Get(int id);
        IResult Update(T entity);
        IResult Delete(T entity);
        IResult Add(T entity);
    }
}
