// SkeletonViewer.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "SkeletonViewer.h"

#define MAX_LOADSTRING 100
#define BUF_SIZE 255

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name

ID2D1Factory* d2dFactory = nullptr;
ID2D1HwndRenderTarget* d2dRenderTarget = nullptr;
ID2D1SolidColorBrush* d2dBrush = nullptr;
IDWriteFactory* dwFactory = nullptr;
IDWriteTextFormat* dwTextFormat = nullptr;

HANDLE hPipe;
LPWSTR lpszPipename = TEXT("\\\\.\\pipe\\anubis-pipe");
OVERLAPPED overlapped;
CRITICAL_SECTION msgLock;
std::wstring msg = L"";
char msgBuf[BUF_SIZE];

// Forward declarations of functions included in this code module:
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
VOID WINAPI ReadLoop(DWORD dwErr, DWORD cbBytesRead, LPOVERLAPPED lpOverLap);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
	hInst = hInstance; // Store instance handle in our global variable

    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // Initialize global strings
    LoadStringW(hInst, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInst, IDC_SKELETONVIEWER, szWindowClass, MAX_LOADSTRING);
	
	//Register Window Class
	WNDCLASSEXW wcex;
	wcex.cbSize = sizeof(WNDCLASSEX);
	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInst;
	wcex.hIcon = LoadIcon(hInst, MAKEINTRESOURCE(IDI_SKELETONVIEWER));
	wcex.hCursor = LoadCursor(nullptr, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = MAKEINTRESOURCEW(IDC_SKELETONVIEWER);
	wcex.lpszClassName = szWindowClass;
	wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));
	RegisterClassExW(&wcex);

    // Perform application initialization:
	HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_TILEDWINDOW ^ WS_SIZEBOX ^ WS_MAXIMIZEBOX, CW_USEDEFAULT, CW_USEDEFAULT, 600, 600, nullptr, nullptr, hInst, nullptr);
	RECT rc;
	GetClientRect(hWnd, &rc);
	HWND hCanvas = CreateWindow(L"Static", L"D2DCanvas", WS_CHILD | WS_VISIBLE | SS_BLACKFRAME, 25, 25, rc.right - 50, rc.bottom - 50, hWnd, nullptr, hInst, nullptr);
	GetWindowRect(hCanvas, &rc);
	D2D1_SIZE_U canvasSize = D2D1::SizeU(rc.right - rc.left, rc.bottom - rc.top);

	// Setup Direct2D
	D2D1CreateFactory(D2D1_FACTORY_TYPE_SINGLE_THREADED, &d2dFactory);
	d2dFactory->CreateHwndRenderTarget(D2D1::RenderTargetProperties(), D2D1::HwndRenderTargetProperties(hCanvas, canvasSize), &d2dRenderTarget);
	d2dRenderTarget->CreateSolidColorBrush(D2D1::ColorF(0.27f, 0.75f, 0.27f), &d2dBrush);
	
	// Setup DirectWrite
	DWriteCreateFactory(DWRITE_FACTORY_TYPE_SHARED, __uuidof(IDWriteFactory), reinterpret_cast<IUnknown**>(&dwFactory));
	//create a customized text format
	dwFactory->CreateTextFormat(L"Courier", NULL, DWRITE_FONT_WEIGHT_REGULAR, DWRITE_FONT_STYLE_NORMAL, DWRITE_FONT_STRETCH_NORMAL, 20.0, L"en-us", &dwTextFormat);

	// Setup Named Pipe and Message Lock
	InitializeCriticalSection(&msgLock);
	hPipe = CreateFile(lpszPipename, GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, NULL);
	if (hPipe == INVALID_HANDLE_VALUE)
	{
		ErrorPopup();
		return 0;
	}
	DWORD mode = PIPE_READMODE_MESSAGE;
	if (!SetNamedPipeHandleState(hPipe, &mode, NULL, NULL))
	{
		ErrorPopup();
		return 0;
	}
	ReadLoop(0, 0, &overlapped);

	// Show Window
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	// Main message loop:
	HACCEL hAccelTable = LoadAccelerators(hInst, MAKEINTRESOURCE(IDC_SKELETONVIEWER));
    MSG msg;
    while (GetMessage(&msg, nullptr, 0, 0))
    {
		SleepEx(0, TRUE);
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
		case WM_COMMAND:
		{
			int wmId = LOWORD(wParam);
			// Parse the menu selections:
			switch (wmId)
			{
				case IDM_EXIT:
					DestroyWindow(hWnd);
					break;
				default:
					return DefWindowProc(hWnd, message, wParam, lParam);
			}
			break;
		}
		case WM_PAINT:
		{
			d2dRenderTarget->BeginDraw();
			{
				d2dRenderTarget->Clear();

				D2D1_RECT_F rc = D2D1::RectF(50.0, 50.0, 500.0, 250.0);
				d2dRenderTarget->DrawRectangle(rc, d2dBrush, 1.0);

				EnterCriticalSection(&msgLock);
					std::wstring s = std::wstring(msg);
				LeaveCriticalSection(&msgLock);
				
				d2dRenderTarget->DrawText(s.c_str(), s.length(), dwTextFormat, rc, d2dBrush);
			}
			d2dRenderTarget->EndDraw();
			break;
		}
		case WM_DESTROY:
		{
			PostQuitMessage(0);
			break;
		}
		default:
		    return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}

VOID CALLBACK ReadLoop(DWORD dwErr, DWORD cbBytesRead, LPOVERLAPPED lpOverLap)
{
	if ((dwErr == 0) && (cbBytesRead != 0))
	{
		EnterCriticalSection(&msgLock);
			std::string s1 = std::string(msgBuf, cbBytesRead);
			std::wstring s2 = std::wstring(s1.begin(), s1.end());
			msg = s2;
		LeaveCriticalSection(&msgLock);
	}

	if (dwErr != 0 || !ReadFileEx(hPipe, msgBuf, BUF_SIZE, lpOverLap, ReadLoop))
	{
		ErrorPopup();
		return;
	}
}
