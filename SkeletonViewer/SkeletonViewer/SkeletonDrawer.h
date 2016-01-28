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
		double const SCALE = 0.9;
		double const OFFSET_X = 0.0;
		double const OFFSET_Y = -0.2;

		array<double>^ Head				= nullptr;
		array<double>^ ShoulderCenter	= nullptr;
		array<double>^ ShoulderLeft		= nullptr;
		array<double>^ ShoulderRight	= nullptr;
		array<double>^ ElbowLeft		= nullptr;
		array<double>^ ElbowRight		= nullptr;
		array<double>^ WristLeft		= nullptr;
		array<double>^ WristRight		= nullptr;
		array<double>^ HandLeft			= nullptr;
		array<double>^ HandRight		= nullptr;
		array<double>^ Spine			= nullptr;
		array<double>^ HipCenter		= nullptr;
		array<double>^ HipLeft			= nullptr;
		array<double>^ HipRight			= nullptr;
		array<double>^ KneeLeft			= nullptr;
		array<double>^ KneeRight		= nullptr;
		array<double>^ AnkleLeft		= nullptr;
		array<double>^ AnkleRight		= nullptr;
		array<double>^ FootLeft			= nullptr;
		array<double>^ FootRight		= nullptr;

		void zeroSkeleton()
		{
			Head[0]				= 0.0;
			Head[1]				= 0.0;
			ShoulderCenter[0]	= 0.0;
			ShoulderCenter[1]	= 0.0;
			ShoulderLeft[0]		= 0.0;
			ShoulderLeft[1]		= 0.0;
			ShoulderRight[0]	= 0.0;
			ShoulderRight[1]	= 0.0;
			ElbowLeft[0]		= 0.0;
			ElbowLeft[1]		= 0.0;
			ElbowRight[0]		= 0.0;
			ElbowRight[1]		= 0.0;
			WristLeft[0]		= 0.0;
			WristLeft[1]		= 0.0;
			WristRight[0]		= 0.0;
			WristRight[1]		= 0.0;
			HandLeft[0]			= 0.0;
			HandLeft[1]			= 0.0;
			HandRight[0]		= 0.0;
			HandRight[1]		= 0.0;
			Spine[0]			= 0.0;
			Spine[1]			= 0.0;
			HipCenter[0]		= 0.0;
			HipCenter[1]		= 0.0;
			HipLeft[0]			= 0.0;
			HipLeft[1]			= 0.0;
			HipRight[0]			= 0.0;
			HipRight[1]		    = 0.0;
			KneeLeft[0]			= 0.0;
			KneeLeft[1]			= 0.0;
			KneeRight[0]		= 0.0;
			KneeRight[1]		= 0.0;
			AnkleLeft[0]		= 0.0;
			AnkleLeft[1]		= 0.0;
			AnkleRight[0]		= 0.0;
			AnkleRight[1]		= 0.0;
			FootLeft[0]			= 0.0;
			FootLeft[1]			= 0.0;
			FootRight[0]		= 0.0;
			FootRight[1]		= 0.0;
		}

		bool parseMessage(String^ msg, RECT bounds);
		void drawSkeleton(ID2D1HwndRenderTarget* d2dRenderTarget, ID2D1SolidColorBrush* d2dBrush);

	public:
		SkeletonDrawer()
		{
			Head				= gcnew array<double>(2);
			ShoulderCenter		= gcnew array<double>(2);
			ShoulderLeft		= gcnew array<double>(2);
			ShoulderRight		= gcnew array<double>(2);
			ElbowLeft			= gcnew array<double>(2);
			ElbowRight			= gcnew array<double>(2);
			WristLeft			= gcnew array<double>(2);
			WristRight			= gcnew array<double>(2);
			HandLeft			= gcnew array<double>(2);
			HandRight			= gcnew array<double>(2);
			Spine				= gcnew array<double>(2);
			HipCenter			= gcnew array<double>(2);
			HipLeft				= gcnew array<double>(2);
			HipRight			= gcnew array<double>(2);
			KneeLeft			= gcnew array<double>(2);
			KneeRight			= gcnew array<double>(2);
			AnkleLeft			= gcnew array<double>(2);
			AnkleRight			= gcnew array<double>(2);
			FootLeft			= gcnew array<double>(2);
			FootRight			= gcnew array<double>(2);

			zeroSkeleton();
		}

		void parseAndDraw(String^ msg, ID2D1HwndRenderTarget* d2dRenderTarget, ID2D1SolidColorBrush* d2dBrush, RECT bounds)
		{
			if (!parseMessage(msg, bounds))
				zeroSkeleton();
			drawSkeleton(d2dRenderTarget, d2dBrush);
		}
	};
}