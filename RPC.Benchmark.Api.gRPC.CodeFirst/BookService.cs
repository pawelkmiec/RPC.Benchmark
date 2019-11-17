using System.Collections.Generic;
using System.Threading.Tasks;
using RPC.Benchmark.Api.gRPC.CodeFirst.Contract;

namespace RPC.Benchmark.Api.gRPC.CodeFirst
{
    public class BookService : IBookService
    {
        private static readonly ResponseCache ResponseCache = new ResponseCache();

        public async Task<List<Book>> GetAllBooks()
        {
            return ResponseCache.GetAll();
        }

        public async Task<Book> GetBook()
        {
            return ResponseCache.First();
        }

        public async Task<BookSalesStats> GetStats()
        {
            return ResponseCache.GetSalesStats();
        }
    }
}
