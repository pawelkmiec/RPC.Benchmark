using System.Runtime.Serialization;

namespace RPC.Benchmark.Api.gRPC.CodeFirst.Contract
{
    [DataContract]
    public class Author
    {
        [DataMember(Order = 1)]
        public string FirstName { get; set; }

        [DataMember(Order = 2)]
        public string LastName { get; set; }
    }
}