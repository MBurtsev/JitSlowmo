#include "pch.h"
#include "CycleBuffer.h"
#include "CycleBufferSegment.h"

using namespace JitCpp;

generic <typename T>
CycleBuffer<T>::CycleBuffer(int capacity)
{
	auto seg = gcnew CycleBufferSegment<T>(capacity);

	Head   = seg;
	Reader = seg;
	Writer = seg;
}


