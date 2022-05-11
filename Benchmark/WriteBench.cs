using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using DataflowChannel;

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
                _channel.Write0(1);
            }
        }

        [IterationSetup(Target = nameof(Write1))]
        public void Write1Setup()
        {
            _channel = new Channel<int>();
        }

        //[Benchmark(OperationsPerInvoke = count)]
        public void Write1()
        {
            for (int i = 0; i < count; i++)
            {
                _channel.Write1(1);
            }
        }

        [IterationSetup(Target = nameof(Write2))]
        public void Write2Setup()
        {
            _channel = new Channel<int>();
        }

        //[Benchmark(OperationsPerInvoke = count)]
        public void Write2()
        {
            for (int i = 0; i < count; i++)
            {
                _channel.Write2(1);
            }
        }
    }
}
