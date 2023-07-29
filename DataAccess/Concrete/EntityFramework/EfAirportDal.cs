using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAirportDal : EfEntityRepositoryBase<Airport, TicketBookingContext>, IAirportDal
    {
    }
}
