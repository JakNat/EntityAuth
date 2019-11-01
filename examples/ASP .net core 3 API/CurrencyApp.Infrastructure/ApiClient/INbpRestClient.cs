using System.Collections.Generic;
using CurrencyApp.Core.Models;
using RestSharp;

namespace CurrencyApp.Infrastructure.ApiClient
{
    public interface INbpRestClient
    {
        INbpTable FromTable(Table table);
    }

    public enum Table
    {
        a,b,c
    }
}