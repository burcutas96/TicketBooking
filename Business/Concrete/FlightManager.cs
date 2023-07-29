using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FlightManager : IFlightService
    {
        private IFlightDal _flightDal;

        public FlightManager(IFlightDal flightDal)
        {
            _flightDal = flightDal;
        }

        public IResult Add(Flight entity)
        {
            entity.Id = 0;
            _flightDal.Add(entity);
            return new SuccesResult(FlightMessages.FlightAdded);
        }
        
        public IResult Delete(Flight entity)
        {
            _flightDal.Delete(entity);
            return new SuccesResult(FlightMessages.FlightDeleted);
        }
        
        public IDataResult<Flight> Get(int id)
        {
            var result = _flightDal.Get(a => a.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Flight>(result, FlightMessages.FlightNotFound);
            } 
            return new SuccessDataResult<Flight>(result, FlightMessages.FlightWasBrought);
        }

        public IDataResult<List<Flight>> GetAll()
        {
            return new SuccessDataResult<List<Flight>>(_flightDal.GetAll(), FlightMessages.FlightsListed);
        }

        public IResult Update(Flight entity)
        {
            var result = _flightDal.Get(a => a.Id == entity.Id);
            
            if (result == null)
            {
                return new ErrorDataResult<Flight>(result, FlightMessages.FlightNotFound);
            }    
            
            _airportDal.Update(entity);
            return new SuccessResult(FlightMessages.FlightUpdated);
        }
    }
}