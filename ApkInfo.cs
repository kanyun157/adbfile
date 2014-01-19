using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADBexplorer
{
    class ApkInfo
    {
        public string filePath;
        public string package;
        public string versionName;
        public string versionCode;
        public string versionDroid;
        public string size;
        public string arch;
        public string label;
        public string iconPath;
        public string sdkVersion;
        public string glVersion;
        public string glFeature;
        public List<string> uses_permission;
    }
}
