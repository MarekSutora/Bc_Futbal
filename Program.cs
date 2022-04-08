using System;
using System.Windows.Forms;

namespace LGR_Futbal
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RiadiaciForm());
        }
    }
}
