namespace CurrencyApp.Infrastructure.Dto
{
    public class RateDto
    {
        public string Currency { get; set; }
        public string Code { get; set; }
    }

    public class RateDetailedDto : RateDto
    {
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
    }
}
