using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FlightTypeManager : IFlightTypeService
    {
        IFlightTypeDal _flightTypeDal;

        public FlightTypeManager(IFlightTypeDal flightTypeDal)
        {
            _flightTypeDal = flightTypeDal;
        }


        public IResult Add(FlightType entity)
        {
            entity.Id = 0;
            _flightTypeDal.Add(entity);
            return new SuccessResult(FlightTypeMessages.FlightTypeAdded);
        }

        public IResult Delete(FlightType entity)
        {
            var result = _flightTypeDal.Get(a => a.Id == entity.Id);
            if (result == null)
            {
                return new ErrorResult(FlightTypeMessages.FlightTypeNotFound);
            }

            _flightTypeDal.Delete(entity);
            return new SuccessResult(FlightTypeMessages.FlightTypeDeleted);
        }

        public IDataResult<FlightType> Get(int id)
        {
            var result = _flightTypeDal.Get(a => a.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<FlightType>(result, FlightTypeMessages.FlightTypeNotFound);
            }

            return new SuccessDataResult<FlightType>(result, FlightTypeMessages.FlightTypeWasBrought);
        }

        public IDataResult<List<FlightType>> GetAll()
        {
            return new SuccessDataResult<List<FlightType>>(_flightTypeDal.GetAll(), FlightTypeMessages.FlightTypesListed);
        }

        public IResult Update(FlightType entity)
        {
            var result = _flightTypeDal.Get(a => a.Id == entity.Id);
            if (result == null)
            {
                return new ErrorResult(FlightTypeMessages.FlightTypeNotFound);
            }
            _flightTypeDal.Update(entity);
            return new SuccessResult(FlightTypeMessages.FlightTypeUpdated);
        }
    }
}
