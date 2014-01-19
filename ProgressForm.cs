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
    public partial class ProgressForm : KryptonForm
    {
        bool switchToBack = true;
 
        public ProgressForm(bool toBack)
        {
            InitializeComponent();
            switchToBack = false;// toBack;
        }

   
        public void setTitle(string title, string content)
        {
            labelContent.Text = content;
            labelTitle.Text = title;
        }

        public bool setProgress(int value)
        {
            if (value == 1)
            {
                this.Close();
            }

            return false;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            this.loadingProgress1.Start();
        }

    }
}
