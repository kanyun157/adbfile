using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace ADBexplorer
{
    class GlobalSys
    {
        public static string startArg;
        public static string selfPath;
        public static string adbPath;
        public static string aaptPath;
        public static string logPath;
        public static string tmpIconPath;
        public static string registerPath;

        public static void loadConfig()
        {
            selfPath = System.Windows.Forms.Application.StartupPath;
            adbPath = selfPath + "\\adb.exe";
            aaptPath = selfPath + "\\aapt.exe";
            logPath = selfPath + "\\log.txt";
            tmpIconPath = selfPath + "\\tmp.png";
            registerPath = selfPath + "\\RegisterApp.exe";
            //Log.Write(selfPath);
        }

        // typeName should looks like ".png" which is a standard keyname in HKEY_CLASSES_ROOT
        public static void setAssociatedFileType(string typeName, string app, string iconPath)
        {
            string fileType = getTypeKeyName(typeName);
            Registry.ClassesRoot.OpenSubKey(fileType + "\\shell\\open\\command", true).SetValue(null, app);
            Registry.ClassesRoot.OpenSubKey(fileType + "\\shell\\open\\DefaultIcon", true).SetValue(null, iconPath);
        }

        public static string getAssociatedFileType(string typeName)
        {
            string fileType = getTypeKeyName(typeName);
            return (string)Registry.ClassesRoot.OpenSubKey(fileType + "\\shell\\open\\command").GetValue(null);
        }

        public static string getTypeKeyName(string typeName)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(typeName);
            return (string)key.GetValue(null);
        }


        //刷新文件关联图标
        //[DllImport("shell32.dll")]
        //public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2); 
        //SHChangeNotify(0x8000000, 0, IntPtr.Zero, IntPtr.Zero);
    }
}
