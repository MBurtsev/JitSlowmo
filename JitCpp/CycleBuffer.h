#pragma once
#include "CycleBufferSegment.h"
#include "Help.h"

namespace JitCpp
{
	generic <typename T> ref class CycleBuffer sealed
	{
	public:
		CycleBuffer(int capacity);
		CycleBufferSegment<T>^ Head;
	private:
		EmptySpace _empty00;
	public:
		CycleBufferSegment<T>^ Reader;
	private:
		EmptySpace _empty01;
	public:
		CycleBufferSegment<T>^ Writer;
	private:
		EmptySpace _empty02;
	};
}