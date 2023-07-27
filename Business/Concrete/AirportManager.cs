using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AirportManager : IAirportService
    {
        IAirportDal _airportDal;

        public AirportManager(IAirportDal airportDal)
        {
            _airportDal = airportDal;
        }


        public IResult Add(Airport entity)
        {
            _airportDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            _airportDal.Delete(id);
            return new SuccessResult();
        }

        public IDataResult<Airport> Get(int id)
        {
            return new SuccessDataResult<Airport>(_airportDal.Get(a => a.Id == id));
        }

        public IDataResult<List<Airport>> GetAll()
        {
            return new SuccessDataResult<List<Airport>>(_airportDal.GetAll());
        }

        public IResult Update(Airport entity)
        {
            _airportDal.Update(entity);
            return new SuccessResult();
        }
    }
}
