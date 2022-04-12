using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyBenchmarks
{
    [AllStatisticsColumn]
    public class ParallePerfTest
    {
        private readonly ParalleTest parallelTest;

        public ParallePerfTest()
        {
            parallelTest = new ParalleTest();
        }

        [Benchmark]
        public async Task MaxParalle16() => await parallelTest.MaxParalle(16);

        [Benchmark]
        public async Task MaxParalle32() => await parallelTest.MaxParalle(32);

        [Benchmark]
        public async Task MaxParalle64() => await parallelTest.MaxParalle(64);

        [Benchmark]
        public async Task MaxParalle128() => await parallelTest.MaxParalle(128);

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}