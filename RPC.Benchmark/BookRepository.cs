using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace RPC.Benchmark
{
    // this repo is to ensure that both GRPC & JSON APIs use the same set of data
    public class BookRepository
    {
        public BookRepository()
        {
            Books = ReadItems<BookDto>("books.json");
            Stats = ReadItems<BooksSalesStatsDto>("stats.json");
        }

        public List<BookDto> Books { get; }

        public List<BooksSalesStatsDto> Stats { get; }

        private List<T> ReadItems<T>(string filePath)
        {
            var resourceContents = ReadEmbeddedResource(filePath);
            var items = JsonConvert.DeserializeObject<List<T>>(resourceContents);
            return items;
        }

        private static string ReadEmbeddedResource(string filePath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "RPC.Benchmark.Data." + filePath;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
