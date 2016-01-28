#pragma once

#include "Includes.h"
namespace SkeletonViewer
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	ref class SkeletonDrawer
	{
	private:
		array<double>^ Head = nullptr;
		array<double>^ SpineShoulder = nullptr;
		array<double>^ SpineMiddle = nullptr;
		array<double>^ SpineBase = nullptr;
		array<double>^ ShoulderLeft = nullptr;
		array<double>^ ShoulderRight = nullptr;
		array<double>^ ElbowLeft = nullptr;
		array<double>^ ElbowRight = nullptr;
		array<double>^ WristLeft = nullptr;
		array<double>^ WristRight = nullptr;
		array<double>^ HandLeft = nullptr;
		array<double>^ HandRight = nullptr;
		array<double>^ HipLeft = nullptr;
		array<double>^ HipRight = nullptr;
		array<double>^ KneeLeft = nullptr;
		array<double>^ KneeRight = nullptr;
		array<double>^ AnkleLeft = nullptr;
		array<double>^ AnkleRight = nullptr;
		array<double>^ FootLeft = nullptr;
		array<double>^ FootRight = nullptr;

		void useDefaultSkeleton()
		{
			Head[0] = 90.0;
			Head[1] = 90.0;
			SpineShoulder[0] = 90.0;
			SpineShoulder[1] = 90.0;
			SpineMiddle[0] = 90.0;
			SpineMiddle[1] = 90.0;
			SpineBase[0] = 90.0;
			SpineBase[1] = 90.0;
			ShoulderLeft[0] = 90.0;
			ShoulderLeft[1] = 90.0;
			ShoulderRight[0] = 90.0;
			ShoulderRight[1] = 90.0;
			ElbowLeft[0] = 90.0;
			ElbowLeft[1] = 90.0;
			ElbowRight[0] = 90.0;
			ElbowRight[1] = 90.0;
			WristLeft[0] = 90.0;
			WristLeft[1] = 90.0;
			WristRight[0] = 90.0;
			WristRight[1] = 90.0;
			HandLeft[0] = 90.0;
			HandLeft[1] = 90.0;
			HandRight[0] = 90.0;
			HandRight[1] = 90.0;
			HipLeft[0] = 90.0;
			HipLeft[1] = 90.0;
			HipRight[0] = 90.0;
			HipRight[1] = 90.0;
			KneeLeft[0] = 90.0;
			KneeLeft[1] = 90.0;
			KneeRight[0] = 90.0;
			KneeRight[1] = 90.0;
			AnkleLeft[0] = 90.0;
			AnkleLeft[1] = 90.0;
			AnkleRight[0] = 90.0;
			AnkleRight[1] = 90.0;
			FootLeft[0] = 90.0;
			FootLeft[1] = 90.0;
			FootRight[0] = 90.0;
			FootRight[1] = 90.0;
		}

		bool parseMessage(String^ msg);
		void drawSkeleton(ID2D1HwndRenderTarget* d2dRenderTarget, ID2D1SolidColorBrush* d2dBrush);

	public:
		SkeletonDrawer()
		{
			Head = gcnew array<double>(2);
			SpineShoulder = gcnew array<double>(2);
			SpineMiddle = gcnew array<double>(2);
			SpineBase = gcnew array<double>(2);
			ShoulderLeft = gcnew array<double>(2);
			ShoulderRight = gcnew array<double>(2);
			ElbowLeft = gcnew array<double>(2);
			ElbowRight = gcnew array<double>(2);
			WristLeft = gcnew array<double>(2);
			WristRight = gcnew array<double>(2);
			HandLeft = gcnew array<double>(2);
			HandRight = gcnew array<double>(2);
			HipLeft = gcnew array<double>(2);
			HipRight = gcnew array<double>(2);
			KneeLeft = gcnew array<double>(2);
			KneeRight = gcnew array<double>(2);
			AnkleLeft = gcnew array<double>(2);
			AnkleRight = gcnew array<double>(2);
			FootLeft = gcnew array<double>(2);
			FootRight = gcnew array<double>(2);

			useDefaultSkeleton();
		}

		void parseAndDraw(String^ msg, ID2D1HwndRenderTarget* d2dRenderTarget, ID2D1SolidColorBrush* d2dBrush)
		{
			if (!parseMessage(msg))
				useDefaultSkeleton();
			drawSkeleton(d2dRenderTarget, d2dBrush);
		}
	};
}