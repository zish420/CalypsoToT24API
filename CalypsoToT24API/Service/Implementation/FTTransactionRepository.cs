using CalypsoToT24API.Infrastructure;
using CalypsoToT24API.Infrastructure.Models;
using CalypsoToT24API.Service.Abstraction;

namespace CalypsoToT24API.Service.Implementation
{
    public class FTTransactionRepository : IFTTransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public FTTransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FTTransaction transaction)
        {
            _context.FTTransactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
