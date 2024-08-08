namespace CalypsoToT24API.Infrastructure.Models
{
    public class FTTransaction
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string CalypsoEventId { get; set; }
        public string EventType { get; set; }
        public string PostingId { get; set; }
        public string PostingVersion { get; set; }
        public string T24Reference { get; set; }
        public string PostingType { get; set; }
        public string PostingLinkedId { get; set; }
        public string LinkedT24Reference { get; set; }
        public string TradeId { get; set; }
        public string TradeVersion { get; set; }
        public string ProductFamily { get; set; }
        public string ProductType { get; set; }
        public string ProcessingOrg { get; set; }
        public decimal PostingAmount { get; set; }
        public string PostingCurrency { get; set; }
        public string DebitAccountName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public bool Financial { get; set; }
        public string CounterpartyExternalReference { get; set; }
        public DateTime SystemDate { get; set; }
        public string SettlementMethod { get; set; }
        public decimal SpotRate { get; set; }
        public DateTime MaturityDate { get; set; }
        public string PrincipalBeneficiaryInternal { get; set; }
        public string PrincipalIntermediaryInternal { get; set; }
    }
}
