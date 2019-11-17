using System.IO;
using Newtonsoft.Json;

namespace RPC.Benchmark.DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = BookGenerator.CreateBooks();
            GenerateJson(books, "books.json");

            var stats = BookGenerator.CreateBookSalesStats();
            GenerateJson(stats, "stats.json");
        }

        private static void GenerateJson(object model, string filePath)
        {
            var booksJson = JsonConvert.SerializeObject(model, Formatting.Indented);
            File.WriteAllText(filePath, booksJson);
        }
    }
}
