using System.Runtime.Serialization;

namespace RPC.Benchmark.Api.gRPC.CodeFirst.Contract
{
    [DataContract]
    public class BookSalesStats
    {
        [DataMember(Order = 1)]
        public int SalesQuantityLastMonth { get; set; }

        [DataMember(Order = 2)]
        public int SalesQuantityLastYear { get; set; }

        [DataMember(Order = 3)]
        public int SalesQuantityTotal { get; set; }
    }
}