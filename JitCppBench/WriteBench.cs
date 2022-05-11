using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using JitCpp;

namespace Benchmark
{
    [Config(typeof(BenchConfig))]
    [DisassemblyDiagnoser(printSource: true)]
    //[HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions)]
    public class WriteBench
    {
        private const int count = 100_000_000;
        private Channel<int> _channel;

        [IterationSetup(Target = nameof(Write0))]
        public void Write0Setup()
        {
            _channel = new Channel<int>();
        }

        [Benchmark(OperationsPerInvoke = count)]
        public void Write0()
        {
            for (int i = 0; i < count; i++)
            {
                _channel.Add(1);
            }
        }
    }
}
