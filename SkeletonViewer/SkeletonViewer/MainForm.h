#pragma once
// Windows Header Files:
#include <windows.h>

// C RunTime Header Files
#include <stdlib.h>
#include <malloc.h>
#include <memory.h>
#include <tchar.h>
#include <math.h>
#include <string>

// Direct2D
#include <d2d1.h>
#include <d2d1helper.h>
#include <dwrite.h>
#include <wincodec.h>
#pragma comment ( lib, "d2d1.lib" )
#pragma comment ( lib, "dwrite.lib" )

#include "Canvas.h"

namespace SkeletonViewer {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Security::Permissions;

	/// <summary>
	/// Summary for MainForm
	/// </summary>
	public ref class MainForm : public System::Windows::Forms::Form
	{
	public:
		MainForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		ID2D1Factory* d2dFactory = nullptr;
		ID2D1HwndRenderTarget* d2dRenderTarget = nullptr;
		ID2D1SolidColorBrush* d2dBrush = nullptr;
		IDWriteFactory* dwFactory = nullptr;
		IDWriteTextFormat* dwTextFormat = nullptr;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MainForm()
		{
			if (components)
			{
				delete components;
			}
		}

		[SecurityPermission(SecurityAction::Demand, Flags = SecurityPermissionFlag::UnmanagedCode)]
		virtual void WndProc(Message% m) override
		{

			// Listen for operating system messages.
			switch (m.Msg)
			{
			case WM_PAINT:
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
			Form::WndProc(m);
		}

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;
		SkeletonViewer::Canvas^ canvas;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->SuspendLayout();
			// 
			// label1
			//
			this->canvas = (gcnew SkeletonViewer::Canvas());
			this->canvas->AutoSize = true;
			this->canvas->Location = System::Drawing::Point(19, 18);
			this->canvas->Name = L"Canvas";
			this->canvas->Size = System::Drawing::Size(46, 17);
			this->canvas->TabIndex = 0;
			// 
			// MainForm
			// 
			this->components = gcnew System::ComponentModel::Container();
			this->Size = System::Drawing::Size(300, 300);
			this->Padding = System::Windows::Forms::Padding(0);
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(282, 253);
			this->Controls->Add(this->canvas);
			this->Name = L"MainForm";
			this->Text = L"MainForm";
			this->ResumeLayout(false);
			this->PerformLayout();
		}

		void InitializeDirect2D()
		{
			RECT rc;
			HWND hCanvas = static_cast<HWND>(canvas->Handle.ToPointer());
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
		}
#pragma endregion
	};
}
