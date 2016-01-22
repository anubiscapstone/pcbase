#include "Includes.h"
#include "MainForm.h"
#include "NamedPipeClient.h"

using namespace System::Windows::Forms;
using namespace SkeletonViewer;

int APIENTRY wWinMain(_In_ HINSTANCE hInstance, _In_opt_ HINSTANCE hPrevInstance, _In_ LPWSTR lpCmdLine, _In_ int nCmdShow)
{
	NamedPipeClient^ pipeClient = gcnew NamedPipeClient();
	pipeClient->Start();

	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	Application::Run(gcnew MainForm(pipeClient));
}