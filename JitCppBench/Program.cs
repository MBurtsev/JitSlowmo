using System;
using System.Collections.Generic;
using System.Diagnostics;
using Benchmark;
using BenchmarkDotNet.Running;
using JitCpp;

namespace JitCppBench
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var count   = 100_000_000;
            var channel = new Channel<int>();
            var sw      = Stopwatch.StartNew();

            for (int i = 0; i < count; i++)
            {
                channel.Add(i);
            }

            Console.WriteLine($"Time:{sw.ElapsedMilliseconds}");

            //BenchmarkRunner.Run<WriteBench>();

            Console.WriteLine("Press any key for exit");
            Console.ReadLine();
        }
    }
}
