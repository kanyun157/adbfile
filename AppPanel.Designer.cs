namespace ADBexplorer
{
    partial class AppPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnInstallApk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labelApkName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textApkPath = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.labelSystemVer = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labelVersion = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labelSize = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.listApk = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全不选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.kryptonLinkLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnInstallApk);
            this.kryptonPanel1.Controls.Add(this.kryptonPanel2);
            this.kryptonPanel1.Controls.Add(this.listApk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(605, 462);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnInstallApk
            // 
            this.btnInstallApk.Location = new System.Drawing.Point(488, 26);
            this.btnInstallApk.Name = "btnInstallApk";
            this.btnInstallApk.Size = new System.Drawing.Size(104, 30);
            this.btnInstallApk.TabIndex = 8;
            this.btnInstallApk.Text = "安装";
            this.btnInstallApk.Values.ExtraText = "";
            this.btnInstallApk.Values.Image = null;
            this.btnInstallApk.Values.ImageStates.ImageCheckedNormal = null;
            this.btnInstallApk.Values.ImageStates.ImageCheckedPressed = null;
            this.btnInstallApk.Values.ImageStates.ImageCheckedTracking = null;
            this.btnInstallApk.Values.Text = "安装";
            this.btnInstallApk.Click += new System.EventHandler(this.btnInstallApk_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonLinkLabel1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.labelApkName);
            this.kryptonPanel2.Controls.Add(this.textApkPath);
            this.kryptonPanel2.Controls.Add(this.labelSystemVer);
            this.kryptonPanel2.Controls.Add(this.labelVersion);
            this.kryptonPanel2.Controls.Add(this.labelSize);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.pictureBox1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.TabOneNote;
            this.kryptonPanel2.Size = new System.Drawing.Size(286, 462);
            this.kryptonPanel2.TabIndex = 7;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(25, 26);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel4.TabIndex = 10;
            this.kryptonLabel4.Text = "应用详情：";
            this.kryptonLabel4.Values.ExtraText = "";
            this.kryptonLabel4.Values.Image = null;
            this.kryptonLabel4.Values.Text = "应用详情：";
            // 
            // labelApkName
            // 
            this.labelApkName.Location = new System.Drawing.Point(117, 89);
            this.labelApkName.Name = "labelApkName";
            this.labelApkName.Size = new System.Drawing.Size(88, 20);
            this.labelApkName.TabIndex = 9;
            this.labelApkName.Text = "kryptonLabel4";
            this.labelApkName.Values.ExtraText = "";
            this.labelApkName.Values.Image = null;
            this.labelApkName.Values.Text = "kryptonLabel4";
            // 
            // textApkPath
            // 
            this.textApkPath.Location = new System.Drawing.Point(25, 152);
            this.textApkPath.Multiline = true;
            this.textApkPath.Name = "textApkPath";
            this.textApkPath.ReadOnly = true;
            this.textApkPath.Size = new System.Drawing.Size(224, 37);
            this.textApkPath.TabIndex = 8;
            this.textApkPath.Text = "kryptonTextBox1";
            // 
            // labelSystemVer
            // 
            this.labelSystemVer.Location = new System.Drawing.Point(108, 253);
            this.labelSystemVer.Name = "labelSystemVer";
            this.labelSystemVer.Size = new System.Drawing.Size(88, 20);
            this.labelSystemVer.TabIndex = 7;
            this.labelSystemVer.Text = "kryptonLabel4";
            this.labelSystemVer.Values.ExtraText = "";
            this.labelSystemVer.Values.Image = null;
            this.labelSystemVer.Values.Text = "kryptonLabel4";
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(108, 227);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(88, 20);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "kryptonLabel4";
            this.labelVersion.Values.ExtraText = "";
            this.labelVersion.Values.Image = null;
            this.labelVersion.Values.Text = "kryptonLabel4";
            // 
            // labelSize
            // 
            this.labelSize.Location = new System.Drawing.Point(108, 201);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(88, 20);
            this.labelSize.TabIndex = 7;
            this.labelSize.Text = "kryptonLabel4";
            this.labelSize.Values.ExtraText = "";
            this.labelSize.Values.Image = null;
            this.labelSize.Values.Text = "kryptonLabel4";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(39, 253);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Text = "系统要求:";
            this.kryptonLabel3.Values.ExtraText = "";
            this.kryptonLabel3.Values.Image = null;
            this.kryptonLabel3.Values.Text = "系统要求:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(39, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(39, 227);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Text = "应用版本:";
            this.kryptonLabel2.Values.ExtraText = "";
            this.kryptonLabel2.Values.Image = null;
            this.kryptonLabel2.Values.Text = "应用版本:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(39, 201);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Text = "应用大小:";
            this.kryptonLabel1.Values.ExtraText = "";
            this.kryptonLabel1.Values.Image = null;
            this.kryptonLabel1.Values.Text = "应用大小:";
            // 
            // listApk
            // 
            this.listApk.AllowDrop = true;
            this.listApk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listApk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listApk.CheckBoxes = true;
            this.listApk.ContextMenuStrip = this.contextMenuStrip1;
            this.listApk.FullRowSelect = true;
            this.listApk.GridLines = true;
            this.listApk.Location = new System.Drawing.Point(308, 62);
            this.listApk.MultiSelect = false;
            this.listApk.Name = "listApk";
            this.listApk.Size = new System.Drawing.Size(294, 397);
            this.listApk.TabIndex = 0;
            this.listApk.UseCompatibleStateImageBehavior = false;
            this.listApk.View = System.Windows.Forms.View.Details;
            this.listApk.SelectedIndexChanged += new System.EventHandler(this.listApk_SelectedIndexChanged);
            this.listApk.DragDrop += new System.Windows.Forms.DragEventHandler(this.listApk_DragDrop);
            this.listApk.DragEnter += new System.Windows.Forms.DragEventHandler(this.listApk_DragEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全选ToolStripMenuItem,
            this.全不选ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 70);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // 全不选ToolStripMenuItem
            // 
            this.全不选ToolStripMenuItem.Name = "全不选ToolStripMenuItem";
            this.全不选ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.全不选ToolStripMenuItem.Text = "全不选";
            this.全不选ToolStripMenuItem.Click += new System.EventHandler(this.全不选ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // kryptonLinkLabel1
            // 
            this.kryptonLinkLabel1.AutoSize = false;
            this.kryptonLinkLabel1.Location = new System.Drawing.Point(25, 279);
            this.kryptonLinkLabel1.Name = "kryptonLinkLabel1";
            this.kryptonLinkLabel1.Size = new System.Drawing.Size(211, 56);
            this.kryptonLinkLabel1.TabIndex = 11;
            this.kryptonLinkLabel1.Text = "kryptonLinkLabel1swerwerwesssssssssssssss";
            this.kryptonLinkLabel1.Values.ExtraText = "";
            this.kryptonLinkLabel1.Values.Image = null;
            this.kryptonLinkLabel1.Values.Text = "kryptonLinkLabel1swerwerwesssssssssssssss";
            // 
            // AppPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "AppPanel";
            this.Size = new System.Drawing.Size(605, 462);
            this.Load += new System.EventHandler(this.AppPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ListView listApk;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnInstallApk;
        private System.Windows.Forms.ImageList imageList1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelSystemVer;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelVersion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelSize;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全不选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textApkPath;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelApkName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel1;
    }
}
