using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AnubisClient
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ANUBISEngine.Run();
            Application.Run();
        }
    }
}
