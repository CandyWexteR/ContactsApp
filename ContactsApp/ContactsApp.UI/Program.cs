using System;
using System.Windows.Forms;

namespace ContactsApp.UI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var main = new MainForm();
            Application.Run(main);
        }
    }
}
