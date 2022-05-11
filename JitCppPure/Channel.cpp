#include "pch.h"
#include <iostream>
#include "Channel.h"
//#include "ChannelData.h"
#include "ChannelWorker.h"

using namespace JitCpp;

generic <typename T>
Channel<T>::Channel()
{
	Initialise(DEFAULT_SEGMENT_CAPACITY);
}

generic <typename T>
Channel<T>::Channel(int capacity)
{
	Initialise(capacity);
}

generic <typename T>
Channel<T>::~Channel()
{
	delete _worker;
}

generic <typename T>
void Channel<T>::Add(T value)
{
    //auto channel = _channel;
    //auto operation = channel->WriterOperation;

    //channel->WriterOperation++;

    //auto data = channel->Storage[operation % DATA_CAPACITY];
    //auto seg = data->Writer;
    //auto pos = seg->WriterPosition;

    //seg->WriterMessages[pos] = value;
}

generic <typename T>
void Channel<T>::Initialise(int capacity)
{
	//_capacity = capacity;
	//_worker   = new ChannelWorker;
 //   _channel  = gcnew ChannelData<T>(capacity);
}

