using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ADBexplorer
{
    class Aapt
    {
        private static string[] toAndroidVer = 
        { 
            "1.0",
            "1.1",
            "1.5",
            "1.6",
            "2.0",
            "2.01",
            "2.1",
            "2.2",
            "2.3",
            "2.3.3",
            "3.0",
            "3.1",
            "3.2",
            "4.0.1",
            "4.0.3",
            "4.1",
            "4.2"
        };
        public static bool GetApkInfo(string path, out ApkInfo apkInfo)
        {
            bool bret = true;
            apkInfo = null;

            StringBuilder result;
            bret = AdbCmd.ExecuteCommand(GlobalSys.aaptPath, "dump badging \""+path+"\"", out result);
            string str = result.ToString();
            string[] myarray = str.Split(new char[] { '\r', '\r', '\n' });
            if (bret)
            {
                apkInfo = new ApkInfo();
                apkInfo.filePath = path;
                apkInfo.uses_permission = new List<string>();
                for (int i = 0; i < myarray.Length; i++)
                {
                    if (myarray[i].Length > 0)
                    {
                        if (myarray[i].Contains("package:"))
                        {
                            apkInfo.package = GetQuoteString(myarray[i], "name=");
                            apkInfo.versionName = GetQuoteString(myarray[i], "versionName=");
                        }
                        else if (myarray[i].Contains("application:"))
                        {
                            apkInfo.label = GetQuoteString(myarray[i], "label=");
                            apkInfo.iconPath = GetQuoteString(myarray[i], "icon=");
                        }
                        else if (myarray[i].Contains("uses-permission:"))
                        {
                             apkInfo.uses_permission.Add(GetQuoteString(myarray[i], "uses-permission"));
                        }
                        else if (myarray[i].Contains("sdkVersion:"))
                        {
                            apkInfo.sdkVersion = GetQuoteString(myarray[i], "sdkVersion");
                            int ver = Int32.Parse(apkInfo.sdkVersion);
                            apkInfo.versionDroid = toAndroidVer[ver - 1];
                        }
                        else if (myarray[i].Contains("native-code:"))
                        {
                            apkInfo.arch = GetQuoteString(myarray[i], "native-code");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("");
            }
            return bret;
        }

        private static string GetQuoteString(string str, string key)
        {
            int index = str.IndexOf(key);
            int i;
            char[] chArray = str.ToCharArray();
            int start, end;
            end = start = index+key.Length;
            for (i = start; i < chArray.Length; i++)
            {
                if (chArray[i] == '=')
                {
                    end = i;
                    break;
                }
            }
            if (end == start)
                end = str.Length;
            string tmp = str.Substring(start, end - start);
            start = tmp.IndexOf("\'");
            end = tmp.LastIndexOf("\'");
            return tmp.Substring(start+1, end - start - 1);
        }

        private static string[] GetQuoteString(string str)
        {
            char[] chArray = str.ToCharArray();
            int i;
            int count = 0;
            for (i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == '\'')
                {
                    count++;
                }
            }
            if (count <= 1)
                return null;
            count = count / 2;

            string[] strArray = new string[count];
            int pos = 0;
            count = 0;
            bool newquote=true;
            for (i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == '\'')
                {
                    if (newquote)
                    {
                        pos = i;
                    }
                    else
                    {
                        strArray[count] = str.Substring(pos+1, i - pos-1);
                        count++;
                    }
                    newquote = !newquote;
                }
            }
            return strArray;
        }
    }
}
