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

	public ref class SkeletonDrawer
	{
	private:
		float const SCALE = 0.9f;
		float const OFFSET_X = 0.0f;
		float const OFFSET_Y = -0.2f;

		array<float>^ Head				= nullptr;
		array<float>^ ShoulderCenter	= nullptr;
		array<float>^ ShoulderLeft		= nullptr;
		array<float>^ ShoulderRight		= nullptr;
		array<float>^ ElbowLeft			= nullptr;
		array<float>^ ElbowRight		= nullptr;
		array<float>^ WristLeft			= nullptr;
		array<float>^ WristRight		= nullptr;
		array<float>^ HandLeft			= nullptr;
		array<float>^ HandRight			= nullptr;
		array<float>^ Spine				= nullptr;
		array<float>^ HipCenter			= nullptr;
		array<float>^ HipLeft			= nullptr;
		array<float>^ HipRight			= nullptr;
		array<float>^ KneeLeft			= nullptr;
		array<float>^ KneeRight			= nullptr;
		array<float>^ AnkleLeft			= nullptr;
		array<float>^ AnkleRight		= nullptr;
		array<float>^ FootLeft			= nullptr;
		array<float>^ FootRight			= nullptr;

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
		void printSkeleton(array<TextBox^>^ txtBoxes);

	public:
		SkeletonDrawer()
		{
			Head				= gcnew array<float>(2);
			ShoulderCenter		= gcnew array<float>(2);
			ShoulderLeft		= gcnew array<float>(2);
			ShoulderRight		= gcnew array<float>(2);
			ElbowLeft			= gcnew array<float>(2);
			ElbowRight			= gcnew array<float>(2);
			WristLeft			= gcnew array<float>(2);
			WristRight			= gcnew array<float>(2);
			HandLeft			= gcnew array<float>(2);
			HandRight			= gcnew array<float>(2);
			Spine				= gcnew array<float>(2);
			HipCenter			= gcnew array<float>(2);
			HipLeft				= gcnew array<float>(2);
			HipRight			= gcnew array<float>(2);
			KneeLeft			= gcnew array<float>(2);
			KneeRight			= gcnew array<float>(2);
			AnkleLeft			= gcnew array<float>(2);
			AnkleRight			= gcnew array<float>(2);
			FootLeft			= gcnew array<float>(2);
			FootRight			= gcnew array<float>(2);

			zeroSkeleton();
		}

		void parseAndDraw(String^ msg, array<TextBox^>^ txtBoxes, ID2D1HwndRenderTarget* d2dRenderTarget, ID2D1SolidColorBrush* d2dBrush, RECT bounds)
		{
			if (!parseMessage(msg, bounds))
				zeroSkeleton();
			drawSkeleton(d2dRenderTarget, d2dBrush);
			printSkeleton(txtBoxes);
		}
	};
}