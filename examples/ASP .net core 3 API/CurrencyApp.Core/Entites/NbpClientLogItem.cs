using EntityAuth.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CurrencyApp.Core.Entites
{
    public class NbpClientLogItem : IResourceId<long>
    {
        public long Id { get; set; }

        [Required]
        public DateTime RequestTime { get; set; }

        [Required]
        public long ResponseMillis { get; set; }

        [Required]
        public string ResponseUri { get; set; }

        [Required]
        public string ResponseStatus { get; set; }
    }
}
