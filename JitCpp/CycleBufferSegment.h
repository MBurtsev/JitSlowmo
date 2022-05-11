#pragma once
#include "Help.h"

namespace JitCpp
{
	generic <typename T> ref class CycleBufferSegment sealed
	{
	public:
		CycleBufferSegment(int capacity);
		int ReaderPosition;
	private:
		EmptySpace _empty00;
	public:
		array<T>^ ReaderMessages;
	private:
		EmptySpace _empty01;
	public:
		int WriterPosition;
	private:
		EmptySpace _empty02;
	public:
		array<T>^ WriterMessages;
	private:
		EmptySpace _empty03;
	public:
		CycleBufferSegment<T>^ Next;
	private:
		EmptySpace _empty04;
	};
}