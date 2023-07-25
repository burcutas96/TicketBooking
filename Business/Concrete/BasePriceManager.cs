using Business.Abstract;
using Core.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BasePriceManager : IBasePriceService
    {
        IBasePriceDal _basePriceDal;

        public BasePriceManager(IBasePriceDal basePriceDal)
        {
            _basePriceDal = basePriceDal;
        }

        public IResult Add(BasePrice entity)
        {
            _basePriceDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            _basePriceDal.Delete(id);
            return new SuccessResult();
        }

        public IDataResult<BasePrice> Get(int id)
        {
            return new SuccessDataResult<BasePrice>(_basePriceDal.Get(b => b.id == id));
        }

        public IDataResult<List<BasePrice>> GetAll()
        {
            return new SuccessDataResult<List<BasePrice>>(_basePriceDal.GetAll());
        }

        public IResult Update(BasePrice entity)
        {
            _basePriceDal.Update(entity);
            return new SuccessResult();
        }
    }
}
