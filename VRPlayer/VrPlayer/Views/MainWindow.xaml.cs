using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using VrPlayer.Helpers;
using VrPlayer.ViewModels;
using VrPlayer.Views.Dialogs;


namespace VrPlayer
{
    public partial class MainWindow : FullScreenWindow
    {
        private readonly MainWindowViewModel _viewModel;

        private readonly MenuViewModel _menuViewModel;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                _viewModel = ((App)Application.Current).ViewModelFactory.CreateMainWindowViewModel();
                DataContext = _viewModel;

                _menuViewModel = ((App)Application.Current).ViewModelFactory.CreateMenuViewModel();


                // Attempt to auto load anubis stream
                _viewModel.MediaService.Load("udp://@226.0.0.1:1234");

                //Display Stream On Rift
                DisplayOnDrewsAmazingOculusRift();
                
            }
            catch (Exception exc)
            {
                Logger.Instance.Error("Error while initilizing Main window.", exc);
            }
        }
        
        private void MaximizeDrewsAwesomeWindow()
        {
            this.WindowState = WindowState.Maximized;
        }

         //[DllImport("user32.dll")]
         //static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

        private void DisplayOnDrewsAmazingOculusRift()
        {
            //helpful link for below code: http://stackoverflow.com/questions/3121900/how-can-i-make-a-wpf-window-maximized-on-the-screen-with-the-mouse-cursor
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Show();
            this.Left = 3361;

            MaximizeDrewsAwesomeWindow();
            //string s = System.Windows.Forms.Screen.AllScreens[2].DeviceName;
            

            //string NoahSucks = Screen.PrimaryScreen.DeviceName;
            //int numOfDisplays = System.Windows.Forms.Screen.AllScreens.Length;
            //string noah = System.Windows.Forms.Screen.AllScreens[3].DeviceName;
            //Rectangle monitor;
            //monitor = System.Windows.Forms.Screen.AllScreens[3].WorkingArea;
            //MessageBox.Show("d");
            //string j = noah;
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            _viewModel.KeyboardCommand.Execute(e.Key);
        }

        
        private void Window_OnDrop(object sender, DragEventArgs e)
        {
            try
            {
                //////////////////////////////////////////////////////////////////////
                // get filename that was dropped onto the window 
                //////////////////////////////////////////////////////////////////////
                var filename = ((DataObject)e.Data).GetFileDropList()[0];

                //////////////////////////////////////////////////////////////////////
                // play it
                //////////////////////////////////////////////////////////////////////
                _viewModel.MediaService.Load(filename);
            }
            catch (Exception exc)
            {
                //////////////////////////////////////////////////////////////////////
                // didn't work - why?
                //////////////////////////////////////////////////////////////////////
                Logger.Instance.Error("Error with the Drag&Drop", exc);
            }
        }


        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
