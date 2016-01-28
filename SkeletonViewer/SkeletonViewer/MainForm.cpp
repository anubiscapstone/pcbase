#include "MainForm.h"

using namespace SkeletonViewer;

Void MainForm::Direct2DPaint()
{
	d2dRenderTarget->BeginDraw();
	{
		d2dRenderTarget->Clear();

		skeleton->parseAndDraw(this->pipeClient->Message, d2dRenderTarget, d2dBrush);

		std::wstring s = msclr::interop::marshal_as<std::wstring>(this->pipeClient->Message);
		D2D1_RECT_F rc = D2D1::RectF(50.0, 50.0, 450.0, 450.0);
		d2dRenderTarget->DrawText(s.c_str(), s.length(), dwTextFormat, rc, d2dBrush);
	}
	d2dRenderTarget->EndDraw();
}