using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RPC.Benchmark.Runner
{
    public class NewtonsoftJsonApiClient
    {
        private readonly HttpClient _client;

        public NewtonsoftJsonApiClient(string apiUrl)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(apiUrl)
            };
        }

        public async Task<IEnumerable<BookDto>> GetAllBooks()
        {
            var response = await _client.GetStringAsync("/books/all");
            var books = JsonConvert.DeserializeObject<IEnumerable<BookDto>>(response);
            return books;
        }

        public async Task<BookDto> GetBook()
        {
            var response = await _client.GetStringAsync("/books/first");
            var book = JsonConvert.DeserializeObject<BookDto>(response);
            return book;
        }

        public async Task<BooksSalesStatsDto> GetStats()
        {
            var response = await _client.GetStringAsync("/books/stats");
            var stats = JsonConvert.DeserializeObject<BooksSalesStatsDto>(response);
            return stats;
        }
    }
}
