#include "pch.h"
#include "ChannelData.h"
#include "CycleBuffer.h"

using namespace JitCpp;

generic<typename T>
ChannelData<T>::ChannelData(int capacity)
{
	Storage = gcnew array<CycleBuffer<T>^>(DATA_CAPACITY);

	for (int i = 0; i < DATA_CAPACITY; ++i)
	{
		Storage[i] = gcnew CycleBuffer<T>(capacity);
	}
}

		

