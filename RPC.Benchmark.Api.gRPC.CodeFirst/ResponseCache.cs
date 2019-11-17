using System.Collections.Generic;
using System.Linq;
using RPC.Benchmark.Api.gRPC.CodeFirst.Contract;

namespace RPC.Benchmark.Api.gRPC.CodeFirst
{
    public class ResponseCache
    {
        private static readonly BookRepository BookRepository = new BookRepository();
        
        private List<Book> _getAllBooksResponse;
        private Book _getFirstBooksResponse;
        private BookSalesStats _getSalesStatsResponse;

        public List<Book> GetAll()
        {
            _getAllBooksResponse ??= GetResponse();

            return _getAllBooksResponse;

            List<Book> GetResponse()
            {
                return BookRepository.Books.Select(MapBook).ToList();
            }
        }

        public Book First()
        {
            _getFirstBooksResponse ??= GetResponse();
            return _getFirstBooksResponse;

            Book GetResponse()
            {
                return MapBook(BookRepository.Books[0]);
            }
        }

        public BookSalesStats GetSalesStats()
        {
            _getSalesStatsResponse ??= GetResponse();
            return _getSalesStatsResponse;

            BookSalesStats GetResponse()
            {
                return MapStats(BookRepository.Stats[0]);
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
