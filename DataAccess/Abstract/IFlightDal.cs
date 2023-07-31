using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IFlightDal : IEntityRepository<Flight>
    {
        List<FlightDTO> GetFlightDTOs(Expression<Func<FlightDTO, bool>> filter = null);
    }
}