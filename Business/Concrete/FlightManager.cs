using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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
            return new SuccessResult(FlightMessages.FlightAdded);
        }
        
        public IResult Delete(Flight entity)
        {
            var result = _flightDal.Get(a => a.Id == entity.Id);
            if (result == null)
            {
                return new ErrorResult(FlightMessages.FlightNotFound);
            }
            _flightDal.Delete(entity);
            return new SuccessResult(FlightMessages.FlightDeleted);
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
                return new ErrorResult(FlightMessages.FlightNotFound);
            }    
            
            _flightDal.Update(entity);
            return new SuccessResult(FlightMessages.FlightUpdated);
        }

        public IDataResult<List<FlightDTO>> GetReturnFlightDTOs()
        {
            return new SuccessDataResult<List<FlightDTO>>(_flightDal.GetFlightDTOs(f => f.FlightType == "Return"), FlightMessages.FlightsListed);
        }

        public IDataResult<List<FlightDTO>> GetDepartureFlightDTOs()
        {
            return new SuccessDataResult<List<FlightDTO>>(_flightDal.GetFlightDTOs(f => f.FlightType == "Departure"), FlightMessages.FlightsListed);
        }
    }
}