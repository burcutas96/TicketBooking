using Business.Abstract;
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
    public class AirlineManager : IAirlineService
    {
        IAirlineDal _airlineDal;

        public AirlineManager(IAirlineDal airlineDal)
        {
            _airlineDal = airlineDal;
        }


        public IResult Add(Airline entity)
        {
            _airlineDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            _airlineDal.Delete(id);
            return new SuccessResult();
        }

        public IDataResult<Airline> Get(int id)
        {
            return new SuccessDataResult<Airline>(_airlineDal.Get(a => a.Id == id));
        }

        public IDataResult<List<Airline>> GetAll()
        {
            return new SuccessDataResult<List<Airline>>(_airlineDal.GetAll());
        }

        public IResult Update(Airline entity)
        {
            _airlineDal.Update(entity);
            return new SuccessResult();
        }
    }
}
