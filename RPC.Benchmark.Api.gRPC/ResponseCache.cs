using System.Linq;
using TryingOut.Benchmark.Api.Grpc;

namespace RPC.Benchmark.Api.gRPC
{
    public class ResponseCache
    {
        private static readonly BookRepository BookRepository = new BookRepository();
        
        private BooksResponse _getAllBooksResponse;
        private BookResponse _getFirstBooksResponse;
        private GetSalesStatsResponse _getSalesStatsResponse;

        public BooksResponse GetAll()
        {
            _getAllBooksResponse ??= GetResponse();
            return _getAllBooksResponse;

            BooksResponse GetResponse()
            {
                var books = BookRepository.Books.Select(MapBook).ToList();
                var response = new BooksResponse();
                response.Books.AddRange(books);
                return response;
            }
        }

        public BookResponse First()
        {
            _getFirstBooksResponse ??= GetResponse();
            return _getFirstBooksResponse;

            BookResponse GetResponse()
            {
                var response = new BookResponse
                {
                    Book = MapBook(BookRepository.Books[0])
                };
                return response;
            }
        }

        public GetSalesStatsResponse GetSalesStats()
        {
            _getSalesStatsResponse ??= GetResponse();
            return _getSalesStatsResponse;

            GetSalesStatsResponse GetResponse()
            {
                var response = new GetSalesStatsResponse
                {
                    Stats = MapStats(BookRepository.Stats[0])
                };
                return response;
            }
        }

        private Book MapBook(BookDto x)
        {
            return new Book
            {
                ISBN = x.ISBN,
                Title = x.Title,
                YearPublished = x.YearPublished,
                Author = new Author
                {
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName
                }
            };
        }

        private BookSalesStats MapStats(BooksSalesStatsDto stats)
        {
            return new BookSalesStats
            {
                SalesQuantityTotal = stats.SalesQuantityTotal,
                SalesQuantityLastMonth = stats.SalesQuantityLastMonth,
                SalesQuantityLastYear = stats.SalesQuantityLastYear
            };
        }
    }
}
