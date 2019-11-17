using System.ComponentModel.DataAnnotations;

namespace RPC.Benchmark
{
    public class AuthorDto
    {
        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(10)]
        public string LastName { get; set; }
    }
}