using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RPC.Benchmark.Runner
{
    public class Program
    {
        private const int RepeatCount = 1000;

        private static readonly GrpcApiClient GrpcClient = new GrpcApiClient("https://localhost:5001");
        private static readonly JsonApiClient JsonClient = new JsonApiClient("https://localhost:5002");
        private static readonly NewtonsoftJsonApiClient NewtonsoftJsonClient = new NewtonsoftJsonApiClient("https://localhost:5003");
        private static readonly CodeFirstGrpcClient CodeFirstGrpcClient = new CodeFirstGrpcClient("https://localhost:5004");

        static async Task Main()
        {
            await RunTest(nameof(GetStatsGrpc), GetStatsGrpc);
            await RunTest(nameof(GetStatsCodeFirstGrpc), GetStatsCodeFirstGrpc);
            await RunTest(nameof(GetStatsJson), GetStatsJson);
            await RunTest(nameof(GetStatsNewtonsoftJson), GetStatsNewtonsoftJson);

            await RunTest(nameof(GetBookGrpc), GetBookGrpc);
            await RunTest(nameof(GetBookCodeFirstGrpc), GetBookCodeFirstGrpc);
            await RunTest(nameof(GetBookJson), GetBookJson);
            await RunTest(nameof(GetBookNewtonsoftJson), GetBookNewtonsoftJson);

            await RunTest(nameof(GetAllBooksGrpc), GetAllBooksGrpc);
            await RunTest(nameof(GetAllBooksCodeFirstGrpc), GetAllBooksCodeFirstGrpc);
            await RunTest(nameof(GetAllBooksJson), GetAllBooksJson);
            await RunTest(nameof(GetAllBooksNewtonsoftJson), GetAllBooksNewtonsoftJson);

            if (Debugger.IsAttached)
            {
                Console.ReadLine();
            }
        }

        private static async Task RunTest(string methodName, Func<Task> action)
        {
            var responseTime = await Repeat(RepeatCount, action);
            Console.WriteLine($"{methodName} - {responseTime} ms");
        }

        private static async Task GetStatsGrpc() => await GrpcClient.GetStats();

        private static async Task GetStatsCodeFirstGrpc() => await CodeFirstGrpcClient.GetStats();

        private static async Task GetStatsJson() => await JsonClient.GetStats();

        private static async Task GetStatsNewtonsoftJson() => await NewtonsoftJsonClient.GetStats();

        private static async Task GetBookGrpc() => await GrpcClient.GetBook();

        private static async Task GetBookCodeFirstGrpc() => await CodeFirstGrpcClient.GetBook();

        private static async Task GetBookJson() => await JsonClient.GetBook();

        private static async Task GetBookNewtonsoftJson() => await NewtonsoftJsonClient.GetBook();

        private static async Task GetAllBooksGrpc() => await GrpcClient.GetAllBooks();

        private static async Task GetAllBooksCodeFirstGrpc() => await CodeFirstGrpcClient.GetAllBooks();

        private static async Task GetAllBooksJson() => await JsonClient.GetAllBooks();

        private static async Task GetAllBooksNewtonsoftJson() => await NewtonsoftJsonClient.GetAllBooks();

        private static async Task<long> Repeat(int count, Func<Task> toRepeat)
        {
            var sw = new Stopwatch();
            sw.Start();

            for (var i = 0; i < count; i++)
            {
                await toRepeat();
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
