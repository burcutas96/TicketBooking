using Business.Abstract;
using Business.Constants.Messages;
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
            entity.Id = 0;
            _airportDal.Add(entity);
            return new SuccessResult(AirportMessages.AirportAdded);
        }

        public IResult Delete(Airport entity)
        {
            _airportDal.Delete(entity);
            return new SuccessResult(AirportMessages.AirportDeleted);
        }

        public IDataResult<Airport> Get(int id)
        {
            return new SuccessDataResult<Airport>(_airportDal.Get(a => a.Id == id), AirportMessages.AirportWasBrought);
        }

        public IDataResult<List<Airport>> GetAll()
        {
            return new SuccessDataResult<List<Airport>>(_airportDal.GetAll(), AirportMessages.AirportsListed);
        }

        public IResult Update(Airport entity)
        {
            _airportDal.Update(entity);
            return new SuccessResult(AirportMessages.AirportUpdated);
        }
    }
}
