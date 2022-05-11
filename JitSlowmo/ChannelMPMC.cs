// Maksim Burtsev https://github.com/MBurtsev
// Licensed under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DataflowChannel
{
    public partial class Channel<T>
    {
        // The default value that is used if the user has not specified a capacity.
        private const int DEFAULT_SEGMENT_CAPACITY = 32 * 1024;
        private const int DATA_CAPACITY = 1024;
        // Current segment size
        private readonly int _capacity;
        private ChannelData _channel;

        int WriterOperation = 0;

        public Channel() : this(DEFAULT_SEGMENT_CAPACITY)
        { 
        }

        public Channel(int capacity)
        {
            _capacity = capacity;
            _channel = new ChannelData(capacity);
        }

        // 2300ms why it so slow ?
        //[MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public void Write0(T value)
        {
            var channel = _channel;
            var operation = channel.WriterOperation;
            
            channel.WriterOperation++;
            
            var data = channel.Storage[operation % DATA_CAPACITY];
            var seg = data.Writer;
            var pos = seg.WriterPosition;

            seg.WriterMessages[pos] = value;
        }
        public void Write00(T value)
        {
            var channel = _channel;
            var operation = channel.WriterOperation;
            
            channel.WriterOperation++;
            //channel.WriterOperation = channel.WriterOperation + 1;

            var data = channel.Storage[operation % DATA_CAPACITY];
            var seg = data.Writer;

            seg.WriterMessages[seg.WriterPosition] = value;
        }

        // 240ms
        public void Write1(T value)
        {
            var channel = _channel;
                        
            var operation = channel.WriterOperation;

            //channel.WriterOperation++;

            var data = channel.Storage[operation % DATA_CAPACITY];
            var seg = data.Writer;

            seg.WriterMessages[seg.WriterPosition] = value;
        }

        // 170ms
        public void Write2(T value)
        {
            var channel = _channel;

            channel.WriterOperation++;
        }

        #region ' Structures '

        private /*sealed class*/ struct ChannelData
        {
            public ChannelData(int capacity)
            {
                Storage = new CycleBuffer[DATA_CAPACITY];

                for (var i = 0; i < DATA_CAPACITY; i++)
                {
                    Storage[i] = new CycleBuffer(capacity);
                }
            }

            public readonly CycleBuffer[] Storage;
            public int WriterOperation = 0;
        }

        private sealed class CycleBuffer
        {
            public CycleBuffer(int capacity)
            {
                var seg = new CycleBufferSegment(capacity);

                Head = seg;
                Reader = seg;
                Writer = seg;
            }

            // head segment
            public CycleBufferSegment Head;
            private long _empty00;
            private long _empty01;
            private long _empty02;
            private long _empty03;
            private long _empty04;
            private long _empty05;
            private long _empty06;
            private long _empty07;

            // current reader segment
            public CycleBufferSegment Reader;
            private long _empty08;
            private long _empty09;
            private long _empty10;
            private long _empty11;
            private long _empty12;
            private long _empty13;
            private long _empty14;
            private long _empty15;

            // current writer segment
            public CycleBufferSegment Writer;
            private long _empty16;
            private long _empty17;
            private long _empty18;
            private long _empty19;
            private long _empty20;
            private long _empty21;
            private long _empty22;
            private long _empty23;
        }

        private sealed class CycleBufferSegment
        {
            public CycleBufferSegment(int capacity)
            {
                var mes = new T[capacity];
                WriterMessages = mes;
                ReaderMessages = mes;
            }

            // Reading thread position
            public int ReaderPosition;
            private long _empty00;
            private long _empty01;
            private long _empty02;
            private long _empty03;
            private long _empty04;
            private long _empty05;
            private long _empty06;
            private long _empty07;

            public T[] ReaderMessages;
            private long _empty08;
            private long _empty09;
            private long _empty10;
            private long _empty11;
            private long _empty12;
            private long _empty13;
            private long _empty14;
            private long _empty15;

            // Writing thread position
            public int WriterPosition;
            private long _empty16;
            private long _empty17;
            private long _empty18;
            private long _empty19;
            private long _empty20;
            private long _empty21;
            private long _empty22;
            private long _empty23;

            public T[] WriterMessages;
            private long _empty24;
            private long _empty25;
            private long _empty26;
            private long _empty27;
            private long _empty28;
            private long _empty29;
            private long _empty30;
            private long _empty31;

            // Next segment
            public CycleBufferSegment Next;
            private long _empty32;
            private long _empty33;
            private long _empty34;
            private long _empty35;
            private long _empty36;
            private long _empty37;
            private long _empty38;
            private long _empty39;

            public override string ToString()
            {
                return this.GetHashCode().ToString();
            }
        }

        #endregion
    }
}