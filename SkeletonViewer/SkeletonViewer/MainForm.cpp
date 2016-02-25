#include "MainForm.h"

using namespace SkeletonViewer;

Void MainForm::Direct2DPaint()
{
	d2dRenderTarget->BeginDraw();
	{
		d2dRenderTarget->Clear();

		skeleton->parseAndDraw(this->pipeClient->Message, txtBoxes, d2dRenderTarget, d2dBrush, *bounds);

		//raw text output
		std::wstring s = msclr::interop::marshal_as<std::wstring>(this->pipeClient->ConnectionMessage);
		D2D1_RECT_F d2drc = D2D1::RectF((float)bounds->left, (float)bounds->top, (float)bounds->right, (float)bounds->bottom);
		d2dRenderTarget->DrawText(s.c_str(), s.length(), dwTextFormat, d2drc, d2dBrush);
	}
	d2dRenderTarget->EndDraw();
}
