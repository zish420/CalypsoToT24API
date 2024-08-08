using CalypsoToT24API.Infrastructure.Models;

namespace CalypsoToT24API.Service.Abstraction
{
    public interface IFTTransactionRepository
    {
        Task AddAsync(FTTransaction transaction);
    }

}
