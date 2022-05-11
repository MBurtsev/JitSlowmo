#include "pch.h"
#include "CycleBufferSegment.h"

using namespace JitCpp;

generic <typename T>
CycleBufferSegment<T>::CycleBufferSegment(int capacity)
{
	array<T>^ mes = gcnew array<T>(capacity);

	ReaderMessages = mes;
	WriterMessages = mes;
	Next = nullptr;
}