#pragma once

// Windows Header Files:
#include <windows.h>
#pragma comment ( lib, "user32.lib" )

// C RunTime Header Files
#include <stdlib.h>
#include <malloc.h>
#include <memory.h>
#include <tchar.h>
#include <math.h>
#include <string>

// CLR Header Files
#include <msclr\marshal.h>
#include <msclr\marshal_cppstd.h>
#include <msclr\lock.h>

// Direct2D Header Files
#include <d2d1.h>
#include <d2d1helper.h>
#include <dwrite.h>
#include <wincodec.h>
#pragma comment ( lib, "d2d1.lib" )
#pragma comment ( lib, "dwrite.lib" )

template<class Interface>
inline void SafeRelease(Interface* pInterfaceToRelease)
{
	if (pInterfaceToRelease != nullptr)
	{
		pInterfaceToRelease->Release();
		pInterfaceToRelease = nullptr;
	}
}