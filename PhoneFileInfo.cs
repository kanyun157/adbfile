using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADBexplorer
{
    class PhoneFileInfo
    {
        public bool isFile = false;
        public bool isLink = false;
        public string linkName;
        public string name;
        public string size = "";
        public string modifyDate;
        public string modifyTime;
        public string permission;
        public string info;
        public string GetRealName()
        {
            if (isLink)
                return linkName;
            else
                return name;
        }
    }
}
