#include "SkeletonDrawer.h"

using namespace SkeletonViewer;

bool SkeletonDrawer::parseMessage(String^ msg)
{
	try
	{
		array<String^>^ jointParts = msg->Split(String(" ").ToCharArray());
		if (jointParts->Length != 40)
			return false;
		Head[0] = Double::Parse(jointParts[0]);
		Head[1] = Double::Parse(jointParts[1]);
		SpineShoulder[0] = Double::Parse(jointParts[2]);
		SpineShoulder[1] = Double::Parse(jointParts[3]);
		SpineMiddle[0] = Double::Parse(jointParts[4]);
		SpineMiddle[1] = Double::Parse(jointParts[5]);
		SpineBase[0] = Double::Parse(jointParts[6]);
		SpineBase[1] = Double::Parse(jointParts[7]);
		ShoulderLeft[0] = Double::Parse(jointParts[8]);
		ShoulderLeft[1] = Double::Parse(jointParts[9]);
		ShoulderRight[0] = Double::Parse(jointParts[10]);
		ShoulderRight[1] = Double::Parse(jointParts[11]);
		ElbowLeft[0] = Double::Parse(jointParts[12]);
		ElbowLeft[1] = Double::Parse(jointParts[13]);
		ElbowRight[0] = Double::Parse(jointParts[14]);
		ElbowRight[1] = Double::Parse(jointParts[15]);
		WristLeft[0] = Double::Parse(jointParts[16]);
		WristLeft[1] = Double::Parse(jointParts[17]);
		WristRight[0] = Double::Parse(jointParts[18]);
		WristRight[1] = Double::Parse(jointParts[19]);
		HandLeft[0] = Double::Parse(jointParts[20]);
		HandLeft[1] = Double::Parse(jointParts[21]);
		HandRight[0] = Double::Parse(jointParts[22]);
		HandRight[1] = Double::Parse(jointParts[23]);
		HipLeft[0] = Double::Parse(jointParts[24]);
		HipLeft[1] = Double::Parse(jointParts[25]);
		HipRight[0] = Double::Parse(jointParts[26]);
		HipRight[1] = Double::Parse(jointParts[27]);
		KneeLeft[0] = Double::Parse(jointParts[28]);
		KneeLeft[1] = Double::Parse(jointParts[29]);
		KneeRight[0] = Double::Parse(jointParts[30]);
		KneeRight[1] = Double::Parse(jointParts[31]);
		AnkleLeft[0] = Double::Parse(jointParts[32]);
		AnkleLeft[1] = Double::Parse(jointParts[33]);
		AnkleRight[0] = Double::Parse(jointParts[34]);
		AnkleRight[1] = Double::Parse(jointParts[35]);
		FootLeft[0] = Double::Parse(jointParts[36]);
		FootLeft[1] = Double::Parse(jointParts[37]);
		FootRight[0] = Double::Parse(jointParts[38]);
		FootRight[1] = Double::Parse(jointParts[39]);
	}
	catch (Exception^ e)
	{
		return false;
	}
	return true;
}

void SkeletonDrawer::drawSkeleton(ID2D1HwndRenderTarget* d2dRenderTarget, ID2D1SolidColorBrush* d2dBrush)
{
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(Head[0], Head[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(SpineShoulder[0], SpineShoulder[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(SpineMiddle[0], SpineMiddle[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(SpineBase[0], SpineBase[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(ShoulderLeft[0], ShoulderLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(ShoulderRight[0], ShoulderRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(ElbowLeft[0], ElbowLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(ElbowRight[0], ElbowRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(WristLeft[0], WristLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(WristRight[0], WristRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(HandLeft[0], HandLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(HandRight[0], HandRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(HipLeft[0], HipLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(HipRight[0], HipRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(KneeLeft[0], KneeLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(KneeRight[0], KneeRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(AnkleLeft[0], AnkleLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(AnkleRight[0], AnkleRight[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(FootLeft[0], FootLeft[1]), d2dBrush, 3.0);
	d2dRenderTarget->DrawLine(D2D1::Point2F(0.0, 0.0), D2D1::Point2F(FootRight[0], FootRight[1]), d2dBrush, 3.0);
}
