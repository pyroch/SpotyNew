using System;
using System.Windows.Forms;

namespace SpotyNew
{
    static class SpotyNew
    {
        [STAThread]
        static void Main()
        {
            Custom.Config.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SpotyNewForm());
        }
    }
}
