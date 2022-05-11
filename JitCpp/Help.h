#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;

const int DATA_CAPACITY = 1024;

[StructLayout(LayoutKind::Explicit, Size = 64)]
value struct EmptySpace
{
	[FieldOffset(0)]
	int _empty;
};
