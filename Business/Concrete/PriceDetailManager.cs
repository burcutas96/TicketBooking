using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PriceDetailManager : IPriceDetailService
    {
        IPriceDetailDal _priceDetailDal;

        public PriceDetailManager(IPriceDetailDal priceDetailDal)
        {
            _priceDetailDal = priceDetailDal;
        }

        public IResult Add(PriceDetail entity)
        {
            _priceDetailDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            _priceDetailDal.Delete(id);
            return new SuccessResult();
        }

        public IDataResult<PriceDetail> Get(int id)
        {
            return new SuccessDataResult<PriceDetail>(_priceDetailDal.Get(p => p.id == id));
        }

        public IDataResult<List<PriceDetail>> GetAll()
        {
            return new SuccessDataResult<List<PriceDetail>>(_priceDetailDal.GetAll());
        }

        public IResult Update(PriceDetail entity)
        {
            _priceDetailDal.Update(entity);
            return new SuccessResult();
        }
    }
}
