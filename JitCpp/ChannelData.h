#pragma once
#include "CycleBuffer.h"|
#include "Help.h"

namespace JitCpp
{
	generic <typename T> ref class ChannelData sealed
	{
	public:
		ChannelData(int capacity);
		array<CycleBuffer<T>^>^ Storage;
	private:
		EmptySpace _empty00;
	public: 
		int WriterOperation;
	private:
		EmptySpace _empty01;
	};
}



