#pragma once

#include "Includes.h"
#include "Canvas.h"
#include "NamedPipeClient.h"

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
		MainForm(NamedPipeClient^ pipeClient)
		{
			this->pipeClient = pipeClient;
			InitializeComponent();
			InitializeDirect2D();
		}

	protected:
		NamedPipeClient^ pipeClient = nullptr;

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

			SafeRelease(d2dFactory);
			SafeRelease(d2dRenderTarget);
			SafeRelease(d2dBrush);
			SafeRelease(dwFactory);
			SafeRelease(dwTextFormat);
		}

		[SecurityPermission(SecurityAction::Demand, Flags = SecurityPermissionFlag::UnmanagedCode)]
		virtual void WndProc(Message% m) override
		{
			// Listen for operating system messages.
			switch (m.Msg)
			{
				case WM_PAINT:
				{
					Direct2DPaint();
					this->Validate();
					break;
				}
			}
			Form::WndProc(m);
		}

		virtual void newMessage()
		{
			this->Invalidate(this->canvas->DisplayRectangle);
		}

		virtual void OnShown(EventArgs^ e) override
		{
			this->pipeClient->newMessage += gcnew NamedPipeClient::newMessageDelegate(this, &MainForm::newMessage);
		}

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;
		SkeletonViewer::Canvas^ canvas;

		/// <summary>
		/// Normally you shouldn't touch this method, but I had some problems with the designer
		/// so I manually changed this.  You should not need to touch the designer and if you do
		/// it might mess up what I wrote here.
		/// </summary>
		void InitializeComponent(void)
		{
			this->SuspendLayout();

			// 
			// label1
			//
			this->canvas = (gcnew SkeletonViewer::Canvas());
			this->canvas->Name = L"Canvas";
			this->canvas->Location = System::Drawing::Point(50, 50);
			this->canvas->Size = System::Drawing::Size(500, 500);
			this->canvas->TabIndex = 0;
			// 
			// MainForm
			// 
			this->Name = L"MainForm";
			this->Text = L"MainForm";
			this->Padding = System::Windows::Forms::Padding(0);
			this->ClientSize = System::Drawing::Size(600, 600);
			this->components = gcnew System::ComponentModel::Container();
			this->Controls->Add(this->canvas);

			this->ResumeLayout(false);
			this->PerformLayout();
		}

		void InitializeDirect2D()
		{
			HWND hCanvas = static_cast<HWND>(this->canvas->Handle.ToPointer());
			RECT rc;
			GetWindowRect(hCanvas, &rc);
			D2D1_SIZE_U canvasSize = D2D1::SizeU(rc.right - rc.left, rc.bottom - rc.top);

			// Setup Direct2D
			ID2D1Factory* d2dFactory = nullptr;
			ID2D1HwndRenderTarget* d2dRenderTarget = nullptr;
			ID2D1SolidColorBrush* d2dBrush = nullptr;
			D2D1CreateFactory(D2D1_FACTORY_TYPE_SINGLE_THREADED, &d2dFactory);
			d2dFactory->CreateHwndRenderTarget(D2D1::RenderTargetProperties(), D2D1::HwndRenderTargetProperties(hCanvas, canvasSize), &d2dRenderTarget);
			d2dRenderTarget->CreateSolidColorBrush(D2D1::ColorF(0.27f, 0.75f, 0.27f), &d2dBrush);
			this->d2dFactory = d2dFactory;
			this->d2dRenderTarget = d2dRenderTarget;
			this->d2dBrush = d2dBrush;

			// Setup DirectWrite
			IDWriteFactory* dwFactory = nullptr;
			IDWriteTextFormat* dwTextFormat = nullptr;
			DWriteCreateFactory(DWRITE_FACTORY_TYPE_SHARED, __uuidof(IDWriteFactory),  reinterpret_cast<IUnknown**>(&dwFactory));
			dwFactory->CreateTextFormat(L"Courier", NULL, DWRITE_FONT_WEIGHT_REGULAR, DWRITE_FONT_STYLE_NORMAL, DWRITE_FONT_STRETCH_NORMAL, 20.0, L"en-us", &dwTextFormat);
			this->dwFactory = dwFactory;
			this->dwTextFormat = dwTextFormat;
		}

		System::Void Direct2DPaint();
	};
}
