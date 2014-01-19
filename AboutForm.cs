using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADBexplorer
{
    public partial class AboutForm : KryptonForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            Version ApplicationVersion = new Version(Application.ProductVersion);
            this.kryptonLabel1.Text = "cold手机助手 v" + ApplicationVersion.ToString();
            this.kryptonTextBox1.Text = "功能很简单的android文件管理器，主要用于拷贝文件，安装apk。\r\n"
            + "虽然很小，但没有扰人的弹窗打扰&自动安装。\r\n"
            + "属自娱自用的小软件－－老猫.";
        }
    }
}
