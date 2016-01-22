#include "NamedPipeClient.h"

using namespace SkeletonViewer;

NamedPipeClient::NamedPipeClient()
{
	this->pipeConnectWorker = gcnew System::ComponentModel::BackgroundWorker;
	this->pipeWriteWorker = gcnew System::ComponentModel::BackgroundWorker;
	this->pipeReadWorker = gcnew System::ComponentModel::BackgroundWorker;
	this->pipeConnectWorker->DoWork += gcnew System::ComponentModel::DoWorkEventHandler(this, &NamedPipeClient::pipeConnectWork);
	this->pipeConnectWorker->RunWorkerCompleted += gcnew System::ComponentModel::RunWorkerCompletedEventHandler(this, &NamedPipeClient::pipeConnectDone);
	this->pipeWriteWorker->DoWork += gcnew System::ComponentModel::DoWorkEventHandler(this, &NamedPipeClient::pipeWriteWork);
	this->pipeWriteWorker->RunWorkerCompleted += gcnew System::ComponentModel::RunWorkerCompletedEventHandler(this, &NamedPipeClient::pipeWriteDone);
	this->pipeReadWorker->DoWork += gcnew System::ComponentModel::DoWorkEventHandler(this, &NamedPipeClient::pipeReadWork);
	this->pipeReadWorker->RunWorkerCompleted += gcnew System::ComponentModel::RunWorkerCompletedEventHandler(this, &NamedPipeClient::pipeReadDone);
}

Void NamedPipeClient::pipeConnectWork(Object^ sender, DoWorkEventArgs^ e)
{
	this->pipe = gcnew NamedPipeClientStream(".", this->serverName, PipeDirection::InOut, PipeOptions::Asynchronous);
	this->pipe->Connect();
}

Void NamedPipeClient::pipeConnectDone(Object^ sender, RunWorkerCompletedEventArgs^ e)
{
	try
	{
		if (e->Error != nullptr || e->Cancelled)
			throw e->Error;

		this->pipeWriter = gcnew StreamWriter(this->pipe);
		this->pipeReader = gcnew StreamReader(this->pipe);
		this->Message = "Connected to " + this->serverName;
		this->pipeWriteWorker->RunWorkerAsync();
		this->pipeReadWorker->RunWorkerAsync();
	}
	catch (Exception^)
	{
		this->PipeBroke();
	}
}

Void NamedPipeClient::pipeWriteWork(Object^ sender, DoWorkEventArgs^ e)
{
	this->pipeWriter->WriteLine(helo);
	this->pipeWriter->Flush();
}

Void NamedPipeClient::pipeWriteDone(Object^ sender, RunWorkerCompletedEventArgs^ e)
{
	try
	{
		if (e->Error != nullptr || e->Cancelled)
			throw e->Error;
	}
	catch (Exception^)
	{
		this->PipeBroke();
	}
}

Void NamedPipeClient::pipeReadWork(Object^ sender, DoWorkEventArgs^ e)
{
	e->Result = this->pipeReader->ReadLine();
}

Void NamedPipeClient::pipeReadDone(Object^ sender, RunWorkerCompletedEventArgs^ e)
{
	try
	{
		if (e->Error != nullptr || e->Cancelled)
			throw e->Error;

		this->Message = safe_cast<String^>(e->Result);
		if (this->pipe->IsConnected)
			this->pipeReadWorker->RunWorkerAsync();
		else
			this->PipeBroke();
	}
	catch (Exception^)
	{
		this->PipeBroke();
	}
}

Void NamedPipeClient::Start()
{
	try
	{
		this->Message = "Waiting for Connection";
		this->pipeConnectWorker->RunWorkerAsync();
	}
	catch (Exception^)
	{
		this->PipeBroke();
	}
}

Void NamedPipeClient::PipeBroke()
{
	this->Message = "Named Pipe Error";
}
