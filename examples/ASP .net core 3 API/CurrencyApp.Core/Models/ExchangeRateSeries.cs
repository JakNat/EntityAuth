using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyApp.Core.Models
{
    public class ExchangeRateSeries
    {

        /// <summary>
        /// Type of Table
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// Table Number 
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Publication Date
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// List of Rates in Table
        /// </summary>
        public IEnumerable<Rate> Rates { get; set; }
    }
}
