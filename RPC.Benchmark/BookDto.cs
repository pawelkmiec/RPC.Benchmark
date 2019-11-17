using System.ComponentModel.DataAnnotations;

namespace RPC.Benchmark
{
    public class BookDto
    {
        [StringLength(10)]
        public string ISBN { get; set; }

        [StringLength(20)]
        public string Title { get; set; }

        public int YearPublished { get; set; }

        public AuthorDto Author { get; set; }
    }
}