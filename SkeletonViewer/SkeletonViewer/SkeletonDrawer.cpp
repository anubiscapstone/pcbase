#include "SkeletonDrawer.h"

using namespace SkeletonViewer;

bool SkeletonDrawer::parseMessage(String^ msg)
{
	try
	{
		array<String^>^ jointParts = msg->Split(String(" ").ToCharArray());
		if (jointParts->Length != 40)
			return false;
		
		D2D1_RECT_F rc = D2D1::RectF(50.0, 50.0, 450.0, 450.0);
		double midx = ((rc.right - rc.left) / 2.0) + rc.left;
		double midy = ((rc.bottom - rc.top) / 2.0) + rc.top;
		double scale = 150;

		Head[0]				 = (Double::Parse(jointParts[0])  * scale)	+ midx		;
		Head[1]				 = (Double::Parse(jointParts[1])  * -scale)	+ midy		;
		SpineShoulder[0]	 = (Double::Parse(jointParts[2])  * scale)	+ midx		;
		SpineShoulder[1]	 = (Double::Parse(jointParts[3])  * -scale)	+ midy		;
		SpineMiddle[0]		 = (Double::Parse(jointParts[4])  * scale)	+ midx		;
		SpineMiddle[1]		 = (Double::Parse(jointParts[5])  * -scale)	+ midy		;
		SpineBase[0]		 = (Double::Parse(jointParts[6])  * scale)	+ midx		;
		SpineBase[1]		 = (Double::Parse(jointParts[7])  * -scale)	+ midy		;
		ShoulderLeft[0]		 = (Double::Parse(jointParts[8])  * scale)	+ midx		;
		ShoulderLeft[1]		 = (Double::Parse(jointParts[9])  * -scale)	+ midy		;
		ShoulderRight[0]	 = (Double::Parse(jointParts[10]) * scale)	+ midx		;
		ShoulderRight[1]	 = (Double::Parse(jointParts[11]) * -scale)	+ midy		;
		ElbowLeft[0]		 = (Double::Parse(jointParts[12]) * scale)	+ midx		;
		ElbowLeft[1]		 = (Double::Parse(jointParts[13]) * -scale)	+ midy		;
		ElbowRight[0]		 = (Double::Parse(jointParts[14]) * scale)	+ midx		;
		ElbowRight[1]		 = (Double::Parse(jointParts[15]) * -scale)	+ midy		;
		WristLeft[0]		 = (Double::Parse(jointParts[16]) * scale)	+ midx		;
		WristLeft[1]		 = (Double::Parse(jointParts[17]) * -scale)	+ midy		;
		WristRight[0]		 = (Double::Parse(jointParts[18]) * scale)	+ midx		;
		WristRight[1]		 = (Double::Parse(jointParts[19]) * -scale)	+ midy		;
		HandLeft[0]			 = (Double::Parse(jointParts[20]) * scale)	+ midx		;
		HandLeft[1]			 = (Double::Parse(jointParts[21]) * -scale) + midy		;
		HandRight[0]		 = (Double::Parse(jointParts[22]) * scale)	+ midx		;
		HandRight[1]		 = (Double::Parse(jointParts[23]) * -scale)	+ midy		;
		HipLeft[0]			 = (Double::Parse(jointParts[24]) * scale)	+ midx		;
		HipLeft[1]			 = (Double::Parse(jointParts[25]) * -scale)	+ midy		;
		HipRight[0]			 = (Double::Parse(jointParts[26]) * scale)	+ midx		;
		HipRight[1]			 = (Double::Parse(jointParts[27]) * -scale)	+ midy		;
		KneeLeft[0]			 = (Double::Parse(jointParts[28]) * scale)	+ midx		;
		KneeLeft[1]			 = (Double::Parse(jointParts[29]) * -scale)	+ midy		;
		KneeRight[0]		 = (Double::Parse(jointParts[30]) * scale)	+ midx		;
		KneeRight[1]		 = (Double::Parse(jointParts[31]) * -scale)	+ midy		;
		AnkleLeft[0]		 = (Double::Parse(jointParts[32]) * scale)	+ midx		;
		AnkleLeft[1]		 = (Double::Parse(jointParts[33]) * -scale)	+ midy		;
		AnkleRight[0]		 = (Double::Parse(jointParts[34]) * scale)	+ midx		;
		AnkleRight[1]		 = (Double::Parse(jointParts[35]) * -scale)	+ midy		;
		FootLeft[0]			 = (Double::Parse(jointParts[36]) * scale)	+ midx		;
		FootLeft[1]			 = (Double::Parse(jointParts[37]) * -scale)	+ midy		;
		FootRight[0]		 = (Double::Parse(jointParts[38]) * scale)	+ midx		;
		FootRight[1]		 = (Double::Parse(jointParts[39]) * -scale)	+ midy		;
	}
	catch (Exception^ e)
	{
		return false;
	}
	return true;
}

void SkeletonDrawer::drawSkeleton(ID2D1HwndRenderTarget* d2dRenderTarget, ID2D1SolidColorBrush* d2dBrush)
{
	D2D1_RECT_F rc = D2D1::RectF(50.0, 50.0, 450.0, 450.0);
	double midx = ((rc.right - rc.left) / 2.0) + rc.left;
	double midy = ((rc.bottom - rc.top) / 2.0) + rc.top;

	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(Head[0], Head[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(SpineShoulder[0], SpineShoulder[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(SpineMiddle[0], SpineMiddle[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(SpineBase[0], SpineBase[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(ShoulderLeft[0], ShoulderLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(ShoulderRight[0], ShoulderRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(ShoulderLeft[0], ShoulderLeft[1]), D2D1::Point2F(ElbowLeft[0], ElbowLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(ShoulderRight[0], ShoulderRight[1]), D2D1::Point2F(ElbowRight[0], ElbowRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(WristLeft[0], WristLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(WristRight[0], WristRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(ElbowLeft[0], ElbowLeft[1]), D2D1::Point2F(HandLeft[0], HandLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(ElbowRight[0], ElbowRight[1]), D2D1::Point2F(HandRight[0], HandRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(HipLeft[0], HipLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(HipRight[0], HipRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(KneeLeft[0], KneeLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(KneeRight[0], KneeRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(AnkleLeft[0], AnkleLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(midx, midy), D2D1::Point2F(AnkleRight[0], AnkleRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(AnkleLeft[0], AnkleLeft[1]), D2D1::Point2F(FootLeft[0], FootLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(AnkleRight[0], AnkleRight[1]), D2D1::Point2F(FootRight[0], FootRight[1]), d2dBrush, 3.0);
}
