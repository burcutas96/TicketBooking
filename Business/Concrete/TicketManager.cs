using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TicketManager : ITicketService
    {
        ITicketDal _ticketDal;

        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }
        
        public IResult Add(Ticket entity)
        {
            entity.Id = 0;
            _ticketDal.Add(entity);
            return new SuccessResult(TicketMessages.TickedAdded);
        }
        
        public IResult Delete(Ticket entity)
        {
            _ticketDal.Delete(entity);
            return new SuccessResult(TicketMessages.TicketDeleted);
        }

        public IDataResult<Ticket> Get(int id)
        {
            var result = _ticketDal.Get(a => a.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Ticket>(result, TicketMessages.TicketNotFound);
            } 
            return new SuccessDataResult<Ticket>(Ticket, TicketMessages.TicketWasBrought);
        }

        public IDataResult<List<Ticket>> GetAll()
        {
            return new SuccessDataResult<List<Ticket>>(_ticketDal.GetAll(), TicketMessages.TicketsListed);
        }

        public IResult Update(Ticket entity)
        {
            var result = _ticketDal.Get(a => a.Id = entity.Id);
            
            if (result == null)
            {
                return new ErrorResult<Ticket>(TicketMessages.TicketNotFound)
            }
            
            _ticketDal.Update(entity);
            return new SuccessResult(TicketMessages.TicketUpdated);
        }
    }
}