using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using RPC.Benchmark.Api.gRPC.CodeFirst.Contract;
using Book = RPC.Benchmark.Api.gRPC.CodeFirst.Contract.Book;
using BookSalesStats = RPC.Benchmark.Api.gRPC.CodeFirst.Contract.BookSalesStats;

namespace RPC.Benchmark.Runner
{
    public class CodeFirstGrpcClient : IBookService
    {
        private readonly GrpcChannel _channel;
        private readonly IBookService _bookService;

        public CodeFirstGrpcClient(string apiUrl)
        {
            _channel = GrpcChannel.ForAddress(apiUrl);
            _bookService = _channel.CreateGrpcService<IBookService>();
        }

        public Task<List<Book>> GetAllBooks()
        {
            return _bookService.GetAllBooks();
        }

        public Task<Book> GetBook()
        {
            return _bookService.GetBook();
        }

        public Task<BookSalesStats> GetStats()
        {
            return _bookService.GetStats();
        }
    }
}
