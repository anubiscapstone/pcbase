#pragma once

#include "Includes.h"
#include "NamedPipeClient.h"
#include "SkeletonDrawer.h"

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
			this->skeleton = gcnew SkeletonDrawer();
			InitializeComponent();
			InitializeDirect2D();
		}

	protected:
		NamedPipeClient^ pipeClient = nullptr;
		SkeletonDrawer^ skeleton = nullptr;

		ID2D1Factory* d2dFactory = nullptr;
		ID2D1HwndRenderTarget* d2dRenderTarget = nullptr;
		ID2D1SolidColorBrush* d2dBrush = nullptr;
		IDWriteFactory* dwFactory = nullptr;
		IDWriteTextFormat* dwTextFormat = nullptr;
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::TextBox^  textBox2;
	private: System::Windows::Forms::TextBox^  textBox3;
	private: System::Windows::Forms::TextBox^  textBox4;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::Label^  label5;
	private: System::Windows::Forms::Label^  label6;
	private: System::Windows::Forms::Label^  label7;
	private: System::Windows::Forms::Label^  label8;
	private: System::Windows::Forms::TextBox^  textBox5;
	private: System::Windows::Forms::TextBox^  textBox6;
	private: System::Windows::Forms::TextBox^  textBox7;
	private: System::Windows::Forms::TextBox^  textBox8;
	private: System::Windows::Forms::Label^  label9;
	private: System::Windows::Forms::Label^  label10;
	private: System::Windows::Forms::Label^  label11;
	private: System::Windows::Forms::Label^  label12;
	private: System::Windows::Forms::TextBox^  textBox9;
	private: System::Windows::Forms::TextBox^  textBox10;
	private: System::Windows::Forms::TextBox^  textBox11;
	private: System::Windows::Forms::TextBox^  textBox12;
	private: System::Windows::Forms::Label^  label13;
	private: System::Windows::Forms::Label^  label14;
	private: System::Windows::Forms::Label^  label15;
	private: System::Windows::Forms::Label^  label16;
	private: System::Windows::Forms::TextBox^  textBox13;
	private: System::Windows::Forms::TextBox^  textBox14;
	private: System::Windows::Forms::TextBox^  textBox15;
	private: System::Windows::Forms::TextBox^  textBox16;
	private: System::Windows::Forms::Label^  label17;
	private: System::Windows::Forms::Label^  label18;
	private: System::Windows::Forms::Label^  label19;
	private: System::Windows::Forms::Label^  label20;
	private: System::Windows::Forms::TextBox^  textBox17;
	private: System::Windows::Forms::TextBox^  textBox18;
	private: System::Windows::Forms::TextBox^  textBox19;
	private: System::Windows::Forms::TextBox^  textBox20;
	private: System::Windows::Forms::Label^  label21;
	private: System::Windows::Forms::Label^  label22;
	private: System::Windows::Forms::Label^  label23;
	private: System::Windows::Forms::Label^  label24;
	private: System::Windows::Forms::TextBox^  textBox21;
	private: System::Windows::Forms::TextBox^  textBox22;
	private: System::Windows::Forms::TextBox^  textBox23;
	private: System::Windows::Forms::TextBox^  textBox24;
	private: System::Windows::Forms::Label^  label25;
	private: System::Windows::Forms::Label^  label26;
	private: System::Windows::Forms::Label^  label27;
	private: System::Windows::Forms::Label^  label28;
	private: System::Windows::Forms::TextBox^  textBox25;
	private: System::Windows::Forms::TextBox^  textBox26;
	private: System::Windows::Forms::TextBox^  textBox27;
	private: System::Windows::Forms::TextBox^  textBox28;
	private: System::Windows::Forms::Label^  label29;
	private: System::Windows::Forms::Label^  label30;
	private: System::Windows::Forms::Label^  label31;
	private: System::Windows::Forms::Label^  label32;
	private: System::Windows::Forms::TextBox^  textBox29;
	private: System::Windows::Forms::TextBox^  textBox30;
	private: System::Windows::Forms::TextBox^  textBox31;
	private: System::Windows::Forms::TextBox^  textBox32;
	private: System::Windows::Forms::Label^  label33;
	private: System::Windows::Forms::Label^  label34;
	private: System::Windows::Forms::Label^  label35;
	private: System::Windows::Forms::Label^  label36;
	private: System::Windows::Forms::TextBox^  textBox33;
	private: System::Windows::Forms::TextBox^  textBox34;
	private: System::Windows::Forms::TextBox^  textBox35;
	private: System::Windows::Forms::TextBox^  textBox36;
	private: System::Windows::Forms::Label^  label37;
	private: System::Windows::Forms::Label^  label38;
	private: System::Windows::Forms::Label^  label39;
	private: System::Windows::Forms::Label^  label40;
	private: System::Windows::Forms::TextBox^  textBox37;
	private: System::Windows::Forms::TextBox^  textBox38;
	private: System::Windows::Forms::TextBox^  textBox39;
	private: System::Windows::Forms::TextBox^  textBox40;

	private: array<System::Windows::Forms::TextBox^>^ txtBoxes;
	protected:

		RECT* bounds = nullptr;

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

		virtual void OnPaint(PaintEventArgs^ e) override
		{
			Direct2DPaint();
		}

		virtual void newMessage()
		{
			this->Invalidate();
		}

		virtual void OnShown(EventArgs^ e) override
		{
			this->pipeClient->newMessage += gcnew NamedPipeClient::newMessageDelegate(this, &MainForm::newMessage);
			this->Invalidate();
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
			this->canvas = (gcnew SkeletonViewer::Canvas());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->textBox2 = (gcnew System::Windows::Forms::TextBox());
			this->textBox3 = (gcnew System::Windows::Forms::TextBox());
			this->textBox4 = (gcnew System::Windows::Forms::TextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->label7 = (gcnew System::Windows::Forms::Label());
			this->label8 = (gcnew System::Windows::Forms::Label());
			this->textBox5 = (gcnew System::Windows::Forms::TextBox());
			this->textBox6 = (gcnew System::Windows::Forms::TextBox());
			this->textBox7 = (gcnew System::Windows::Forms::TextBox());
			this->textBox8 = (gcnew System::Windows::Forms::TextBox());
			this->label9 = (gcnew System::Windows::Forms::Label());
			this->label10 = (gcnew System::Windows::Forms::Label());
			this->label11 = (gcnew System::Windows::Forms::Label());
			this->label12 = (gcnew System::Windows::Forms::Label());
			this->textBox9 = (gcnew System::Windows::Forms::TextBox());
			this->textBox10 = (gcnew System::Windows::Forms::TextBox());
			this->textBox11 = (gcnew System::Windows::Forms::TextBox());
			this->textBox12 = (gcnew System::Windows::Forms::TextBox());
			this->label13 = (gcnew System::Windows::Forms::Label());
			this->label14 = (gcnew System::Windows::Forms::Label());
			this->label15 = (gcnew System::Windows::Forms::Label());
			this->label16 = (gcnew System::Windows::Forms::Label());
			this->textBox13 = (gcnew System::Windows::Forms::TextBox());
			this->textBox14 = (gcnew System::Windows::Forms::TextBox());
			this->textBox15 = (gcnew System::Windows::Forms::TextBox());
			this->textBox16 = (gcnew System::Windows::Forms::TextBox());
			this->label17 = (gcnew System::Windows::Forms::Label());
			this->label18 = (gcnew System::Windows::Forms::Label());
			this->label19 = (gcnew System::Windows::Forms::Label());
			this->label20 = (gcnew System::Windows::Forms::Label());
			this->textBox17 = (gcnew System::Windows::Forms::TextBox());
			this->textBox18 = (gcnew System::Windows::Forms::TextBox());
			this->textBox19 = (gcnew System::Windows::Forms::TextBox());
			this->textBox20 = (gcnew System::Windows::Forms::TextBox());
			this->label21 = (gcnew System::Windows::Forms::Label());
			this->label22 = (gcnew System::Windows::Forms::Label());
			this->label23 = (gcnew System::Windows::Forms::Label());
			this->label24 = (gcnew System::Windows::Forms::Label());
			this->textBox21 = (gcnew System::Windows::Forms::TextBox());
			this->textBox22 = (gcnew System::Windows::Forms::TextBox());
			this->textBox23 = (gcnew System::Windows::Forms::TextBox());
			this->textBox24 = (gcnew System::Windows::Forms::TextBox());
			this->label25 = (gcnew System::Windows::Forms::Label());
			this->label26 = (gcnew System::Windows::Forms::Label());
			this->label27 = (gcnew System::Windows::Forms::Label());
			this->label28 = (gcnew System::Windows::Forms::Label());
			this->textBox25 = (gcnew System::Windows::Forms::TextBox());
			this->textBox26 = (gcnew System::Windows::Forms::TextBox());
			this->textBox27 = (gcnew System::Windows::Forms::TextBox());
			this->textBox28 = (gcnew System::Windows::Forms::TextBox());
			this->label29 = (gcnew System::Windows::Forms::Label());
			this->label30 = (gcnew System::Windows::Forms::Label());
			this->label31 = (gcnew System::Windows::Forms::Label());
			this->label32 = (gcnew System::Windows::Forms::Label());
			this->textBox29 = (gcnew System::Windows::Forms::TextBox());
			this->textBox30 = (gcnew System::Windows::Forms::TextBox());
			this->textBox31 = (gcnew System::Windows::Forms::TextBox());
			this->textBox32 = (gcnew System::Windows::Forms::TextBox());
			this->label33 = (gcnew System::Windows::Forms::Label());
			this->label34 = (gcnew System::Windows::Forms::Label());
			this->label35 = (gcnew System::Windows::Forms::Label());
			this->label36 = (gcnew System::Windows::Forms::Label());
			this->textBox33 = (gcnew System::Windows::Forms::TextBox());
			this->textBox34 = (gcnew System::Windows::Forms::TextBox());
			this->textBox35 = (gcnew System::Windows::Forms::TextBox());
			this->textBox36 = (gcnew System::Windows::Forms::TextBox());
			this->label37 = (gcnew System::Windows::Forms::Label());
			this->label38 = (gcnew System::Windows::Forms::Label());
			this->label39 = (gcnew System::Windows::Forms::Label());
			this->label40 = (gcnew System::Windows::Forms::Label());
			this->textBox37 = (gcnew System::Windows::Forms::TextBox());
			this->textBox38 = (gcnew System::Windows::Forms::TextBox());
			this->textBox39 = (gcnew System::Windows::Forms::TextBox());
			this->textBox40 = (gcnew System::Windows::Forms::TextBox());
			this->SuspendLayout();
			// 
			// canvas
			// 
			//this->canvas->BackColor = System::Drawing::Color::Black;
			this->canvas->Location = System::Drawing::Point(25, 25);
			this->canvas->Name = L"canvas";
			this->canvas->Size = System::Drawing::Size(900, 900);
			this->canvas->TabIndex = 0;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(953, 25);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(46, 17);
			this->label1->TabIndex = 5;
			this->label1->Text = L"Head.X";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(1074, 25);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(46, 17);
			this->label2->TabIndex = 6;
			this->label2->Text = L"Head.Y";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(1197, 25);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(46, 17);
			this->label3->TabIndex = 7;
			this->label3->Text = L"ShoulderCenter.X";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(1319, 25);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(46, 17);
			this->label4->TabIndex = 8;
			this->label4->Text = L"ShoulderCenter.Y";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Location = System::Drawing::Point(953, 90);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(46, 17);
			this->label5->TabIndex = 16;
			this->label5->Text = L"ShoulderLeft.X";
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Location = System::Drawing::Point(1074, 90);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(46, 17);
			this->label6->TabIndex = 15;
			this->label6->Text = L"ShoulderLeft.Y";
			// 
			// label7
			// 
			this->label7->AutoSize = true;
			this->label7->Location = System::Drawing::Point(1197, 90);
			this->label7->Name = L"label7";
			this->label7->Size = System::Drawing::Size(46, 17);
			this->label7->TabIndex = 14;
			this->label7->Text = L"ShoulderRight.X";
			// 
			// label8
			// 
			this->label8->AutoSize = true;
			this->label8->Location = System::Drawing::Point(1319, 90);
			this->label8->Name = L"label8";
			this->label8->Size = System::Drawing::Size(46, 17);
			this->label8->TabIndex = 13;
			this->label8->Text = L"ShoulderRight.Y";
			// 
			// label9
			// 
			this->label9->AutoSize = true;
			this->label9->Location = System::Drawing::Point(953, 160);
			this->label9->Name = L"label9";
			this->label9->Size = System::Drawing::Size(46, 17);
			this->label9->TabIndex = 24;
			this->label9->Text = L"ElbowLeft.X";
			// 
			// label10
			// 
			this->label10->AutoSize = true;
			this->label10->Location = System::Drawing::Point(1074, 160);
			this->label10->Name = L"label10";
			this->label10->Size = System::Drawing::Size(54, 17);
			this->label10->TabIndex = 23;
			this->label10->Text = L"ElbowLeft.Y";
			// 
			// label11
			// 
			this->label11->AutoSize = true;
			this->label11->Location = System::Drawing::Point(1197, 160);
			this->label11->Name = L"label11";
			this->label11->Size = System::Drawing::Size(54, 17);
			this->label11->TabIndex = 22;
			this->label11->Text = L"ElbowRight.X";
			// 
			// label12
			// 
			this->label12->AutoSize = true;
			this->label12->Location = System::Drawing::Point(1319, 160);
			this->label12->Name = L"label12";
			this->label12->Size = System::Drawing::Size(54, 17);
			this->label12->TabIndex = 21;
			this->label12->Text = L"ElbowRight.Y";
			// 
			// label13
			// 
			this->label13->AutoSize = true;
			this->label13->Location = System::Drawing::Point(953, 229);
			this->label13->Name = L"label13";
			this->label13->Size = System::Drawing::Size(54, 17);
			this->label13->TabIndex = 32;
			this->label13->Text = L"WristLeft.X";
			// 
			// label14
			// 
			this->label14->AutoSize = true;
			this->label14->Location = System::Drawing::Point(1074, 229);
			this->label14->Name = L"label14";
			this->label14->Size = System::Drawing::Size(54, 17);
			this->label14->TabIndex = 31;
			this->label14->Text = L"WristLeft.Y";
			// 
			// label15
			// 
			this->label15->AutoSize = true;
			this->label15->Location = System::Drawing::Point(1197, 229);
			this->label15->Name = L"label15";
			this->label15->Size = System::Drawing::Size(54, 17);
			this->label15->TabIndex = 30;
			this->label15->Text = L"WristRight.X";
			// 
			// label16
			// 
			this->label16->AutoSize = true;
			this->label16->Location = System::Drawing::Point(1319, 229);
			this->label16->Name = L"label16";
			this->label16->Size = System::Drawing::Size(54, 17);
			this->label16->TabIndex = 29;
			this->label16->Text = L"WristRight.Y";
			// 
			// label17
			// 
			this->label17->AutoSize = true;
			this->label17->Location = System::Drawing::Point(953, 298);
			this->label17->Name = L"label17";
			this->label17->Size = System::Drawing::Size(54, 17);
			this->label17->TabIndex = 40;
			this->label17->Text = L"HandLeft.X";
			// 
			// label18
			// 
			this->label18->AutoSize = true;
			this->label18->Location = System::Drawing::Point(1074, 298);
			this->label18->Name = L"label18";
			this->label18->Size = System::Drawing::Size(54, 17);
			this->label18->TabIndex = 39;
			this->label18->Text = L"HandLeft.Y";
			// 
			// label19
			// 
			this->label19->AutoSize = true;
			this->label19->Location = System::Drawing::Point(1197, 298);
			this->label19->Name = L"label19";
			this->label19->Size = System::Drawing::Size(54, 17);
			this->label19->TabIndex = 38;
			this->label19->Text = L"HandRight.X";
			// 
			// label20
			// 
			this->label20->AutoSize = true;
			this->label20->Location = System::Drawing::Point(1319, 298);
			this->label20->Name = L"label20";
			this->label20->Size = System::Drawing::Size(54, 17);
			this->label20->TabIndex = 37;
			this->label20->Text = L"HandRight.Y";
			// 
			// label21
			// 
			this->label21->AutoSize = true;
			this->label21->Location = System::Drawing::Point(953, 368);
			this->label21->Name = L"label21";
			this->label21->Size = System::Drawing::Size(54, 17);
			this->label21->TabIndex = 80;
			this->label21->Text = L"Spine.X";
			// 
			// label22
			// 
			this->label22->AutoSize = true;
			this->label22->Location = System::Drawing::Point(1074, 368);
			this->label22->Name = L"label22";
			this->label22->Size = System::Drawing::Size(54, 17);
			this->label22->TabIndex = 79;
			this->label22->Text = L"Spine.Y";
			// 
			// label23
			// 
			this->label23->AutoSize = true;
			this->label23->Location = System::Drawing::Point(1197, 368);
			this->label23->Name = L"label23";
			this->label23->Size = System::Drawing::Size(54, 17);
			this->label23->TabIndex = 78;
			this->label23->Text = L"HipCenter.X";
			// 
			// label24
			// 
			this->label24->AutoSize = true;
			this->label24->Location = System::Drawing::Point(1319, 368);
			this->label24->Name = L"label24";
			this->label24->Size = System::Drawing::Size(54, 17);
			this->label24->TabIndex = 77;
			this->label24->Text = L"HipCenter.Y";
			// 
			// label25
			// 
			this->label25->AutoSize = true;
			this->label25->Location = System::Drawing::Point(953, 433);
			this->label25->Name = L"label25";
			this->label25->Size = System::Drawing::Size(54, 17);
			this->label25->TabIndex = 72;
			this->label25->Text = L"HipLeft.X";
			// 
			// label26
			// 
			this->label26->AutoSize = true;
			this->label26->Location = System::Drawing::Point(1074, 433);
			this->label26->Name = L"label26";
			this->label26->Size = System::Drawing::Size(54, 17);
			this->label26->TabIndex = 71;
			this->label26->Text = L"HipLeft.Y";
			// 
			// label27
			// 
			this->label27->AutoSize = true;
			this->label27->Location = System::Drawing::Point(1197, 433);
			this->label27->Name = L"label27";
			this->label27->Size = System::Drawing::Size(54, 17);
			this->label27->TabIndex = 70;
			this->label27->Text = L"HipRight.X";
			// 
			// label28
			// 
			this->label28->AutoSize = true;
			this->label28->Location = System::Drawing::Point(1319, 433);
			this->label28->Name = L"label28";
			this->label28->Size = System::Drawing::Size(54, 17);
			this->label28->TabIndex = 69;
			this->label28->Text = L"HipRight.Y";
			// 
			// label29
			// 
			this->label29->AutoSize = true;
			this->label29->Location = System::Drawing::Point(953, 503);
			this->label29->Name = L"label29";
			this->label29->Size = System::Drawing::Size(54, 17);
			this->label29->TabIndex = 64;
			this->label29->Text = L"KneeLeft.X";
			// 
			// label30
			// 
			this->label30->AutoSize = true;
			this->label30->Location = System::Drawing::Point(1074, 503);
			this->label30->Name = L"label30";
			this->label30->Size = System::Drawing::Size(54, 17);
			this->label30->TabIndex = 63;
			this->label30->Text = L"KneeLeft.Y";
			// 
			// label31
			// 
			this->label31->AutoSize = true;
			this->label31->Location = System::Drawing::Point(1197, 503);
			this->label31->Name = L"label31";
			this->label31->Size = System::Drawing::Size(54, 17);
			this->label31->TabIndex = 62;
			this->label31->Text = L"KneeRight.X";
			// 
			// label32
			// 
			this->label32->AutoSize = true;
			this->label32->Location = System::Drawing::Point(1319, 503);
			this->label32->Name = L"label32";
			this->label32->Size = System::Drawing::Size(54, 17);
			this->label32->TabIndex = 61;
			this->label32->Text = L"KneeRight.Y";
			// 
			// label33
			// 
			this->label33->AutoSize = true;
			this->label33->Location = System::Drawing::Point(953, 572);
			this->label33->Name = L"label33";
			this->label33->Size = System::Drawing::Size(54, 17);
			this->label33->TabIndex = 56;
			this->label33->Text = L"AnkleLeft.X";
			// 
			// label34
			// 
			this->label34->AutoSize = true;
			this->label34->Location = System::Drawing::Point(1074, 572);
			this->label34->Name = L"label34";
			this->label34->Size = System::Drawing::Size(54, 17);
			this->label34->TabIndex = 55;
			this->label34->Text = L"AnkleLeft.Y";
			// 
			// label35
			// 
			this->label35->AutoSize = true;
			this->label35->Location = System::Drawing::Point(1197, 572);
			this->label35->Name = L"label35";
			this->label35->Size = System::Drawing::Size(54, 17);
			this->label35->TabIndex = 54;
			this->label35->Text = L"AnkleRight.X";
			// 
			// label36
			// 
			this->label36->AutoSize = true;
			this->label36->Location = System::Drawing::Point(1319, 572);
			this->label36->Name = L"label36";
			this->label36->Size = System::Drawing::Size(54, 17);
			this->label36->TabIndex = 53;
			this->label36->Text = L"AnkleRight.Y";
			// 
			// label37
			// 
			this->label37->AutoSize = true;
			this->label37->Location = System::Drawing::Point(953, 641);
			this->label37->Name = L"label37";
			this->label37->Size = System::Drawing::Size(54, 17);
			this->label37->TabIndex = 48;
			this->label37->Text = L"FootLeft.X";
			// 
			// label38
			// 
			this->label38->AutoSize = true;
			this->label38->Location = System::Drawing::Point(1074, 641);
			this->label38->Name = L"label38";
			this->label38->Size = System::Drawing::Size(54, 17);
			this->label38->TabIndex = 47;
			this->label38->Text = L"FootLeft.Y";
			// 
			// label39
			// 
			this->label39->AutoSize = true;
			this->label39->Location = System::Drawing::Point(1197, 641);
			this->label39->Name = L"label39";
			this->label39->Size = System::Drawing::Size(54, 17);
			this->label39->TabIndex = 46;
			this->label39->Text = L"FootRight.X";
			// 
			// label40
			// 
			this->label40->AutoSize = true;
			this->label40->Location = System::Drawing::Point(1319, 641);
			this->label40->Name = L"label40";
			this->label40->Size = System::Drawing::Size(54, 17);
			this->label40->TabIndex = 45;
			this->label40->Text = L"FootRight.Y";
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(956, 50);
			this->textBox1->Name = L"textBox1";
			this->textBox1->ReadOnly = true;
			this->textBox1->Size = System::Drawing::Size(100, 22);
			this->textBox1->TabIndex = 1;
			// 
			// textBox2
			// 
			this->textBox2->Location = System::Drawing::Point(1077, 50);
			this->textBox2->Name = L"textBox2";
			this->textBox2->ReadOnly = true;
			this->textBox2->Size = System::Drawing::Size(100, 22);
			this->textBox2->TabIndex = 2;
			// 
			// textBox3
			// 
			this->textBox3->Location = System::Drawing::Point(1200, 50);
			this->textBox3->Name = L"textBox3";
			this->textBox3->ReadOnly = true;
			this->textBox3->Size = System::Drawing::Size(100, 22);
			this->textBox3->TabIndex = 3;
			// 
			// textBox4
			// 
			this->textBox4->Location = System::Drawing::Point(1322, 50);
			this->textBox4->Name = L"textBox4";
			this->textBox4->ReadOnly = true;
			this->textBox4->Size = System::Drawing::Size(100, 22);
			this->textBox4->TabIndex = 4;
			// 
			// textBox5
			// 
			this->textBox5->Location = System::Drawing::Point(956, 115);
			this->textBox5->Name = L"textBox5";
			this->textBox5->ReadOnly = true;
			this->textBox5->Size = System::Drawing::Size(100, 22);
			this->textBox5->TabIndex = 12;
			// 
			// textBox6
			// 
			this->textBox6->Location = System::Drawing::Point(1077, 115);
			this->textBox6->Name = L"textBox6";
			this->textBox6->ReadOnly = true;
			this->textBox6->Size = System::Drawing::Size(100, 22);
			this->textBox6->TabIndex = 11;
			// 
			// textBox7
			// 
			this->textBox7->Location = System::Drawing::Point(1200, 115);
			this->textBox7->Name = L"textBox7";
			this->textBox7->ReadOnly = true;
			this->textBox7->Size = System::Drawing::Size(100, 22);
			this->textBox7->TabIndex = 10;
			// 
			// textBox8
			// 
			this->textBox8->Location = System::Drawing::Point(1322, 115);
			this->textBox8->Name = L"textBox8";
			this->textBox8->ReadOnly = true;
			this->textBox8->Size = System::Drawing::Size(100, 22);
			this->textBox8->TabIndex = 9;
			// 
			// textBox9
			// 
			this->textBox9->Location = System::Drawing::Point(956, 185);
			this->textBox9->Name = L"textBox9";
			this->textBox9->ReadOnly = true;
			this->textBox9->Size = System::Drawing::Size(100, 22);
			this->textBox9->TabIndex = 20;
			// 
			// textBox10
			// 
			this->textBox10->Location = System::Drawing::Point(1077, 185);
			this->textBox10->Name = L"textBox10";
			this->textBox10->ReadOnly = true;
			this->textBox10->Size = System::Drawing::Size(100, 22);
			this->textBox10->TabIndex = 19;
			// 
			// textBox11
			// 
			this->textBox11->Location = System::Drawing::Point(1200, 185);
			this->textBox11->Name = L"textBox11";
			this->textBox11->ReadOnly = true;
			this->textBox11->Size = System::Drawing::Size(100, 22);
			this->textBox11->TabIndex = 18;
			// 
			// textBox12
			// 
			this->textBox12->Location = System::Drawing::Point(1322, 185);
			this->textBox12->Name = L"textBox12";
			this->textBox12->ReadOnly = true;
			this->textBox12->Size = System::Drawing::Size(100, 22);
			this->textBox12->TabIndex = 17;
			// 
			// textBox13
			// 
			this->textBox13->Location = System::Drawing::Point(956, 254);
			this->textBox13->Name = L"textBox13";
			this->textBox13->ReadOnly = true;
			this->textBox13->Size = System::Drawing::Size(100, 22);
			this->textBox13->TabIndex = 28;
			// 
			// textBox14
			// 
			this->textBox14->Location = System::Drawing::Point(1077, 254);
			this->textBox14->Name = L"textBox14";
			this->textBox14->ReadOnly = true;
			this->textBox14->Size = System::Drawing::Size(100, 22);
			this->textBox14->TabIndex = 27;
			// 
			// textBox15
			// 
			this->textBox15->Location = System::Drawing::Point(1200, 254);
			this->textBox15->Name = L"textBox15";
			this->textBox15->ReadOnly = true;
			this->textBox15->Size = System::Drawing::Size(100, 22);
			this->textBox15->TabIndex = 26;
			// 
			// textBox16
			// 
			this->textBox16->Location = System::Drawing::Point(1322, 254);
			this->textBox16->Name = L"textBox16";
			this->textBox16->ReadOnly = true;
			this->textBox16->Size = System::Drawing::Size(100, 22);
			this->textBox16->TabIndex = 25;
			// 
			// textBox17
			// 
			this->textBox17->Location = System::Drawing::Point(956, 323);
			this->textBox17->Name = L"textBox17";
			this->textBox17->ReadOnly = true;
			this->textBox17->Size = System::Drawing::Size(100, 22);
			this->textBox17->TabIndex = 36;
			// 
			// textBox18
			// 
			this->textBox18->Location = System::Drawing::Point(1077, 323);
			this->textBox18->Name = L"textBox18";
			this->textBox18->ReadOnly = true;
			this->textBox18->Size = System::Drawing::Size(100, 22);
			this->textBox18->TabIndex = 35;
			// 
			// textBox19
			// 
			this->textBox19->Location = System::Drawing::Point(1200, 323);
			this->textBox19->Name = L"textBox19";
			this->textBox19->ReadOnly = true;
			this->textBox19->Size = System::Drawing::Size(100, 22);
			this->textBox19->TabIndex = 34;
			// 
			// textBox20
			// 
			this->textBox20->Location = System::Drawing::Point(1322, 323);
			this->textBox20->Name = L"textBox20";
			this->textBox20->ReadOnly = true;
			this->textBox20->Size = System::Drawing::Size(100, 22);
			this->textBox20->TabIndex = 33;
			// 
			// textBox21
			// 
			this->textBox21->Location = System::Drawing::Point(956, 393);
			this->textBox21->Name = L"textBox21";
			this->textBox21->ReadOnly = true;
			this->textBox21->Size = System::Drawing::Size(100, 22);
			this->textBox21->TabIndex = 76;
			// 
			// textBox22
			// 
			this->textBox22->Location = System::Drawing::Point(1077, 393);
			this->textBox22->Name = L"textBox22";
			this->textBox22->ReadOnly = true;
			this->textBox22->Size = System::Drawing::Size(100, 22);
			this->textBox22->TabIndex = 75;
			// 
			// textBox23
			// 
			this->textBox23->Location = System::Drawing::Point(1200, 393);
			this->textBox23->Name = L"textBox23";
			this->textBox23->ReadOnly = true;
			this->textBox23->Size = System::Drawing::Size(100, 22);
			this->textBox23->TabIndex = 74;
			// 
			// textBox24
			// 
			this->textBox24->Location = System::Drawing::Point(1322, 393);
			this->textBox24->Name = L"textBox24";
			this->textBox24->ReadOnly = true;
			this->textBox24->Size = System::Drawing::Size(100, 22);
			this->textBox24->TabIndex = 73;
			// 
			// textBox25
			// 
			this->textBox25->Location = System::Drawing::Point(956, 458);
			this->textBox25->Name = L"textBox25";
			this->textBox25->ReadOnly = true;
			this->textBox25->Size = System::Drawing::Size(100, 22);
			this->textBox25->TabIndex = 68;
			// 
			// textBox26
			// 
			this->textBox26->Location = System::Drawing::Point(1077, 458);
			this->textBox26->Name = L"textBox26";
			this->textBox26->ReadOnly = true;
			this->textBox26->Size = System::Drawing::Size(100, 22);
			this->textBox26->TabIndex = 67;
			// 
			// textBox27
			// 
			this->textBox27->Location = System::Drawing::Point(1200, 458);
			this->textBox27->Name = L"textBox27";
			this->textBox27->ReadOnly = true;
			this->textBox27->Size = System::Drawing::Size(100, 22);
			this->textBox27->TabIndex = 66;
			// 
			// textBox28
			// 
			this->textBox28->Location = System::Drawing::Point(1322, 458);
			this->textBox28->Name = L"textBox28";
			this->textBox28->ReadOnly = true;
			this->textBox28->Size = System::Drawing::Size(100, 22);
			this->textBox28->TabIndex = 65;
			// 
			// textBox29
			// 
			this->textBox29->Location = System::Drawing::Point(956, 528);
			this->textBox29->Name = L"textBox29";
			this->textBox29->ReadOnly = true;
			this->textBox29->Size = System::Drawing::Size(100, 22);
			this->textBox29->TabIndex = 60;
			// 
			// textBox30
			// 
			this->textBox30->Location = System::Drawing::Point(1077, 528);
			this->textBox30->Name = L"textBox30";
			this->textBox30->ReadOnly = true;
			this->textBox30->Size = System::Drawing::Size(100, 22);
			this->textBox30->TabIndex = 59;
			// 
			// textBox31
			// 
			this->textBox31->Location = System::Drawing::Point(1200, 528);
			this->textBox31->Name = L"textBox31";
			this->textBox31->ReadOnly = true;
			this->textBox31->Size = System::Drawing::Size(100, 22);
			this->textBox31->TabIndex = 58;
			// 
			// textBox32
			// 
			this->textBox32->Location = System::Drawing::Point(1322, 528);
			this->textBox32->Name = L"textBox32";
			this->textBox32->ReadOnly = true;
			this->textBox32->Size = System::Drawing::Size(100, 22);
			this->textBox32->TabIndex = 57;
			// 
			// textBox33
			// 
			this->textBox33->Location = System::Drawing::Point(956, 597);
			this->textBox33->Name = L"textBox33";
			this->textBox33->ReadOnly = true;
			this->textBox33->Size = System::Drawing::Size(100, 22);
			this->textBox33->TabIndex = 52;
			// 
			// textBox34
			// 
			this->textBox34->Location = System::Drawing::Point(1077, 597);
			this->textBox34->Name = L"textBox34";
			this->textBox34->ReadOnly = true;
			this->textBox34->Size = System::Drawing::Size(100, 22);
			this->textBox34->TabIndex = 51;
			// 
			// textBox35
			// 
			this->textBox35->Location = System::Drawing::Point(1200, 597);
			this->textBox35->Name = L"textBox35";
			this->textBox35->ReadOnly = true;
			this->textBox35->Size = System::Drawing::Size(100, 22);
			this->textBox35->TabIndex = 50;
			// 
			// textBox36
			// 
			this->textBox36->Location = System::Drawing::Point(1322, 597);
			this->textBox36->Name = L"textBox36";
			this->textBox36->ReadOnly = true;
			this->textBox36->Size = System::Drawing::Size(100, 22);
			this->textBox36->TabIndex = 49;
			// 
			// textBox37
			// 
			this->textBox37->Location = System::Drawing::Point(956, 666);
			this->textBox37->Name = L"textBox37";
			this->textBox37->ReadOnly = true;
			this->textBox37->Size = System::Drawing::Size(100, 22);
			this->textBox37->TabIndex = 44;
			// 
			// textBox38
			// 
			this->textBox38->Location = System::Drawing::Point(1077, 666);
			this->textBox38->Name = L"textBox38";
			this->textBox38->ReadOnly = true;
			this->textBox38->Size = System::Drawing::Size(100, 22);
			this->textBox38->TabIndex = 43;
			// 
			// textBox39
			// 
			this->textBox39->Location = System::Drawing::Point(1200, 666);
			this->textBox39->Name = L"textBox39";
			this->textBox39->ReadOnly = true;
			this->textBox39->Size = System::Drawing::Size(100, 22);
			this->textBox39->TabIndex = 42;
			// 
			// textBox40
			// 
			this->textBox40->Location = System::Drawing::Point(1322, 666);
			this->textBox40->Name = L"textBox40";
			this->textBox40->ReadOnly = true;
			this->textBox40->Size = System::Drawing::Size(100, 22);
			this->textBox40->TabIndex = 41;
			// 
			// MainForm
			// 
			this->ClientSize = System::Drawing::Size(1450, 950);
			this->Controls->Add(this->label21);
			this->Controls->Add(this->label22);
			this->Controls->Add(this->label23);
			this->Controls->Add(this->label24);
			this->Controls->Add(this->textBox21);
			this->Controls->Add(this->textBox22);
			this->Controls->Add(this->textBox23);
			this->Controls->Add(this->textBox24);
			this->Controls->Add(this->label25);
			this->Controls->Add(this->label26);
			this->Controls->Add(this->label27);
			this->Controls->Add(this->label28);
			this->Controls->Add(this->textBox25);
			this->Controls->Add(this->textBox26);
			this->Controls->Add(this->textBox27);
			this->Controls->Add(this->textBox28);
			this->Controls->Add(this->label29);
			this->Controls->Add(this->label30);
			this->Controls->Add(this->label31);
			this->Controls->Add(this->label32);
			this->Controls->Add(this->textBox29);
			this->Controls->Add(this->textBox30);
			this->Controls->Add(this->textBox31);
			this->Controls->Add(this->textBox32);
			this->Controls->Add(this->label33);
			this->Controls->Add(this->label34);
			this->Controls->Add(this->label35);
			this->Controls->Add(this->label36);
			this->Controls->Add(this->textBox33);
			this->Controls->Add(this->textBox34);
			this->Controls->Add(this->textBox35);
			this->Controls->Add(this->textBox36);
			this->Controls->Add(this->label37);
			this->Controls->Add(this->label38);
			this->Controls->Add(this->label39);
			this->Controls->Add(this->label40);
			this->Controls->Add(this->textBox37);
			this->Controls->Add(this->textBox38);
			this->Controls->Add(this->textBox39);
			this->Controls->Add(this->textBox40);
			this->Controls->Add(this->label17);
			this->Controls->Add(this->label18);
			this->Controls->Add(this->label19);
			this->Controls->Add(this->label20);
			this->Controls->Add(this->textBox17);
			this->Controls->Add(this->textBox18);
			this->Controls->Add(this->textBox19);
			this->Controls->Add(this->textBox20);
			this->Controls->Add(this->label13);
			this->Controls->Add(this->label14);
			this->Controls->Add(this->label15);
			this->Controls->Add(this->label16);
			this->Controls->Add(this->textBox13);
			this->Controls->Add(this->textBox14);
			this->Controls->Add(this->textBox15);
			this->Controls->Add(this->textBox16);
			this->Controls->Add(this->label9);
			this->Controls->Add(this->label10);
			this->Controls->Add(this->label11);
			this->Controls->Add(this->label12);
			this->Controls->Add(this->textBox9);
			this->Controls->Add(this->textBox10);
			this->Controls->Add(this->textBox11);
			this->Controls->Add(this->textBox12);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->label7);
			this->Controls->Add(this->label8);
			this->Controls->Add(this->textBox5);
			this->Controls->Add(this->textBox6);
			this->Controls->Add(this->textBox7);
			this->Controls->Add(this->textBox8);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->textBox4);
			this->Controls->Add(this->textBox3);
			this->Controls->Add(this->textBox2);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->canvas);
			this->txtBoxes = gcnew array<System::Windows::Forms::TextBox^> {textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, textBox33, textBox34, textBox35, textBox36, textBox37, textBox38, textBox39, textBox40};
			this->Name = L"MainForm";
			this->Text = L"MainForm";
			this->ResumeLayout(false);
			this->PerformLayout();
		}

		void InitializeDirect2D()
		{
			HWND hCanvas = static_cast<HWND>(this->canvas->Handle.ToPointer());
			RECT* rc = new RECT;
			GetWindowRect(hCanvas, rc);
			D2D1_SIZE_U canvasSize = D2D1::SizeU(rc->right - rc->left, rc->bottom - rc->top);
			bounds = rc;
			bounds->right = bounds->right - bounds->left;
			bounds->bottom = bounds->bottom - bounds->top;
			bounds->left = 0;
			bounds->top = 0;

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
			dwFactory->CreateTextFormat(L"Courier", NULL, DWRITE_FONT_WEIGHT_REGULAR, DWRITE_FONT_STYLE_NORMAL, DWRITE_FONT_STRETCH_NORMAL, 30.0, L"en-us", &dwTextFormat);
			this->dwFactory = dwFactory;
			this->dwTextFormat = dwTextFormat;
		}

		System::Void Direct2DPaint();
	};
}
