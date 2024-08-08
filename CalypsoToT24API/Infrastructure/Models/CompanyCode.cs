namespace CalypsoToT24API.Infrastructure.Models
{
    public enum CompanyCode
    {
        KE0010001,
        UG0010001,
        RW0010001,
        TZ0010001
    }

    public static class CompanyCodeMapper
    {
        private static readonly Dictionary<string, CompanyCode> _companyCodeMap = new Dictionary<string, CompanyCode>
    {
        { "NCBA KENYA", CompanyCode.KE0010001 },
        { "NCBA UGANDA", CompanyCode.UG0010001 },
        { "NCBA RWANDA", CompanyCode.RW0010001 },
        { "NCBA TANZANIA", CompanyCode.TZ0010001 }
    };

        public static bool TryGetCompanyCode(string companyName, out CompanyCode companyCode)
        {
            return _companyCodeMap.TryGetValue(companyName, out companyCode);
        }
    }
}
