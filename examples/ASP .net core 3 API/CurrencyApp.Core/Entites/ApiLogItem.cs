using EntityAuth.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyApp.Core.Entites
{
    public class ApiLogItem : IResourceId<long>
    {
        public long Id { get; set; }

        [Required]
        public DateTime RequestTime { get; set; }

        [Required]
        public long ResponseMillis { get; set; }

        [Required]
        public int StatusCode { get; set; }

        [Required]
        public string Method { get; set; }

        [Required]
        public string Path { get; set; }

        public string QueryString { get; set; }

        public string RequestBody { get; set; }

        public string ResponseBody { get; set; }
    }
}
