using System;
using System.Windows.Forms;
using Ttu.Presentation;
using Ttu.Service;

namespace Ttu.Library
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new ServiceInitializer().Initialize(false);
            PresentationEnvironment.Singleton.SetServiceFactory(new ServiceFactory());


            Application.Run(new MainForm());
        }
    }
}
