using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AirlineManager : IAirlineService
    {
        IAirlineDal _airlineDal;

        public AirlineManager(IAirlineDal airlineDal)
        {
            _airlineDal = airlineDal;
        }


        public IResult Add(Airline entity)
        {
            entity.Id = 0;
            _airlineDal.Add(entity);
            return new SuccessResult(AirlineMessages.AirlineAdded);
        }

        public IResult Delete(Airline entity)
        {
            _airlineDal.Delete(entity);
            return new SuccessResult(AirlineMessages.AirlineDeleted);
        }

        public IDataResult<Airline> Get(int id)
        {
            return new SuccessDataResult<Airline>(_airlineDal.Get(a => a.Id == id), AirlineMessages.AirlineWasBrought);
        }

        public IDataResult<List<Airline>> GetAll()
        {
            return new SuccessDataResult<List<Airline>>(_airlineDal.GetAll(), AirlineMessages.AirlinesListed);
        }

        public IResult Update(Airline entity)
        {
            _airlineDal.Update(entity);
            return new SuccessResult(AirlineMessages.AirlineUpdated);
        }
    }
}
