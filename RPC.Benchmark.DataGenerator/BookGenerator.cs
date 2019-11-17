using System.Collections.Generic;
using System.Linq;
using AutoFixture;

namespace RPC.Benchmark.DataGenerator
{
    public class BookGenerator
    {
        private static readonly Fixture Fixture = new Fixture();

        public static List<BookDto> CreateBooks()
        {
            return CreateItems<BookDto>();
        }

        public static List<BooksSalesStatsDto> CreateBookSalesStats()
        {
            return CreateItems<BooksSalesStatsDto>();
        }

        private static List<T> CreateItems<T>()
        {
            return Enumerable.Range(0, 1000).Select(s => Fixture.Create<T>()).ToList();
        }
    }
}
