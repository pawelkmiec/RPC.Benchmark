using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace RPC.Benchmark.Api.gRPC.CodeFirst.Contract
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        Task<List<Book>> GetAllBooks();

        [OperationContract]
        Task<Book> GetBook();

        [OperationContract]
        Task<BookSalesStats> GetStats();
    }
}
