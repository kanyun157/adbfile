using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ADBexplorer
{
    class AdbFile
    {
        public static List<string> GetDirectories(string path)
        {  
            List<string> dirArray = new List<string>();
            StringBuilder result;
            if (AdbCmd.ExecuteADBCommand("shell busybox ls -1 -A -p --color=never " + path, out result))
            {
                string str = result.ToString();
                if (str.EndsWith("daemon not running"))
                {
                    Log.Write("ADB server not running\r\n");
                    //Log.Write("Starting ADB server..\r\n");
                }
                else if (str.EndsWith("device offline"))
                {
                    Log.Write("device offline\r\n");
                }
                else
                {
                    string[] myarray = str.Split(new char[] { '\r', '\r', '\n' });
                    for (int i = 0; i < myarray.Length; i++)
                    {
                        if (myarray[i].EndsWith("/"))
                        {
                            string tmp = myarray[i].Substring(0, myarray[i].Length-1);
                            dirArray.Add(tmp);
                        }
                    }
                }
            }

            /*string[] strDirs = null;
            if (dirArray.Count>0)
            {
                strDirs = new string[dirArray.Count];
                for (int i=0; i<dirArray.Count; i++)
                {
                    strDirs[i] = (string)dirArray[i];
                }
            }*/
            return dirArray;
        }

        public static List<string> GetFiles(string path)
        {
            List<string> fileArray = new List<string>();
            StringBuilder result;
            if (AdbCmd.ExecuteADBCommand("shell busybox ls -1 -A -p --color=never " + path, out result))
            {
                string str = result.ToString();
                if (str.EndsWith("daemon not running"))
                {
                    Log.Write("ADB server not running\r\n");
                    //Log.Write("Starting ADB server..\r\n");
                }
                else if (str.EndsWith("device offline"))
                {
                    Log.Write("device offline\r\n");
                }
                else
                {
                    string[] myarray = str.Split(new char[] { '\r', '\r', '\n' });
                    for (int i = 0; i < myarray.Length; i++)
                    {
                        if (myarray[i].Length>0 && !myarray[i].EndsWith("/"))
                        {
                            string tmp = myarray[i].Substring(0, myarray[i].Length);
                            fileArray.Add(tmp);
                        }
                    }
                }
            }

            /*string[] strFiles = null;
            if (fileArray.Count > 0)
            {
                strFiles = new string[fileArray.Count];
                for (int i = 0; i < fileArray.Count; i++)
                {
                    strFiles[i] = (string)fileArray[i];
                }
            }*/
            return fileArray;
        }

        
        public static bool GetAllFileInfo(string path, out List<PhoneFileInfo> fileList)
        {
            bool bret = true;
            fileList = null;

            StringBuilder result;
            if (AdbCmd.ExecuteADBCommand("shell busybox ls -l -A -p -e --color=never " + path, out result))
            {
                string str = result.ToString();
                {               
                    string[] myarray = str.Split(new char[] { '\r', '\r', '\n' });
                    /*if (myarray.Length>0 && !AdbCmd.DoAdbErrorCheck(myarray[0]))
                    {
                        bret = false;
                    }
                    else*/
                    {
                        fileList = new List<PhoneFileInfo>();
                        for (int i = 0; i < myarray.Length; i++)
                        {
                            if (myarray[i].Length > 0 && AdbCmd.DoAdbErrorCheck(myarray[i]))
                            {
                                PhoneFileInfo info = ParseLsString(myarray[i]);
                                if (info != null)
                                    fileList.Add(info);
                            }
                        }
                    }
                }
            }
            else
            {
                bret = false;
            }

            return bret;
        }

        static private PhoneFileInfo ParseLsString(string strLine)
        {
            
            /*
            0:string permission;
            1:string node;
            2:string user;
            3:string group;
            4:string size;
            5:string day;
            6:string month;
            7:string date;
            8:string time;
            9:string year;
            10:string name;*/
            if (strLine == null || strLine.Length == 0)
                return null;
            PhoneFileInfo info = null;
            char[] chArray = strLine.ToCharArray();
            info = new PhoneFileInfo();
            string[] columns = new string[11];
            int start, end;
            bool lastIsSpace = false;
            start = 0;
            int i, col;
            for (col = 0, i = start; i < chArray.Length; i++)
            {
                if (col < 10)
                {
                    if (chArray[i] == ' ')
                    {
                        
                        if (!lastIsSpace)
                        {
                            end = i;
                            columns[col] = strLine.Substring(start, end-start);
                            col++;
                        }
                        start = i+1;
                        lastIsSpace = true;
                    }
                    else
                    {
                        lastIsSpace = false;
                    }
                }
                else
                {
                    start = i;
                    break;
                }
            }
            if (col < 10)
                return null;
            columns[col] = strLine.Substring(start, strLine.Length-start);

            info.permission = columns[0];
            info.size = columns[4];
            info.modifyDate = columns[9] + " " + columns[6] + " " + columns[7];
            info.modifyTime = columns[8];
            if (columns[10].Substring(columns[10].Length - 1).Equals("/"))
            {
                info.isFile = false;
                if (columns[10].Contains("->"))
                {
                    string[] strs = SplitStr(columns[10], " -> ");//columns[10].Split(" -> ".ToCharArray());
                    info.isLink = true;
                    info.name = strs[0];
                    info.linkName = strs[1].Substring(0, strs[1].Length-1);
                }
                else
                    info.name = columns[10].Substring(0, columns[10].Length - 1);
            }
            else
            {
                info.isFile = true;
                if (columns[10].Contains("->"))
                {
                    string[] strs = SplitStr(columns[10], " -> ");// columns[10].Split(" -> ".ToCharArray());
                    info.isLink = true;
                    info.name = strs[0];
                    info.linkName = strs[1];
                }
                else
                    info.name = columns[10].Substring(0, columns[10].Length);
            }
            return info;
        }

        private static string[] SplitStr(string input, string pattern)
        {
            return Regex.Split(input, pattern);
        }

        public static PhoneFileInfo GetFileInfo(string path)
        {
            PhoneFileInfo info = new PhoneFileInfo();
            
            return info;
        }

        public static bool DirExists(string path)
        {
            return true;
        }

        public static string GetPhoneFileName(string path)
        {
            int index = path.LastIndexOf("/");
            if (index >= 0 && index<path.Length)
                return path.Substring(index+1);

            return null;
        }

        public static string GetPcFileName(string path)
        {
            int index = path.LastIndexOf("\\");
            if (index >= 0 && index < path.Length)
                return path.Substring(index + 1);

            return null;
        }

        public static string GetPcFilePath(string path)
        {
            int index = path.LastIndexOf("\\");
            if (index >= 0 && index < path.Length)
                return path.Substring(0, index+1);

            return null;
        }

        public static bool MovePcFile(string srcPath, string dstPath)
        {
            bool bret = true;

            FileInfo info = new FileInfo(srcPath);
            if (info.Exists)
            {
                File.Move(srcPath, dstPath);
            }
            else
                bret = false;

            return bret;
        }

        public static string GetPhoneFilePath(string path)
        {
            int index = path.LastIndexOf("/");
            if (index >= 0 && index<path.Length)
                return path.Substring(0, index+1);

            return null;
        }


        public static bool PullFile(string dstPath, string srcPath, bool isDir)
        {
            bool bret = true;
            StringBuilder res;
            if (!isDir)
            {
                byte[] srcData = System.Text.Encoding.UTF8.GetBytes(srcPath);//system string->uft8 encoding
                string srcPathUtf8 = System.Text.Encoding.Default.GetString(srcData);//utf8 encoding->system String

                string dstName = GetPhoneFileName(srcPath);

                string cmd = "pull \"" + srcPathUtf8 + "\" \"" + dstPath + dstName + "\"";
                AdbCmd.ExecuteADBCommand(cmd, out res);
            }
            return bret;
        }

        public static bool PushFile(string dstPath, string srcPath, bool isDir)
        {
            bool bret = true;
            StringBuilder res;
            if (!isDir)
            {
                string dstName = GetPcFileName(srcPath);
                dstName = dstPath + "/" + dstName;
                byte[] dstData = System.Text.Encoding.UTF8.GetBytes(dstName);//system string->uft8 encoding
                string dstPathUtf8 = System.Text.Encoding.Default.GetString(dstData);//utf8 encoding->system String

                string cmd = "push \"" + srcPath + "\" \"" + dstPathUtf8+"\"";
                bret = AdbCmd.ExecuteADBCommand(cmd, out res);
                string strres = res.ToString();
            }
            return bret;
        }

        public static bool MakeDir(string path, string name)
        {
            bool bret = true;

            StringBuilder res;
       
            {
                byte[] srcData = System.Text.Encoding.UTF8.GetBytes(path+"//"+name);//system string->uft8 encoding
                string srcPathUtf8 = System.Text.Encoding.Default.GetString(srcData);//utf8 encoding->system String

                string cmd = "shell mkdir " + srcPathUtf8;
                bret = AdbCmd.ExecuteADBCommand(cmd, out res);
            }

            return bret;
        }

        public static bool Rename(string path, string oldName, string newName)
        {
            bool bret = true;

            StringBuilder res;

            {
                byte[] srcData = System.Text.Encoding.UTF8.GetBytes(path + "/" + oldName);//system string->uft8 encoding
                string srcPathUtf8 = System.Text.Encoding.Default.GetString(srcData);//utf8 encoding->system String
                srcData = System.Text.Encoding.UTF8.GetBytes(path + "/" + newName);//system string->uft8 encoding
                string newPathUtf8 = System.Text.Encoding.Default.GetString(srcData);//utf8 encoding->system String

                string cmd = "shell mv " + srcPathUtf8 + " "+newPathUtf8;
                bret = AdbCmd.ExecuteADBCommand(cmd, out res);
            }

            return bret;
        }

        public static bool DeleteFile(string srcPath, bool isDir)
        {
            bool bret = true;
            StringBuilder res;
            
            byte[] srcData = System.Text.Encoding.UTF8.GetBytes(srcPath);//system string->uft8 encoding
            string srcPathUtf8 = System.Text.Encoding.Default.GetString(srcData);//utf8 encoding->system String

            string cmdDir = "shell rm -r \"" + srcPathUtf8 + "\"";
            string cmdFile = "shell rm \"" + srcPathUtf8+"\""; ;
            if (isDir)
                bret = AdbCmd.ExecuteADBCommand(cmdDir, out res);
            else
                bret = AdbCmd.ExecuteADBCommand(cmdFile, out res);
          
            return bret;
        }

        public static bool InstallApk(string srcPath, bool toSdcard)
        {
            bool bret = true;
            StringBuilder res;

            string srcDir = GetPcFilePath(srcPath);
            string srcName = GetPcFileName(srcPath);
            Random rand = new Random();
            string tmpName = "tmpname" + rand.Next(10001) + ".apk";
            string newPath = srcDir + tmpName;
            MovePcFile(srcPath, newPath);

            string cmdToSdcard = "install -s \"" + newPath + "\"";
            string cmdDefault = "install \"" + newPath + "\"";
            if (toSdcard)
            {
                bret = AdbCmd.ExecuteADBCommand(cmdToSdcard, out res);
                if (!bret)
                    bret = AdbCmd.ExecuteADBCommand(cmdDefault, out res);
            }
            else
            {
                bret = AdbCmd.ExecuteADBCommand(cmdDefault, out res);
            }

            MovePcFile(newPath, srcPath);

            string strres = res.ToString();
            return bret;
        }

        public static bool InstallApk(ApkInfo apkInfo, bool toSdcard)
        {
            bool bret = true;
            StringBuilder res;

            string srcPath = apkInfo.filePath;
            string srcDir = GetPcFilePath(srcPath);
            string srcName = GetPcFileName(srcPath);
            Random rand = new Random();
            string tmpName = "tmpname" + rand.Next(10001) + ".apk";
            string newPath = srcDir + tmpName;
            MovePcFile(srcPath, newPath);
            apkInfo.filePath = newPath;

            string cmdToSdcard = "install -s \"" + newPath + "\"";
            string cmdDefault = "install \"" + newPath + "\"";
            if (toSdcard)
            {
                bret = AdbCmd.ExecuteADBCommand(cmdToSdcard, out res);
                if (!bret)
                    bret = AdbCmd.ExecuteADBCommand(cmdDefault, out res);
            }
            else
            {
                bret = AdbCmd.ExecuteADBCommand(cmdDefault, out res);
            }

            MovePcFile(newPath, srcPath);
            apkInfo.filePath = srcPath;

            string strres = res.ToString();
            return bret;
        }
    }
}
