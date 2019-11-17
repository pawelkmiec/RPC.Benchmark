using System.Threading.Tasks;
using Grpc.Core;
using TryingOut.Benchmark.Api.Grpc;

namespace RPC.Benchmark.Api.gRPC
{
    public class BooksService : BookService.BookServiceBase
    {
        private static readonly ResponseCache ResponseCache = new ResponseCache();

        public override Task<BooksResponse> GetAll(GetAllBooksRequest request, ServerCallContext context)
        {
            return Task.FromResult(ResponseCache.GetAll());
        }

        public override Task<BookResponse> First(GetFirstBookRequest request, ServerCallContext context)
        {
            return Task.FromResult(ResponseCache.First());
        }

        public override Task<GetSalesStatsResponse> GetSalesStats(GetSalesStatsRequest request, ServerCallContext context)
        {
            return Task.FromResult(ResponseCache.GetSalesStats());
        }
    }
}
