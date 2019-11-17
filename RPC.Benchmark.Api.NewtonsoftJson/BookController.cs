using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RPC.Benchmark.Api.NewtonsoftJson
{
    [Route("books")]
    public class BookController : Controller
    {
        private static readonly BookRepository BookRepository = new BookRepository();

        [Route("all")]
        public List<BookDto> GetAll()
        {
            return BookRepository.Books;
        }

        [Route("first")]
        public BookDto First()
        {
            return BookRepository.Books[0];
        }

        [Route("stats")]
        public BooksSalesStatsDto Stats()
        {
            return BookRepository.Stats[0];
        }
    }
}
