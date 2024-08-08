using CalypsoToT24API.Infrastructure.Models;

namespace CalypsoToT24API.Service.Abstraction
{
    public interface IFTTransactionService
    {
        public  Task<bool> SaveFTTransaction(CalypsoEventsFTWS calypsoEvent);
    }


}
