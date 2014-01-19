using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBexplorer
{
    class AdbCmd
    {
        static int lasterr;

        static string mCommand; //The command to process
        static bool mCancel; //Set this to True to cancel
        static bool mReady; //Are we ready to launch new command?

        const string mVersion = "ADB Explorer v1.0";
        const string strError400 = "Not ready to process another command.";
        const string strError401 = "Command Line empty.";
        const string strError402 = "Not processing a command to cancel.";
        const string strError403 = "Not ready to change settings.";
        const string strError404 = "CreatePipe failed.";
        const string strError405 = "SetNamedPipeHandleState failed.";
        const string strError406 = "CreateProcess failed.";

        const string errPermissionDenied = "Permission denied";

        static string strDevice = null;

        public string CommandLine
        {
            get { return mCommand; }
            set 
            { 
                if (mReady==true)
                    mCommand = value; 
                else
                    MessageBox.Show("error", strError403);
            }
        }

        public bool Ready
        {
            get { return mReady; }
        }

        public string Version
        {
            get { return mVersion; }
        }

        public static void SetReady()
        {
            mReady = true;
        }

        void Cancel()
        {
            if (mReady == false)
            {
                mCancel = true;
            }
            else
            {
                MessageBox.Show("error", strError402);
            }
        }

        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }

        static public bool DoAdbErrorCheck(string str)
        {
            if (str.Contains(errPermissionDenied))
            {
                //MessageBox.Show(errPermissionDenied+"\r\n"+str);
                return false;
            }

            return true;
        }

        static public void SelectDevice(string device)
        {
           strDevice = device;
        }

        static public bool ExecuteADBCommand(string CommandLine, out StringBuilder result)
        {          
            //return ExecuteCommand(ADBPath + " " + CommandLine, out result);
            if (strDevice==null)
                return ExecuteCommand(GlobalSys.adbPath, CommandLine, out result);
            else
                return ExecuteCommand(GlobalSys.adbPath, "-s " + strDevice + " " + CommandLine, out result);
        }

        static public bool ExecuteCommand(string exeName, string arguments, out StringBuilder result)
        {
            result = new StringBuilder();

            Process myprocess = new Process();

            myprocess.StartInfo.FileName = exeName;// "adb.exe";
            myprocess.StartInfo.Arguments = arguments;//"shell busybox ls -1 /system/app --color=never"; //
            myprocess.StartInfo.UseShellExecute = false;

            /// added the next line to keep a new window from opening
            myprocess.StartInfo.CreateNoWindow = true;
            myprocess.StartInfo.RedirectStandardOutput = true;
            myprocess.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            myprocess.Start();

            /*while (!myprocess.HasExited)
            {
                count++;
                m_SyncContext.Post(updateText, "time:" + (count / 10) + ":" + (count * 100 - (count / 10) * 1000));
                Thread.Sleep(100);
            }*/
            int count = 0;
            bool hasExit = false;
            while (true)
            {
                string str = myprocess.StandardOutput.ReadLine();
                if (str != null)
                    result.Append(str + "\r\r\n");
                else
                {
                    hasExit = true;
                    break;
                }
            }
            if (!hasExit)
            {
                myprocess.WaitForExit();

                string output = myprocess.StandardOutput.ReadToEnd();
                result.Append(output);
            }
            if (myprocess.ExitCode == 0)
                return true;
            else
            {
                Log.Write(arguments + " failed:\r\n");
                Log.Write(result.ToString() + "\r\n");
                return false;
            }
            /*Console.WriteLine("exitcode:" + myprocess.ExitCode);
            Console.Write(output);
            Console.Write("\n");
            m_SyncContext.Post(updateText, "complete:" + output);*/
        }

        static public bool ExecuteADBCommandNoWait(string CommandLine)
        {
            string ADBPath = "adb.exe";

            if (strDevice == null)
                return ExecuteCommandNoWait(ADBPath, CommandLine);
            else
                return ExecuteCommandNoWait(ADBPath, "-s " + strDevice + " " + CommandLine);
        }


        static public bool ExecuteCommandNoWait(string exeName, string arguments)
        {
            Process myprocess = new Process();

            myprocess.StartInfo.FileName = exeName;// "adb.exe";
            myprocess.StartInfo.Arguments = arguments;//"shell busybox ls -1 /system/app --color=never"; //
            myprocess.StartInfo.UseShellExecute = false;

            /// added the next line to keep a new window from opening
            myprocess.StartInfo.CreateNoWindow = true;
            myprocess.StartInfo.RedirectStandardOutput = true;
            myprocess.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            myprocess.Start();

            /*myprocess.WaitForExit();
            if (myprocess.ExitCode == 0)
                return true;
            else
            {
                Log.Write(arguments + " failed\r\n");
                return false;
            }*/
            return true;
        }    

    }
}
