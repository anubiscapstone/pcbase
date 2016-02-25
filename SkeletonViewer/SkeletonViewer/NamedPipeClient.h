#pragma once

#include "Includes.h"
namespace SkeletonViewer
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Threading;
	using namespace System::IO;
	using namespace System::IO::Pipes;

	public ref class NamedPipeClient
	{
	private:
		System::String^ _message = "";

		System::String^ serverName = "anubis-pipe";
		System::String^ helo = "SkeletonViewer";
		System::IO::Pipes::NamedPipeClientStream^ pipe = nullptr;
		System::IO::StreamWriter^ pipeWriter = nullptr;
		System::IO::StreamReader^ pipeReader = nullptr;
		System::ComponentModel::BackgroundWorker^ pipeConnectWorker = nullptr;
		System::ComponentModel::BackgroundWorker^ pipeWriteWorker = nullptr;
		System::ComponentModel::BackgroundWorker^ pipeReadWorker = nullptr;

		System::Void pipeConnectWork(System::Object^ sender, System::ComponentModel::DoWorkEventArgs^ e);
		System::Void pipeConnectDone(System::Object^ sender, System::ComponentModel::RunWorkerCompletedEventArgs^ e);
		System::Void pipeWriteWork(System::Object^ sender, System::ComponentModel::DoWorkEventArgs^ e);
		System::Void pipeWriteDone(System::Object^ sender, System::ComponentModel::RunWorkerCompletedEventArgs^ e);
		System::Void pipeReadWork(System::Object^ sender, System::ComponentModel::DoWorkEventArgs^ e);
		System::Void pipeReadDone(System::Object^ sender, System::ComponentModel::RunWorkerCompletedEventArgs^ e);

		System::Void PipeBroke();

	public:
		delegate void newMessageDelegate();
		event newMessageDelegate^ newMessage;

		property System::String^ Message
		{
			System::String^ get()
			{
				msclr::lock l(_message);
				System::String^ temp = _message;
				return temp;
			}
			void set(System::String^ s)
			{
				msclr::lock l(_message);
				_message = s;
				l.release();
				newMessage();
			}
		};

		NamedPipeClient();

		System::Void Start();
	};
}
