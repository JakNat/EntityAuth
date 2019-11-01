namespace CurrencyApp.Core.Models
{
    public class Rate
    {

        /// <summary>
        /// Currency Name
        /// </summary>
        public string Currency { get; set; }
        
        /// <summary>
        /// Currency Code
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        ///Converted currency purchase rate (table C)
        /// </summary>
        public decimal Bid { get; set; } 
        
        /// <summary>
        /// Converted currency sale rate (table C)
        /// </summary>
        public decimal Ask { get; set; }

        /// <summary>
        /// Converted average exchange rate (table A and B)
        /// </summary>
        public decimal Mid { get; set; }
    }
}