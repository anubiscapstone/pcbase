using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnubisClient.AnubisCORE;

namespace AnubisClient
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ANUBISEngine.Initialize();
            Application.Run();
        }
    }
}
