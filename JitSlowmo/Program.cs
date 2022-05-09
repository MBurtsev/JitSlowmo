using System;
using DataflowChannel;
using System.Diagnostics;

namespace JitSlowmo
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
                // 2300ms why it so slow ?
                channel.Write0(i);

                // 240ms Same without increment 10 times faster!
                //channel.Write1(i);

                // 171ms Only increment
                //channel.Write2(i);

                // How 240 + 171 = 2300 ?
            }

            Console.WriteLine($"Time:{sw.ElapsedMilliseconds}");
        }
    }
}
