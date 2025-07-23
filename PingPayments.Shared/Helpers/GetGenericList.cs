using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PingPayments.Shared.Helpers
{
    internal class GenericList<T> where T : class
    {
        private readonly HttpClient _httpClient;
        protected virtual JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        public GenericList(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<T>> GetTListAsync(string baseUrl)
        {
            List<T> result = new List<T>();
            var response = await _httpClient.GetAsync(baseUrl);
            if (!response.IsSuccessStatusCode || response.Content.Headers.ContentLength == 0)
                return new List<T>();

            var resultObj = JsonSerializer.Deserialize<GenericTransfer<T>>(await response.Content.ReadAsStreamAsync(), JsonSerializerOptions);
            while (resultObj != null && resultObj.Data != null && resultObj.Data.Any())
            {
                result.AddRange(resultObj.Data);
                if (resultObj.PaginationLinks.Next?.Href == null)
                    break;
                response = await _httpClient.GetAsync(resultObj.PaginationLinks.Next.Href);
                resultObj = JsonSerializer.Deserialize<GenericTransfer<T>>(await response.Content.ReadAsStreamAsync(), JsonSerializerOptions);
            }
            return result;
        }
    }
}
