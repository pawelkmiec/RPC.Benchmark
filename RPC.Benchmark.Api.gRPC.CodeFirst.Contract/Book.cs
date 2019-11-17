using System.Runtime.Serialization;

namespace RPC.Benchmark.Api.gRPC.CodeFirst.Contract
{
    [DataContract]
    public class Book
    {
        [DataMember(Order = 1)]
        public string ISBN { get; set; }

        [DataMember(Order = 2)]
        public string Title { get; set; }

        [DataMember(Order = 3)]
        public int YearPublished { get; set; }

        [DataMember(Order = 4)]
        public Author Author { get; set; }
    }
}