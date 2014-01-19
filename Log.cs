using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADBexplorer
{
    class Log
    {
        const bool DEBUG = false;
        public static void Write(string str)
        {
            if (DEBUG)
            {
                FileStream fs = new FileStream(GlobalSys.logPath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.Flush();
                // 使用StreamWriter来往文件中写入内容
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                // 把richTextBox1中的内容写入文件
                m_streamWriter.Write(str);
                //关闭此文件
                m_streamWriter.Flush();
                m_streamWriter.Close();
            }
        }

        public static void WriteCurrentTime()
        {
            if (DEBUG)
            {
                FileStream fs = new FileStream(GlobalSys.logPath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.Flush();
                // 使用StreamWriter来往文件中写入内容
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                // 把richTextBox1中的内容写入文件
                m_streamWriter.Write(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
                m_streamWriter.Write("\r\n");
                //关闭此文件
                m_streamWriter.Flush();
                m_streamWriter.Close();
            }
        }
    }
}
