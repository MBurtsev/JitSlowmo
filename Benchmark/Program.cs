using BenchmarkDotNet.Running;

namespace Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<WriteBench>();

            Console.WriteLine("Press any key for exit");
            Console.ReadKey();
        }
    }
}
