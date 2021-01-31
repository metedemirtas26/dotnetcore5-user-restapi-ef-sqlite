using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Client
{
    public class RestCountriesClient
    {
        private const string RestCountriesUrl = "https://restcountries.eu/rest/v2/name/";

        private HttpClient _client;
        private readonly ILogger<RestCountriesClient> _logger;

        public RestCountriesClient(HttpClient client, ILogger<RestCountriesClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<bool> CheckCity(string city = "aruba")
        {
            try
            {
                using var responseStream = await _client.GetStreamAsync(GetWeatherStackUrl(city));
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong when calling RestCountriesClient: {city}");
                return false;
            }
        }

        private string GetWeatherStackUrl(string city)
        {
            return RestCountriesUrl + city
                   + "?fullText=true";
        }
    }
}
