namespace ADBexplorer
{
    partial class MainFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panelBar = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnMore = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.checkButtonApk = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.checkButtonFile = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.panelFileManager = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnPushFile = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnPullFile = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.listPCFile = new System.Windows.Forms.ListView();
            this.treePC = new System.Windows.Forms.TreeView();
            this.txtPcDir = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbxDevices = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.listPhoneFile = new System.Windows.Forms.ListView();
            this.treePhone = new System.Windows.Forms.TreeView();
            this.txtPhoneDir = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonCheckSet1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.m_imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.menuPcFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemNewDir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRename = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInstall = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.menuPhoneFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.phoneMenuNewDir = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneMenuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMore = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelBar)).BeginInit();
            this.panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFileManager)).BeginInit();
            this.panelFileManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.menuPcFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            this.menuPhoneFile.SuspendLayout();
            this.menuMore.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(0, 0);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton1.TabIndex = 0;
            this.kryptonButton1.Text = "Button";
            this.kryptonButton1.Values.ExtraText = "";
            this.kryptonButton1.Values.Image = null;
            this.kryptonButton1.Values.ImageStates.ImageCheckedNormal = null;
            this.kryptonButton1.Values.ImageStates.ImageCheckedPressed = null;
            this.kryptonButton1.Values.ImageStates.ImageCheckedTracking = null;
            this.kryptonButton1.Values.Text = "Button";
            // 
            // panelBar
            // 
            this.panelBar.Controls.Add(this.btnMore);
            this.panelBar.Controls.Add(this.checkButtonApk);
            this.panelBar.Controls.Add(this.checkButtonFile);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.HeaderForm;
            this.panelBar.Size = new System.Drawing.Size(796, 48);
            this.panelBar.TabIndex = 0;
            // 
            // btnMore
            // 
            this.btnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMore.Location = new System.Drawing.Point(759, 1);
            this.btnMore.Name = "btnMore";
            this.btnMore.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMore.Size = new System.Drawing.Size(36, 46);
            this.btnMore.TabIndex = 2;
            this.btnMore.Text = "更多";
            this.btnMore.Values.ExtraText = "";
            this.btnMore.Values.Image = null;
            this.btnMore.Values.ImageStates.ImageCheckedNormal = null;
            this.btnMore.Values.ImageStates.ImageCheckedPressed = null;
            this.btnMore.Values.ImageStates.ImageCheckedTracking = null;
            this.btnMore.Values.Text = "更多";
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // checkButtonApk
            // 
            this.checkButtonApk.Location = new System.Drawing.Point(131, 1);
            this.checkButtonApk.Name = "checkButtonApk";
            this.checkButtonApk.Size = new System.Drawing.Size(121, 46);
            this.checkButtonApk.TabIndex = 1;
            this.checkButtonApk.Text = "应用管理";
            this.checkButtonApk.Values.ExtraText = "";
            this.checkButtonApk.Values.Image = null;
            this.checkButtonApk.Values.Text = "应用管理";
            // 
            // checkButtonFile
            // 
            this.checkButtonFile.Location = new System.Drawing.Point(0, 1);
            this.checkButtonFile.Name = "checkButtonFile";
            this.checkButtonFile.Size = new System.Drawing.Size(131, 46);
            this.checkButtonFile.TabIndex = 0;
            this.checkButtonFile.Text = "文件管理";
            this.checkButtonFile.Values.ExtraText = "";
            this.checkButtonFile.Values.Image = null;
            this.checkButtonFile.Values.Text = "文件管理";
            // 
            // panelFileManager
            // 
            this.panelFileManager.Controls.Add(this.kryptonSplitContainer1);
            this.panelFileManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileManager.Location = new System.Drawing.Point(0, 0);
            this.panelFileManager.Name = "panelFileManager";
            this.panelFileManager.Size = new System.Drawing.Size(796, 478);
            this.panelFileManager.TabIndex = 1;
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonPanel1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.listPCFile);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.treePC);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.txtPcDir);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonLabel1);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.cbxDevices);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.listPhoneFile);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.treePhone);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.txtPhoneDir);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonLabel2);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(796, 478);
            this.kryptonSplitContainer1.SplitterDistance = 390;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnPushFile);
            this.kryptonPanel1.Controls.Add(this.btnPullFile);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonPanel1.Location = new System.Drawing.Point(361, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(29, 478);
            this.kryptonPanel1.TabIndex = 5;
            // 
            // btnPushFile
            // 
            this.btnPushFile.Location = new System.Drawing.Point(7, 330);
            this.btnPushFile.Name = "btnPushFile";
            this.btnPushFile.Size = new System.Drawing.Size(19, 25);
            this.btnPushFile.TabIndex = 0;
            this.btnPushFile.Text = ">";
            this.btnPushFile.Values.ExtraText = "";
            this.btnPushFile.Values.Image = null;
            this.btnPushFile.Values.ImageStates.ImageCheckedNormal = null;
            this.btnPushFile.Values.ImageStates.ImageCheckedPressed = null;
            this.btnPushFile.Values.ImageStates.ImageCheckedTracking = null;
            this.btnPushFile.Values.Text = ">";
            this.btnPushFile.Click += new System.EventHandler(this.btnPushFile_Click);
            // 
            // btnPullFile
            // 
            this.btnPullFile.Location = new System.Drawing.Point(7, 284);
            this.btnPullFile.Name = "btnPullFile";
            this.btnPullFile.Size = new System.Drawing.Size(19, 25);
            this.btnPullFile.TabIndex = 0;
            this.btnPullFile.Text = "<";
            this.btnPullFile.Values.ExtraText = "";
            this.btnPullFile.Values.Image = null;
            this.btnPullFile.Values.ImageStates.ImageCheckedNormal = null;
            this.btnPullFile.Values.ImageStates.ImageCheckedPressed = null;
            this.btnPullFile.Values.ImageStates.ImageCheckedTracking = null;
            this.btnPullFile.Values.Text = "<";
            this.btnPullFile.Click += new System.EventHandler(this.btnPullFile_Click);
            // 
            // listPCFile
            // 
            this.listPCFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPCFile.HideSelection = false;
            this.listPCFile.LabelEdit = true;
            this.listPCFile.Location = new System.Drawing.Point(0, 204);
            this.listPCFile.Name = "listPCFile";
            this.listPCFile.Size = new System.Drawing.Size(360, 274);
            this.listPCFile.TabIndex = 4;
            this.listPCFile.UseCompatibleStateImageBehavior = false;
            this.listPCFile.View = System.Windows.Forms.View.Details;
            this.listPCFile.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listPCFile_AfterLabelEdit);
            this.listPCFile.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listPCFile_BeforeLabelEdit);
            this.listPCFile.SelectedIndexChanged += new System.EventHandler(this.listPCFile_SelectedIndexChanged);
            this.listPCFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listPCFile_MouseClick);
            this.listPCFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listPCFile_MouseDoubleClick);
            // 
            // treePC
            // 
            this.treePC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePC.HideSelection = false;
            this.treePC.Location = new System.Drawing.Point(0, 31);
            this.treePC.Name = "treePC";
            this.treePC.Size = new System.Drawing.Size(360, 167);
            this.treePC.TabIndex = 3;
            this.treePC.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePC_AfterSelect);
            // 
            // txtPcDir
            // 
            this.txtPcDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPcDir.Location = new System.Drawing.Point(49, 3);
            this.txtPcDir.Name = "txtPcDir";
            this.txtPcDir.Size = new System.Drawing.Size(311, 22);
            this.txtPcDir.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(4, 4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Text = "电脑:";
            this.kryptonLabel1.Values.ExtraText = "";
            this.kryptonLabel1.Values.Image = null;
            this.kryptonLabel1.Values.Text = "电脑:";
            // 
            // cbxDevices
            // 
            this.cbxDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDevices.DropDownWidth = 98;
            this.cbxDevices.FormattingEnabled = false;
            this.cbxDevices.ItemHeight = 15;
            this.cbxDevices.Location = new System.Drawing.Point(40, 4);
            this.cbxDevices.Name = "cbxDevices";
            this.cbxDevices.Size = new System.Drawing.Size(98, 23);
            this.cbxDevices.TabIndex = 6;
            this.cbxDevices.DropDown += new System.EventHandler(this.cbxDevices_DropDown);
            this.cbxDevices.SelectedIndexChanged += new System.EventHandler(this.cbxDevices_SelectedIndexChanged);
            // 
            // listPhoneFile
            // 
            this.listPhoneFile.AllowDrop = true;
            this.listPhoneFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPhoneFile.HideSelection = false;
            this.listPhoneFile.LabelEdit = true;
            this.listPhoneFile.Location = new System.Drawing.Point(-2, 204);
            this.listPhoneFile.Name = "listPhoneFile";
            this.listPhoneFile.Size = new System.Drawing.Size(400, 274);
            this.listPhoneFile.TabIndex = 5;
            this.listPhoneFile.UseCompatibleStateImageBehavior = false;
            this.listPhoneFile.View = System.Windows.Forms.View.Details;
            this.listPhoneFile.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listPhoneFile_AfterLabelEdit);
            this.listPhoneFile.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listPhoneFile_BeforeLabelEdit);
            this.listPhoneFile.SelectedIndexChanged += new System.EventHandler(this.listPhoneFile_SelectedIndexChanged);
            this.listPhoneFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listPhoneFile_MouseClick);
            this.listPhoneFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listPhoneFile_MouseDoubleClick);
            // 
            // treePhone
            // 
            this.treePhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePhone.HideSelection = false;
            this.treePhone.Location = new System.Drawing.Point(0, 32);
            this.treePhone.Name = "treePhone";
            this.treePhone.Size = new System.Drawing.Size(398, 166);
            this.treePhone.TabIndex = 4;
            this.treePhone.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePhone_AfterSelect);
            // 
            // txtPhoneDir
            // 
            this.txtPhoneDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneDir.Location = new System.Drawing.Point(144, 4);
            this.txtPhoneDir.Name = "txtPhoneDir";
            this.txtPhoneDir.Size = new System.Drawing.Size(254, 22);
            this.txtPhoneDir.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(1, 6);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel2.TabIndex = 0;
            this.kryptonLabel2.Text = "设备:";
            this.kryptonLabel2.Values.ExtraText = "";
            this.kryptonLabel2.Values.Image = null;
            this.kryptonLabel2.Values.Text = "设备:";
            // 
            // kryptonCheckSet1
            // 
            this.kryptonCheckSet1.CheckButtons.Add(this.checkButtonFile);
            this.kryptonCheckSet1.CheckButtons.Add(this.checkButtonApk);
            this.kryptonCheckSet1.CheckedButtonChanged += new System.EventHandler(this.kryptonCheckSet1_CheckedButtonChanged);
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
            this.m_imageListTreeView.Images.SetKeyName(9, "appicon.png");
            this.m_imageListTreeView.Images.SetKeyName(10, "excel.png");
            this.m_imageListTreeView.Images.SetKeyName(11, "html32.png");
            this.m_imageListTreeView.Images.SetKeyName(12, "image.png");
            this.m_imageListTreeView.Images.SetKeyName(13, "movies.png");
            this.m_imageListTreeView.Images.SetKeyName(14, "music.png");
            this.m_imageListTreeView.Images.SetKeyName(15, "pdf.png");
            this.m_imageListTreeView.Images.SetKeyName(16, "ppt.png");
            this.m_imageListTreeView.Images.SetKeyName(17, "text.png");
            this.m_imageListTreeView.Images.SetKeyName(18, "word.png");
            this.m_imageListTreeView.Images.SetKeyName(19, "zip.png");
            // 
            // menuPcFile
            // 
            this.menuPcFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuPcFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCut,
            this.menuItemCopy,
            this.menuItemPaste,
            this.toolStripSeparator2,
            this.menuItemNewDir,
            this.menuItemRename,
            this.menuItemDelete,
            this.toolStripSeparator1,
            this.menuItemRefresh,
            this.menuItemInstall});
            this.menuPcFile.Name = "menuStripFile";
            this.menuPcFile.Size = new System.Drawing.Size(135, 192);
            // 
            // menuItemCut
            // 
            this.menuItemCut.Name = "menuItemCut";
            this.menuItemCut.Size = new System.Drawing.Size(134, 22);
            this.menuItemCut.Text = "剪切";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Name = "menuItemCopy";
            this.menuItemCopy.Size = new System.Drawing.Size(134, 22);
            this.menuItemCopy.Text = "复制";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Name = "menuItemPaste";
            this.menuItemPaste.Size = new System.Drawing.Size(134, 22);
            this.menuItemPaste.Text = "粘贴";
            this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(131, 6);
            // 
            // menuItemNewDir
            // 
            this.menuItemNewDir.Name = "menuItemNewDir";
            this.menuItemNewDir.Size = new System.Drawing.Size(134, 22);
            this.menuItemNewDir.Text = "新建文件夹";
            this.menuItemNewDir.Click += new System.EventHandler(this.menuItemNewDir_Click);
            // 
            // menuItemRename
            // 
            this.menuItemRename.Name = "menuItemRename";
            this.menuItemRename.Size = new System.Drawing.Size(134, 22);
            this.menuItemRename.Text = "重命名";
            this.menuItemRename.Click += new System.EventHandler(this.menuItemRename_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Size = new System.Drawing.Size(134, 22);
            this.menuItemDelete.Text = "删除";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // menuItemRefresh
            // 
            this.menuItemRefresh.Name = "menuItemRefresh";
            this.menuItemRefresh.Size = new System.Drawing.Size(134, 22);
            this.menuItemRefresh.Text = "刷新";
            this.menuItemRefresh.Click += new System.EventHandler(this.menuItemRefresh_Click);
            // 
            // menuItemInstall
            // 
            this.menuItemInstall.Name = "menuItemInstall";
            this.menuItemInstall.Size = new System.Drawing.Size(134, 22);
            this.menuItemInstall.Text = "安装";
            this.menuItemInstall.Click += new System.EventHandler(this.menuItemInstall_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelFileManager);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 48);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(796, 478);
            this.panelMain.TabIndex = 2;
            // 
            // menuPhoneFile
            // 
            this.menuPhoneFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuPhoneFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phoneMenuNewDir,
            this.phoneMenuRename,
            this.phoneMenuDelete,
            this.phoneMenuRefresh});
            this.menuPhoneFile.Name = "menuPhoneFile";
            this.menuPhoneFile.Size = new System.Drawing.Size(135, 92);
            // 
            // phoneMenuNewDir
            // 
            this.phoneMenuNewDir.Name = "phoneMenuNewDir";
            this.phoneMenuNewDir.Size = new System.Drawing.Size(134, 22);
            this.phoneMenuNewDir.Text = "新建文件夹";
            this.phoneMenuNewDir.Click += new System.EventHandler(this.phoneMenuNewDir_Click);
            // 
            // phoneMenuRename
            // 
            this.phoneMenuRename.Name = "phoneMenuRename";
            this.phoneMenuRename.Size = new System.Drawing.Size(134, 22);
            this.phoneMenuRename.Text = "重命名";
            this.phoneMenuRename.Click += new System.EventHandler(this.phoneMenuRename_Click);
            // 
            // phoneMenuDelete
            // 
            this.phoneMenuDelete.Name = "phoneMenuDelete";
            this.phoneMenuDelete.Size = new System.Drawing.Size(134, 22);
            this.phoneMenuDelete.Text = "删除";
            this.phoneMenuDelete.Click += new System.EventHandler(this.phoneMenuDelete_Click);
            // 
            // phoneMenuRefresh
            // 
            this.phoneMenuRefresh.Name = "phoneMenuRefresh";
            this.phoneMenuRefresh.Size = new System.Drawing.Size(134, 22);
            this.phoneMenuRefresh.Text = "刷新";
            this.phoneMenuRefresh.Click += new System.EventHandler(this.phoneMenuRefresh_Click);
            // 
            // menuMore
            // 
            this.menuMore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuMore.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
            this.menuMore.Name = "menuMore";
            this.menuMore.Size = new System.Drawing.Size(153, 48);
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(152, 22);
            this.menuItemAbout.Text = "关于";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 526);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cold手机助手";
            this.Load += new System.EventHandler(this.MainFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelBar)).EndInit();
            this.panelBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelFileManager)).EndInit();
            this.panelFileManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.menuPcFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.menuPhoneFile.ResumeLayout(false);
            this.menuMore.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelBar;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelFileManager;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet kryptonCheckSet1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton checkButtonFile;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton checkButtonApk;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPcDir;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ListView listPCFile;
        private System.Windows.Forms.TreeView treePC;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPhoneDir;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.ListView listPhoneFile;
        private System.Windows.Forms.TreeView treePhone;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPushFile;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPullFile;
        private System.Windows.Forms.ImageList m_imageListTreeView;
        private System.Windows.Forms.ContextMenuStrip menuPcFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewDir;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelMain;
        private System.Windows.Forms.ContextMenuStrip menuPhoneFile;
        private System.Windows.Forms.ToolStripMenuItem phoneMenuNewDir;
        private System.Windows.Forms.ToolStripMenuItem phoneMenuDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnMore;
        private System.Windows.Forms.ToolStripMenuItem menuItemRename;
        private System.Windows.Forms.ToolStripMenuItem phoneMenuRename;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem phoneMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemInstall;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbxDevices;
        private System.Windows.Forms.ContextMenuStrip menuMore;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem menuItemCut;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;



    }
}