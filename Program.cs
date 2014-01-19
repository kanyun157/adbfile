using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBexplorer
{
    static class Program
    {
        static MainFrom mainForm;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GlobalSys.loadConfig();
            mainForm = new MainFrom(); 
            if (args.Length>0)
                GlobalSys.startArg = args[0];     
            SingleInstanceApplication.Run(mainForm, NewInstanceHandler); 
        }

        public static void NewInstanceHandler(object sender, Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs e)
        {
            //string imageLocation = e.CommandLine[1];
            //if(imageLocation!=null)
            //MessageBox.Show(imageLocation);
            //ControlPanel.uploadImage(imageLocation);
            if (e.CommandLine[1]!=null)
            {
                if (e.CommandLine[1].EndsWith(".apk"))
                {
                    GlobalSys.startArg = e.CommandLine[1];
                    mainForm.AddAndSwitchToApk(GlobalSys.startArg);
                    e.BringToForeground = true;       
                }
            }    
        }

        public class SingleInstanceApplication : Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
        {
            private SingleInstanceApplication()
            {
                base.IsSingleInstance = true;
            }

            public static void Run(Form f, Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventHandler startupHandler)
            {
                SingleInstanceApplication app = new SingleInstanceApplication();
                app.MainForm = f;
                app.StartupNextInstance += startupHandler;
                app.Run(Environment.GetCommandLineArgs());
            }
        }  
    }
}
