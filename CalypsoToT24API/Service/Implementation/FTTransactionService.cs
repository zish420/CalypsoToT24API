using CalypsoToT24API.Infrastructure;
using CalypsoToT24API.Service.Abstraction;
using CalypsoToT24API.Helper;
using CalypsoToT24API.Infrastructure.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CalypsoToT24API.Service.Implementation
{
    public class FTTransactionService : IFTTransactionService
    {
        private readonly IFTTransactionRepository _repository;
        private readonly IMemoryCache _cache;

        public FTTransactionService(IFTTransactionRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<bool> SaveFTTransaction(CalypsoEventsFTWS calypsoEvent)
        {
            if (!CompanyCodeMapper.TryGetCompanyCode(calypsoEvent.CompanyCode, out CompanyCode companyCode))
            {
                throw new ArgumentException($"Invalid CompanyCode: {calypsoEvent.CompanyCode}");
            }

            var data = calypsoEvent.CalypsoData.Split(';');

            var transaction = new FTTransaction
            {
                Company = companyCode.ToString(),
                CalypsoEventId = calypsoEvent.CalypsoEventId,
                EventType = data[0],
                PostingId = data[1],
                PostingVersion = data[2],
                T24Reference = data[3],
                PostingType = data[4],
                PostingLinkedId = data[5],
                LinkedT24Reference = data[6],
                TradeId = data[7],
                TradeVersion = data[8],
                ProductFamily = data[9],
                ProductType = data[10],
                ProcessingOrg = data[11],
                PostingAmount = decimal.Parse(data[12]),
                PostingCurrency = data[13],
                DebitAccountName = data[14],
                EffectiveDate = DateTime.ParseExact(data[15], "yyyyMMdd", null),
                Financial = bool.Parse(data[16]),
                CounterpartyExternalReference = data[17],
                SystemDate = DateTime.ParseExact(data[18], "yyyyMMdd", null),
                SettlementMethod = data[19],
                SpotRate = decimal.Parse(data[20]),
                MaturityDate = DateTime.ParseExact(data[21], "yyyyMMdd", null),
                PrincipalBeneficiaryInternal = data.Length > 22 ? data[22] : string.Empty,
                PrincipalIntermediaryInternal = data.Length > 23 ? data[23] : string.Empty
            };

            try
            {
                await _repository.AddAsync(transaction);
                _cache.Set(transaction.CalypsoEventId, transaction, TimeSpan.FromMinutes(10)); // Example caching
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to save FT to DB");
                return false;
            }
        }
    }
}
