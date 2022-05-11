#pragma once
#include "ChannelWorker.h"
#include "ChannelData.h"

using namespace System;

namespace JitCpp
{
	generic <typename T> public ref class Channel
	{
		const int DEFAULT_SEGMENT_CAPACITY = 32 * 1024;

	public:
		Channel();
		Channel(int capacity);
		void Add(T value);

	private:
		ChannelWorker* _worker;
		ChannelData<T>^ _channel;
		int _capacity;
		void Initialise(int capacity);
		~Channel();
	};
}