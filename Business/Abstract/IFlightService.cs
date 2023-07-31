using Core.Business;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IFlightService : IEntityService<Flight>
    {
        IDataResult<List<FlightDTO>> GetReturnFlightDTOs();
        IDataResult<List<FlightDTO>> GetDepartureFlightDTOs();
    }
}