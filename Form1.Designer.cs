namespace ADBexplorer
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtPcDir = new System.Windows.Forms.TextBox();
            this.listPCFile = new System.Windows.Forms.ListView();
            this.treePC = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhoneDir = new System.Windows.Forms.TextBox();
            this.listPhoneFile = new System.Windows.Forms.ListView();
            this.treePhone = new System.Windows.Forms.TreeView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnPull = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.m_imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(746, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appManagerToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // appManagerToolStripMenuItem
            // 
            this.appManagerToolStripMenuItem.Name = "appManagerToolStripMenuItem";
            this.appManagerToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.appManagerToolStripMenuItem.Text = "App manager";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtPcDir);
            this.splitContainer1.Panel1.Controls.Add(this.listPCFile);
            this.splitContainer1.Panel1.Controls.Add(this.treePC);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtPhoneDir);
            this.splitContainer1.Panel2.Controls.Add(this.listPhoneFile);
            this.splitContainer1.Panel2.Controls.Add(this.treePhone);
            this.splitContainer1.Panel2.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnNew);
            this.splitContainer1.Panel2.Controls.Add(this.btnPull);
            this.splitContainer1.Panel2.Controls.Add(this.btnPush);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(746, 459);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtPcDir
            // 
            this.txtPcDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPcDir.Location = new System.Drawing.Point(48, 4);
            this.txtPcDir.Name = "txtPcDir";
            this.txtPcDir.Size = new System.Drawing.Size(300, 21);
            this.txtPcDir.TabIndex = 3;
            // 
            // listPCFile
            // 
            this.listPCFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPCFile.HideSelection = false;
            this.listPCFile.Location = new System.Drawing.Point(4, 214);
            this.listPCFile.Name = "listPCFile";
            this.listPCFile.Size = new System.Drawing.Size(344, 245);
            this.listPCFile.TabIndex = 2;
            this.listPCFile.UseCompatibleStateImageBehavior = false;
            this.listPCFile.View = System.Windows.Forms.View.Details;
            this.listPCFile.SelectedIndexChanged += new System.EventHandler(this.listPCFile_SelectedIndexChanged);
            this.listPCFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listPCFile_MouseDoubleClick);
            // 
            // treePC
            // 
            this.treePC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePC.HideSelection = false;
            this.treePC.Location = new System.Drawing.Point(4, 31);
            this.treePC.Name = "treePC";
            this.treePC.Size = new System.Drawing.Size(344, 177);
            this.treePC.TabIndex = 1;
            this.treePC.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePC_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "电脑:";
            // 
            // txtPhoneDir
            // 
            this.txtPhoneDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneDir.Location = new System.Drawing.Point(118, 4);
            this.txtPhoneDir.Name = "txtPhoneDir";
            this.txtPhoneDir.Size = new System.Drawing.Size(270, 21);
            this.txtPhoneDir.TabIndex = 3;
            // 
            // listPhoneFile
            // 
            this.listPhoneFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPhoneFile.HideSelection = false;
            this.listPhoneFile.Location = new System.Drawing.Point(86, 214);
            this.listPhoneFile.Name = "listPhoneFile";
            this.listPhoneFile.Size = new System.Drawing.Size(305, 245);
            this.listPhoneFile.TabIndex = 3;
            this.listPhoneFile.UseCompatibleStateImageBehavior = false;
            this.listPhoneFile.View = System.Windows.Forms.View.Details;
            this.listPhoneFile.SelectedIndexChanged += new System.EventHandler(this.listPhoneFile_SelectedIndexChanged);
            // 
            // treePhone
            // 
            this.treePhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePhone.HideSelection = false;
            this.treePhone.Location = new System.Drawing.Point(86, 31);
            this.treePhone.Name = "treePhone";
            this.treePhone.Size = new System.Drawing.Size(305, 177);
            this.treePhone.TabIndex = 2;
            this.treePhone.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePhone_AfterSelect);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(5, 334);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 29);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(5, 280);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(5, 231);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 29);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(5, 179);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(75, 29);
            this.btnPull.TabIndex = 1;
            this.btnPull.Text = "<<";
            this.btnPull.UseVisualStyleBackColor = true;
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(5, 130);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(75, 29);
            this.btnPush.TabIndex = 1;
            this.btnPush.Text = ">>";
            this.btnPush.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "设备:";
            // 
            // m_imageListTreeView
            // 
            this.m_imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageListTreeView.ImageStream")));
            this.m_imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageListTreeView.Images.SetKeyName(0, "MyComputer.bmp");
            this.m_imageListTreeView.Images.SetKeyName(1, "FloppyDrive.bmp");
            this.m_imageListTreeView.Images.SetKeyName(2, "FolderClose.bmp");
            this.m_imageListTreeView.Images.SetKeyName(3, "FolderOpen.bmp");
            this.m_imageListTreeView.Images.SetKeyName(4, "File.bmp");
            this.m_imageListTreeView.Images.SetKeyName(5, "35FLOPPY.ICO");
            this.m_imageListTreeView.Images.SetKeyName(6, "525FLOP1.ICO");
            this.m_imageListTreeView.Images.SetKeyName(7, "CDDRIVE.ICO");
            this.m_imageListTreeView.Images.SetKeyName(8, "DRIVENET.ICO");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 483);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "ADB Explorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appManagerToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listPCFile;
        private System.Windows.Forms.TreeView treePC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listPhoneFile;
        private System.Windows.Forms.TreeView treePhone;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ImageList m_imageListTreeView;
        private System.Windows.Forms.TextBox txtPcDir;
        private System.Windows.Forms.TextBox txtPhoneDir;

    }
}

