#include "SkeletonDrawer.h"

using namespace SkeletonViewer;

bool SkeletonDrawer::parseMessage(String^ msg, RECT bounds)
{
	try
	{
		array<String^>^ jointParts = msg->Split(String(" ").ToCharArray(), StringSplitOptions::RemoveEmptyEntries);
		if (jointParts->Length != 40)
			return false;
		
		float scalex = ((bounds.right - bounds.left) / 2.0f);
		float scaley = ((bounds.bottom - bounds.top) / 2.0f);
		float midx = scalex + bounds.left;
		float midy = scaley + bounds.top;
		midx += OFFSET_X * scalex;
		midy += OFFSET_Y * scaley;
		scalex *=  SCALE;
		scaley *= -SCALE;

		Head[0]					 = (float::Parse(jointParts[0])  * scalex)	+ midx		;
		Head[1]					 = (float::Parse(jointParts[1])  * scaley)	+ midy		;
		ShoulderCenter[0]		 = (float::Parse(jointParts[2])  * scalex)	+ midx		;
		ShoulderCenter[1]		 = (float::Parse(jointParts[3])  * scaley)	+ midy		;
		ShoulderLeft[0]			 = (float::Parse(jointParts[4])  * scalex)	+ midx		;
		ShoulderLeft[1]			 = (float::Parse(jointParts[5])  * scaley)	+ midy		;
		ShoulderRight[0]		 = (float::Parse(jointParts[6])  * scalex)	+ midx		;
		ShoulderRight[1]		 = (float::Parse(jointParts[7])  * scaley)	+ midy		;
		ElbowLeft[0]			 = (float::Parse(jointParts[8])  * scalex)	+ midx		;
		ElbowLeft[1]			 = (float::Parse(jointParts[9])  * scaley)	+ midy		;
		ElbowRight[0]			 = (float::Parse(jointParts[10]) * scalex)	+ midx		;
		ElbowRight[1]			 = (float::Parse(jointParts[11]) * scaley)	+ midy		;
		WristLeft[0]			 = (float::Parse(jointParts[12]) * scalex)	+ midx		;
		WristLeft[1]			 = (float::Parse(jointParts[13]) * scaley)	+ midy		;
		WristRight[0]			 = (float::Parse(jointParts[14]) * scalex)	+ midx		;
		WristRight[1]			 = (float::Parse(jointParts[15]) * scaley)	+ midy		;
		HandLeft[0]				 = (float::Parse(jointParts[16]) * scalex)	+ midx		;
		HandLeft[1]				 = (float::Parse(jointParts[17]) * scaley)	+ midy		;
		HandRight[0]			 = (float::Parse(jointParts[18]) * scalex)	+ midx		;
		HandRight[1]			 = (float::Parse(jointParts[19]) * scaley)	+ midy		;
		Spine[0]				 = (float::Parse(jointParts[20]) * scalex)	+ midx		;
		Spine[1]				 = (float::Parse(jointParts[21]) * scaley) + midy		;
		HipCenter[0]			 = (float::Parse(jointParts[22]) * scalex)	+ midx		;
		HipCenter[1]			 = (float::Parse(jointParts[23]) * scaley)	+ midy		;
		HipLeft[0]				 = (float::Parse(jointParts[24]) * scalex)	+ midx		;
		HipLeft[1]				 = (float::Parse(jointParts[25]) * scaley)	+ midy		;
		HipRight[0]				 = (float::Parse(jointParts[26]) * scalex)	+ midx		;
		HipRight[1]				 = (float::Parse(jointParts[27]) * scaley)	+ midy		;
		KneeLeft[0]				 = (float::Parse(jointParts[28]) * scalex)	+ midx		;
		KneeLeft[1]				 = (float::Parse(jointParts[29]) * scaley)	+ midy		;
		KneeRight[0]			 = (float::Parse(jointParts[30]) * scalex)	+ midx		;
		KneeRight[1]			 = (float::Parse(jointParts[31]) * scaley)	+ midy		;
		AnkleLeft[0]			 = (float::Parse(jointParts[32]) * scalex)	+ midx		;
		AnkleLeft[1]			 = (float::Parse(jointParts[33]) * scaley)	+ midy		;
		AnkleRight[0]			 = (float::Parse(jointParts[34]) * scalex)	+ midx		;
		AnkleRight[1]			 = (float::Parse(jointParts[35]) * scaley)	+ midy		;
		FootLeft[0]				 = (float::Parse(jointParts[36]) * scalex)	+ midx		;
		FootLeft[1]				 = (float::Parse(jointParts[37]) * scaley)	+ midy		;
		FootRight[0]			 = (float::Parse(jointParts[38]) * scalex)	+ midx		;
		FootRight[1]			 = (float::Parse(jointParts[39]) * scaley)	+ midy		;
	}
	catch (Exception^)
	{
		return false;
	}
	return true;
}

void SkeletonDrawer::drawSkeleton(ID2D1HwndRenderTarget* d2dRenderTarget, ID2D1SolidColorBrush* d2dBrush)
{
	d2dRenderTarget->DrawLine(D2D1::Point2F(Spine[0], Spine[1]), D2D1::Point2F(HipCenter[0], HipCenter[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(Spine[0], Spine[1]), D2D1::Point2F(ShoulderCenter[0], ShoulderCenter[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(ShoulderCenter[0], ShoulderCenter[1]), D2D1::Point2F(Head[0], Head[1]), d2dBrush, 3.0);

	d2dRenderTarget->DrawLine(D2D1::Point2F(ShoulderCenter[0], ShoulderCenter[1]), D2D1::Point2F(ShoulderLeft[0], ShoulderLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(ShoulderCenter[0], ShoulderCenter[1]), D2D1::Point2F(ShoulderRight[0], ShoulderRight[1]), d2dBrush, 3.0);

	d2dRenderTarget->DrawLine(D2D1::Point2F(ShoulderLeft[0], ShoulderLeft[1]), D2D1::Point2F(ElbowLeft[0], ElbowLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(ShoulderRight[0], ShoulderRight[1]), D2D1::Point2F(ElbowRight[0], ElbowRight[1]), d2dBrush, 3.0);

	d2dRenderTarget->DrawLine(D2D1::Point2F(ElbowLeft[0], ElbowLeft[1]), D2D1::Point2F(WristLeft[0], WristLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(ElbowRight[0], ElbowRight[1]), D2D1::Point2F(WristRight[0], WristRight[1]), d2dBrush, 3.0);

	d2dRenderTarget->DrawLine(D2D1::Point2F(WristLeft[0], WristLeft[1]), D2D1::Point2F(HandLeft[0], HandLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(WristRight[0], WristRight[1]), D2D1::Point2F(HandRight[0], HandRight[1]), d2dBrush, 3.0);

	d2dRenderTarget->DrawLine(D2D1::Point2F(HipCenter[0], HipCenter[1]), D2D1::Point2F(HipLeft[0], HipLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(HipCenter[0], HipCenter[1]), D2D1::Point2F(HipRight[0], HipRight[1]), d2dBrush, 3.0);

	d2dRenderTarget->DrawLine(D2D1::Point2F(HipLeft[0], HipLeft[1]), D2D1::Point2F(KneeLeft[0], KneeLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(HipRight[0], HipRight[1]), D2D1::Point2F(KneeRight[0], KneeRight[1]), d2dBrush, 3.0);

	d2dRenderTarget->DrawLine(D2D1::Point2F(KneeLeft[0], KneeLeft[1]), D2D1::Point2F(AnkleLeft[0], AnkleLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(KneeRight[0], KneeRight[1]), D2D1::Point2F(AnkleRight[0], AnkleRight[1]), d2dBrush, 3.0);

	d2dRenderTarget->DrawLine(D2D1::Point2F(AnkleLeft[0], AnkleLeft[1]), D2D1::Point2F(FootLeft[0], FootLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(AnkleRight[0], AnkleRight[1]), D2D1::Point2F(FootRight[0], FootRight[1]), d2dBrush, 3.0);
}
