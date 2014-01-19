using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using System.Management;
using System.Globalization;
using System.Diagnostics;
using System.Threading;

namespace ADBexplorer
{
    public partial class MainFrom : KryptonForm
    {
        enum ViewID
        {
            VIEW_FILE_MANAGE = 0,
            VIEW_APK_MANAGE = 1,
        };

        const int DIR_IMAGE_KEY = 0;
        const int FILE_NOEXT_IMAGE_KEY = 1;
        const int FILE_APK_IMAGE_KEY = 2;
        const int FILE_DOC_IMAGE_KEY = 3;
        const int FILE_XLS_IMAGE_KEY = 4;
        const int FILE_PPT_IMAGE_KEY = 5;
        const int FILE_TXT_IMAGE_KEY = 6;
        const int FILE_PDF_IMAGE_KEY = 7;
        const int FILE_ZIP_IMAGE_KEY = 8;
        const int FILE_PIC_IMAGE_KEY = 9;
        const int FILE_MP3_IMAGE_KEY = 10;
        const int FILE_MP4_IMAGE_KEY = 11;

        string[] fileIconKey={
                                "mydir_icon",
                                "noext_icon",
                                ".apk",
                                ".doc;.docx",
                                ".xls;.xlsx",
                                ".ppt;.pptx",
                                ".txt",
                                ".pdf",
                                ".7z;.zip;.rar",
                                ".jpg;.png;.bmp",
                                ".mp3;.wmv",
                                ".mp4;.3gp;.avi;.mov"
                            };

        ImageList imageListFile;
        string strPcDir;
     

        string strPhoneDir;

        List<PhoneFileInfo> phoneFiles;

        AppPanel appPanel;

        bool isNewDir = false;
        string oldName;
        Point lastRightMousePos;

        public MainFrom()
        {
            InitializeComponent();
            appPanel = new AppPanel();
            this.panelMain.Controls.Add(appPanel);

            //GlobalSys.setAssociatedFileType(".apk", "\"F:\\myf\\project\\weiyun\\ADB\\bin\\Debug\\ADBexplorer.exe\" \"%1\"");

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        void SwitchToView(ViewID view)
        {
            if (view == ViewID.VIEW_FILE_MANAGE)
            {
                this.panelFileManager.Dock = DockStyle.Fill;
                this.panelFileManager.Show();
                this.appPanel.Hide();
                this.kryptonCheckSet1.CheckedIndex = 0;
                this.checkButtonFile.Checked = true;
                this.checkButtonApk.Checked = false;
            }
            else
            {
                this.appPanel.Dock = DockStyle.Fill;
                this.appPanel.Show();
                this.panelFileManager.Hide();
                this.kryptonCheckSet1.CheckedIndex = 1;
                this.checkButtonFile.Checked = false;
                this.checkButtonApk.Checked = true;
            }
        }

        public void AddAndSwitchToApk(string path)
        {
            this.appPanel.AddApkToList(path);
            SwitchToView(ViewID.VIEW_APK_MANAGE);
            GlobalSys.startArg = null;
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            AdbCmd.SetReady(); 

            InitImageList();
            InitContextMenu();

            InitPcFolder();
            InitPhoneFolder();

            if (GlobalSys.startArg == null)
                SwitchToView(ViewID.VIEW_FILE_MANAGE);
            else
            {
                SwitchToView(ViewID.VIEW_APK_MANAGE);
            }
        }

        void InitImageList()
        {
            imageListFile = new ImageList();
            
            imageListFile.ColorDepth = ColorDepth.Depth24Bit;
            //imageListFile.ImageSize = new System.Drawing.Size(32, 32);
   
            imageListFile.Images.Add(fileIconKey[DIR_IMAGE_KEY], m_imageListTreeView.Images[2]);
            imageListFile.Images.Add(fileIconKey[FILE_NOEXT_IMAGE_KEY], m_imageListTreeView.Images[4]);

            imageListFile.Images.Add(fileIconKey[FILE_APK_IMAGE_KEY], m_imageListTreeView.Images[9]);
            imageListFile.Images.Add(fileIconKey[FILE_DOC_IMAGE_KEY], m_imageListTreeView.Images[18]);
            imageListFile.Images.Add(fileIconKey[FILE_XLS_IMAGE_KEY], m_imageListTreeView.Images[10]);
            imageListFile.Images.Add(fileIconKey[FILE_PPT_IMAGE_KEY], m_imageListTreeView.Images[16]);
            imageListFile.Images.Add(fileIconKey[FILE_TXT_IMAGE_KEY], m_imageListTreeView.Images[17]);
            imageListFile.Images.Add(fileIconKey[FILE_PDF_IMAGE_KEY], m_imageListTreeView.Images[15]);
            imageListFile.Images.Add(fileIconKey[FILE_ZIP_IMAGE_KEY], m_imageListTreeView.Images[19]);
            imageListFile.Images.Add(fileIconKey[FILE_PIC_IMAGE_KEY], m_imageListTreeView.Images[12]);
            imageListFile.Images.Add(fileIconKey[FILE_MP3_IMAGE_KEY], m_imageListTreeView.Images[14]);
            imageListFile.Images.Add(fileIconKey[FILE_MP4_IMAGE_KEY], m_imageListTreeView.Images[13]);
        }

        void InitContextMenu()
        {
            this.listPCFile.ContextMenuStrip = menuPcFile;
            this.listPhoneFile.ContextMenuStrip = menuPhoneFile;
        }

        string GetFileIconKey(string ext)
        {
            for (int i = 2; i < fileIconKey.Length; i++ )
            {
                if (fileIconKey[i].Contains(ext.ToLower()))
                    return fileIconKey[i];
            }
            return fileIconKey[1];
        }

        #region pc folders
        private void InitPcFolder()
        {
            // Populate TreeView with Drive list
            treePC.ImageList = m_imageListTreeView;

            listPCFile.SmallImageList = imageListFile;
            listPCFile.LargeImageList = imageListFile;

            PopulatePcDriveList();
        }


        //文档列表
        protected void InitPcListView()
        {
            //init ListView control
            listPCFile.Clear();		//clear control
            //create column header for ListView
            listPCFile.Columns.Add("名称", 150, System.Windows.Forms.HorizontalAlignment.Left);
            listPCFile.Columns.Add("大小", 75, System.Windows.Forms.HorizontalAlignment.Right);
            listPCFile.Columns.Add("创建时间", 120, System.Windows.Forms.HorizontalAlignment.Left);
            listPCFile.Columns.Add("修改时间", 120, System.Windows.Forms.HorizontalAlignment.Left);

        }
        //This procedure populate the TreeView with the Drive list
        private void PopulatePcDriveList()
        {
            TreeNode nodeTreeNode;
            int imageIndex = 0;
            int selectIndex = 0;

            const int Removable = 2;
            const int LocalDisk = 3;
            const int Network = 4;
            const int CD = 5;
            //const int RAMDrive = 6;

            this.Cursor = Cursors.WaitCursor;
            //clear TreeView
            treePC.Nodes.Clear();
            nodeTreeNode = new TreeNode("My Computer", 0, 0);
            treePC.Nodes.Add(nodeTreeNode);

            //set node collection
            TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;

            //Get Drive list
            ManagementObjectCollection queryCollection = getDrives();
            foreach (ManagementObject mo in queryCollection)
            {

                switch (int.Parse(mo["DriveType"].ToString()))
                {
                    case Removable:			//removable drives
                        imageIndex = 5;
                        selectIndex = 5;
                        break;
                    case LocalDisk:			//Local drives
                        imageIndex = 6;
                        selectIndex = 6;
                        break;
                    case CD:				//CD rom drives
                        imageIndex = 7;
                        selectIndex = 7;
                        break;
                    case Network:			//Network drives
                        imageIndex = 8;
                        selectIndex = 8;
                        break;
                    default:				//defalut to folder
                        imageIndex = 2;
                        selectIndex = 3;
                        break;
                }
                //create new drive node
                nodeTreeNode = new TreeNode(mo["Name"].ToString() + "\\", imageIndex, selectIndex);
                nodeTreeNode.Tag = mo["Name"].ToString() + "\\";

                //add new node
                nodeCollection.Add(nodeTreeNode);

            }


            //Init files ListView
            InitPcListView();

            this.Cursor = Cursors.Default;

        }

        //从文件全名返回路径
        protected string GetPcPath(string fileFullName)
        {
            int end = fileFullName.LastIndexOf("\\");
            return fileFullName.Substring(0, end);
        }

        //从文件全名返回文件名
        protected string GetPcFileName(string fileFullName)
        {
            //Get Name of folder
            string[] stringSplit = fileFullName.Split('\\');
            int _maxIndex = stringSplit.Length;
            return stringSplit[_maxIndex - 1];
        }

        //从文件全名得到扩展名
        protected string GetExtName(string fileFullName)
        {
            int end = fileFullName.LastIndexOf(".");
            return fileFullName.Substring(end);
        }

        //显示目录列表
        protected void PopulatePcDirectory(TreeNode nodeCurrent, TreeNodeCollection nodeCurrentCollection)
        {
            TreeNode nodeDir;
            int imageIndex = 2;		//unselected image index
            int selectIndex = 3;	//selected image index

            if (nodeCurrent.SelectedImageIndex != 0)
            {
                //populate treeview with folders
                try
                {
                    //check path
                    if (Directory.Exists((string)nodeCurrent.Tag) == false)
                    {
                        MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
                    }
                    else
                    {
                        strPcDir = (string)nodeCurrent.Tag;

                        //populate files
                        PopulatePcFiles(strPcDir);

                        string[] stringDirectories = Directory.GetDirectories(strPcDir);
                        string stringFullPath = "";
                        string stringPathName = "";

                        //loop throught all directories
                        foreach (string stringDir in stringDirectories)
                        {
                            stringFullPath = stringDir;
                            stringPathName = GetPcFileName(stringFullPath);

                            //create node for directories
                            nodeDir = new TreeNode(stringPathName, imageIndex, selectIndex);
                            nodeDir.Tag = strPcDir + "\\" + stringPathName;
                            nodeCurrentCollection.Add(nodeDir);
                        }
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show("Error: Drive not ready or directory does not exist.");
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show("Error: Drive or directory access denided.");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }
        }

        //显示文件列表
        protected void PopulatePcFiles(string dirPath)
        {
            //Populate listview with files
            string[] lvData = new string[4];

            //clear list
            InitPcListView();

            //if (nodeCurrent.SelectedImageIndex != 0)
            {
                //check path
                if (Directory.Exists(dirPath) == false)
                {
                    MessageBox.Show("Directory or path " + dirPath + " does not exist.");
                }
                else
                {
                    try
                    {
                        string[] stringFiles = Directory.GetFiles(dirPath);
                        string stringFileName = "";
                        DateTime dtCreateDate, dtModifyDate;
                        Int64 lFileSize = 0;

                        ///////directory
                        string[] stringDirectories = Directory.GetDirectories(dirPath);
                        string stringFullPath = "";
                        string stringPathName = "";

                        //loop throught all directories
                        foreach (string stringDir in stringDirectories)
                        { 
                            lvData[0] = GetPcFileName(stringDir);

                            //FileInfo objFileSize = new FileInfo(stringFileName);

                            //Create actual list item
                            ListViewItem lvItem = new ListViewItem(lvData, 0);
                            lvItem.ImageKey = fileIconKey[DIR_IMAGE_KEY];
                            
                            listPCFile.Items.Add(lvItem);
                        }

                        //loop throught all files
                        foreach (string stringFile in stringFiles)
                        {
                            stringFileName = stringFile;
                            FileInfo objFileSize = new FileInfo(stringFileName);
                            lFileSize = objFileSize.Length;
                            dtCreateDate = objFileSize.CreationTime; //GetCreationTime(stringFileName);
                            dtModifyDate = objFileSize.LastWriteTime; //GetLastWriteTime(stringFileName);

                            //create listview data
                            lvData[0] = GetPcFileName(stringFileName);
                            lvData[1] = formatSize(lFileSize);

                            //check if file is in local current day light saving time
                            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtCreateDate) == false)
                            {
                                //not in day light saving time adjust time
                                lvData[2] = formatDate(dtCreateDate.AddHours(1));
                            }
                            else
                            {
                                //is in day light saving time adjust time
                                lvData[2] = formatDate(dtCreateDate);
                            }

                            //check if file is in local current day light saving time
                            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtModifyDate) == false)
                            {
                                //not in day light saving time adjust time
                                lvData[3] = formatDate(dtModifyDate.AddHours(1));
                            }
                            else
                            {
                                //not in day light saving time adjust time
                                lvData[3] = formatDate(dtModifyDate);
                            }

                            //Create actual list item
                            ListViewItem lvItem = new ListViewItem(lvData, 0);

                            // Check to see if the image collection contains an image
                            // for this extension, using the extension as a key.
                            if (objFileSize.Extension.Length > 0)
                            {
                                /*if (!imageListFile.Images.ContainsKey(objFileSize.Extension))
                                {
                                    // Set a default icon for the file.
                                    Icon iconForFile = SystemIcons.WinLogo;
                                    iconForFile = Icon.ExtractAssociatedIcon(stringFileName);
                                    imageListFile.Images.Add(objFileSize.Extension, iconForFile);
                                }
                                lvItem.ImageKey = objFileSize.Extension;*/
                                lvItem.ImageKey = GetFileIconKey(objFileSize.Extension);
                            }
                            else
                            {
                                lvItem.ImageKey = fileIconKey[FILE_NOEXT_IMAGE_KEY];
                            }

                            listPCFile.Items.Add(lvItem);
                        }
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show("Error: Drive not ready or directory does not exist.");
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        MessageBox.Show("Error: Drive or directory access denided.");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error: " + e);
                    }
                }
            }
        }

        protected ManagementObjectCollection getDrives()
        {
            //get drive collection
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk ");
            ManagementObjectCollection queryCollection = query.Get();

            return queryCollection;
        }

        protected string formatDate(DateTime dtDate)
        {
            //Get date and time in short format
            string stringDate = "";

            stringDate = dtDate.ToShortDateString().ToString() + " " + dtDate.ToShortTimeString().ToString();

            return stringDate;
        }

        protected string formatSize(Int64 lSize)
        {
            //Format number to KB
            string stringSize = "";
            NumberFormatInfo myNfi = new NumberFormatInfo();

            Int64 lKBSize = 0;

            if (lSize < 1024)
            {
                if (lSize == 0)
                {
                    //zero byte
                    stringSize = "0";
                }
                else
                {
                    //less than 1K but not zero byte
                    stringSize = "1";
                }
            }
            else
            {
                //convert to KB
                lKBSize = lSize / 1024;
                //format number with default format
                stringSize = lKBSize.ToString("n", myNfi);
                //remove decimal
                stringSize = stringSize.Replace(".00", "");
            }

            return stringSize + " KB";

        }

        private void treePC_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Populate folders and files when a folder is selected
            this.Cursor = Cursors.WaitCursor;

            //get current selected drive or folder
            TreeNode nodeCurrent = e.Node;
            strPcDir = (string)treePC.SelectedNode.Tag;

            //clear all sub-folders
            nodeCurrent.Nodes.Clear();

            if (nodeCurrent.SelectedImageIndex == 0)
            {
                //Selected My Computer - repopulate drive list
                PopulatePcDriveList();
            }
            else
            {
                //populate sub-folders and folder files
                PopulatePcDirectory(nodeCurrent, nodeCurrent.Nodes);
            }
            this.Cursor = Cursors.Default;
            this.txtPcDir.Text = strPcDir;
        }

        //用相应的应用程序打开文件
        private void listPCFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (strPcDir.Length > 0)
            {
                ListViewItem lvItem = listPCFile.SelectedItems[0];
                FileInfo objFileSize = new FileInfo(Path.Combine(strPcDir, lvItem.Text));
                if ((objFileSize.Attributes&FileAttributes.Directory)!=0)
                {
                    strPcDir = Path.Combine(strPcDir, lvItem.Text);
                    foreach (TreeNode node in this.treePC.SelectedNode.Nodes)
                    {
                        if (node.Text.Equals(lvItem.Text))
                        {
                            this.treePC.SelectedNode = node;
                            break;
                        }
                    }
                    //PopulatePcFiles(strPcDir);
                }
                else
                    Process.Start(Path.Combine(strPcDir, lvItem.Text));
            }
        }

        private void listPCFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (strPcDir.Length > 0)
            {
                //ListViewItem lvItem = listPCFile.SelectedItems[0];
                //strPcFile = Path.Combine(strPcDir, lvItem.Text);
            }
        }

        #endregion pc folders


        private void treePhone_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Populate folders and files when a folder is selected
            this.Cursor = Cursors.WaitCursor;

            //get current selected drive or folder
            TreeNode nodeCurrent = e.Node;
            strPhoneDir = (string)treePhone.SelectedNode.Tag;

            //clear all sub-folders
            nodeCurrent.Nodes.Clear();

            //populate sub-folders and folder files
            PopulatePhoneDirectory(nodeCurrent, nodeCurrent.Nodes);

            this.Cursor = Cursors.Default;
            this.txtPhoneDir.Text = strPhoneDir;
        }

        private void listPhoneFile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitPhoneFolder()
        {
            // Populate TreeView with Drive list
            treePhone.ImageList = m_imageListTreeView;

            listPhoneFile.SmallImageList = imageListFile;
            listPhoneFile.LargeImageList = imageListFile;

            ConnectADB();
            cbxDevices.Items.Clear();
            cbxDevices.Items.Add("请选择设备");
            cbxDevices.SelectedIndex = 0;

            //PopulateRootList();
        }

        void ConnectADB()
        {
            AdbCmd.SelectDevice(null);
            AdbCmd.ExecuteADBCommandNoWait("start-server");
        }
        void ListDevices()
        {
            StringBuilder strBuilder;
            bool bret = AdbCmd.ExecuteADBCommand("devices", out strBuilder);
            cbxDevices.Items.Clear();
            cbxDevices.Items.Add("请选择设备");
            if (bret)
            {
                string str = strBuilder.ToString();
                string[] myarray = str.Split(new char[] { '\r', '\r', '\n' });
                 for (int i = 0; i < myarray.Length; i++)
                 {
                     if (myarray[i].Length > 0 && !myarray[i].Contains("devices attached"))
                     {
                         string[] myarray2 = myarray[i].Split(new char[] { '\t' });
                         if (myarray2.Length>0 &&myarray2[1].Contains("device"))
                            cbxDevices.Items.Add(myarray2[0]);
                     }
                 }
            }

            cbxDevices.SelectedIndex = 0;
        }

        //文档列表
        protected void InitPhoneListView()
        {
            //init ListView control
            listPhoneFile.Clear();		//clear control
            //create column header for ListView
            listPhoneFile.Columns.Add("名称", 150, System.Windows.Forms.HorizontalAlignment.Left);
            listPhoneFile.Columns.Add("大小", 75, System.Windows.Forms.HorizontalAlignment.Right);
            listPhoneFile.Columns.Add("修改时间", 120, System.Windows.Forms.HorizontalAlignment.Left);
            listPhoneFile.Columns.Add("权限", 50, System.Windows.Forms.HorizontalAlignment.Left);
            listPhoneFile.Columns.Add("备注", 120, System.Windows.Forms.HorizontalAlignment.Left);
        }


        //This procedure populate the TreeView with the Drive list
        private void PopulateRootList()
        {
            TreeNode nodeTreeNode;

            this.Cursor = Cursors.WaitCursor;
            //clear TreeView
            treePhone.Nodes.Clear();
            nodeTreeNode = new TreeNode("My Device", 0, 0);
            nodeTreeNode.Tag = "/";
            treePhone.Nodes.Add(nodeTreeNode);

            //set node collection
            TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;
            PopulatePhoneDirectory(nodeTreeNode, nodeCollection);

            //Init files ListView
            InitPhoneListView();

            this.Cursor = Cursors.Default;
        }

        void PopulatePhoneFiles(string dirPath)
        {
            //clear list
            InitPhoneListView();

            bool bret = bret = AdbFile.GetAllFileInfo(dirPath, out phoneFiles);
            if (!bret)
                return;


            for (int i = 0; i < phoneFiles.Count; i++)
            {
                PhoneFileInfo info = phoneFiles[i];
                string[] lvData = new string[5];
                if (info != null)
                {
                    lvData[0] = info.name;
                    lvData[1] = info.size;
                    lvData[2] = info.modifyDate + " " + info.modifyTime;
                    lvData[3] = info.permission;

                    if (!info.isFile)
                    {
                        if (info.isLink)
                        {
                            lvData[4] = info.linkName;
                        }
                        ListViewItem lvItem = new ListViewItem(lvData, 0);
                        lvItem.ImageKey = fileIconKey[DIR_IMAGE_KEY];
                        lvItem.Tag = info;
                        listPhoneFile.Items.Add(lvItem);
                    }
                    else
                    {
                        if (info.isLink)
                        {
                            lvData[4] = info.linkName;
                        }
                        ListViewItem lvItem = new ListViewItem(lvData, 0);
                        string ext = "";
                        if (info.name.LastIndexOf('.') >= 0)
                        {
                            ext = info.name.Substring(info.name.LastIndexOf('.'));
                        }
                        if (ext.Length > 0)
                        {
                            lvItem.ImageKey = GetFileIconKey(ext);
                        }
                        else
                        {
                            lvItem.ImageKey = fileIconKey[FILE_NOEXT_IMAGE_KEY];
                        }
                        lvItem.Tag = info;
                        listPhoneFile.Items.Add(lvItem);
                    }
                }
            }
        }


        //显示目录列表
        protected void PopulatePhoneDirectory(TreeNode nodeCurrent, TreeNodeCollection nodeCurrentCollection)
        {
            TreeNode nodeDir;
            int imageIndex = 2;		//unselected image index
            int selectIndex = 3;	//selected image index
     

            //if (nodeCurrent.SelectedImageIndex != 0)
            {
                //populate treeview with folders
                try
                {
                    //check path
                    if (AdbFile.DirExists((string)nodeCurrent.Tag) == false)
                    {
                        MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
                    }
                    else
                    {
                        //populate files
                        /*PopulatePcFiles(nodeCurrent); 

                        string[] stringDirectories = Directory.GetDirectories(getPcFullPath(nodeCurrent.FullPath));
                        string stringFullPath = "";
                        string stringPathName = "";

                        //loop throught all directories
                        foreach (string stringDir in stringDirectories)
                        {
                            stringFullPath = stringDir;
                            stringPathName = GetPcFileName(stringFullPath);

                            //create node for directories
                            nodeDir = new TreeNode(stringPathName.ToString(), imageIndex, selectIndex);
                            nodeCurrentCollection.Add(nodeDir);
                        }*/
                        //clear list
                        InitPhoneListView();

                        strPhoneDir = (string)nodeCurrent.Tag;

                        bool bret = false;
                        if (nodeCurrent.SelectedImageIndex == 0)
                            bret = AdbFile.GetAllFileInfo("/", out phoneFiles);
                        else
                            bret = AdbFile.GetAllFileInfo(strPhoneDir, out phoneFiles);
                        if (!bret)
                            return;

                        
                        for (int i = 0; i < phoneFiles.Count; i++)
                        {
                            PhoneFileInfo info = phoneFiles[i];
                            string[] lvData = new string[5];
                            if (info != null)
                            {
                                lvData[0] = info.name;
                                lvData[1] = info.size;
                                lvData[2] = info.modifyDate+" "+info.modifyTime;
                                lvData[3] = info.permission;
                                
                                if (!info.isFile)
                                {
                                    //if (!info.isLink)
                                    {
                                        nodeDir = new TreeNode(info.name, imageIndex, selectIndex);
                                        if (info.isLink)
                                            nodeDir.Tag = strPhoneDir+info.linkName;
                                        else
                                            nodeDir.Tag = strPhoneDir + "/" + info.name;
                                        nodeCurrentCollection.Add(nodeDir);
                                    }

                                    if (info.isLink)
                                    {
                                        lvData[4] = info.linkName;
                                    }
                                    ListViewItem lvItem = new ListViewItem(lvData, 0);
                                    lvItem.ImageKey = fileIconKey[DIR_IMAGE_KEY];
                                    lvItem.Tag = info;
                                    listPhoneFile.Items.Add(lvItem);
                                }
                                else
                                {    
                                    if (info.isLink)
                                    {
                                        lvData[4] = info.linkName;
                                    }
                                    ListViewItem lvItem = new ListViewItem(lvData, 0);
                                    string ext = "";
                                    if (info.name.LastIndexOf('.') >=0)
                                    {
                                        ext = info.name.Substring(info.name.LastIndexOf('.'));
                                    }
                                    if (ext.Length > 0)
                                    {
                                        lvItem.ImageKey = GetFileIconKey(ext);
                                    }
                                    else
                                    {
                                        lvItem.ImageKey = fileIconKey[FILE_NOEXT_IMAGE_KEY];
                                    }
                                    lvItem.Tag = info;
                                    listPhoneFile.Items.Add(lvItem);
                                }
                            }
                        }
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show("Error: Drive not ready or directory does not exist.");
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show("Error: Drive or directory access denided.");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }
        }
      

        private void listPhoneFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (strPhoneDir.Length > 0)
            {
                ListViewItem lvItem = listPhoneFile.SelectedItems[0];
                PhoneFileInfo fileInfo = (PhoneFileInfo)lvItem.Tag;
                if (!fileInfo.isFile)
                {
                    strPhoneDir = strPhoneDir + "/" + lvItem.Text;
                    foreach (TreeNode node in this.treePhone.SelectedNode.Nodes)
                    {
                        if (node.Text.Equals(lvItem.Text))
                        {
                            this.treePhone.SelectedNode = node;
                            break;
                        }
                    }
                }
            }
        }

        void RefreshPcFiles()
        {
            int lastTopIndex = -1;
            if (listPCFile.TopItem!=null)
                lastTopIndex = this.listPCFile.TopItem.Index;

            //PopulatePcFiles(this.strPcDir);
            //Populate folders and files when a folder is selected
            this.Cursor = Cursors.WaitCursor;
            strPcDir = (string)treePC.SelectedNode.Tag;

            //clear all sub-folders
            treePC.SelectedNode.Nodes.Clear();

            if (treePC.SelectedNode.SelectedImageIndex == 0)
            {
                PopulatePcDriveList();
            }
            else
            {
                PopulatePcDirectory(treePC.SelectedNode, treePC.SelectedNode.Nodes);
            }
            this.Cursor = Cursors.Default;


            if (lastTopIndex >= 0 && listPCFile.Items != null)
            {
                listPCFile.TopItem = listPCFile.Items[lastTopIndex];
                listPCFile.TopItem = listPCFile.Items[lastTopIndex];
            }
        }

        void RefreshPhoneFiles()
        {
            int lastTopIndex = -1;
            if (listPhoneFile.TopItem != null)
                lastTopIndex = this.listPhoneFile.TopItem.Index;
            //PopulatePhoneFiles(strPhoneDir);

            //Populate folders and files when a folder is selected
            this.Cursor = Cursors.WaitCursor;
            strPhoneDir = (string)treePhone.SelectedNode.Tag;

            //clear all sub-folders
            treePhone.SelectedNode.Nodes.Clear();

            //populate sub-folders and folder files
            PopulatePhoneDirectory(treePhone.SelectedNode, treePhone.SelectedNode.Nodes);
            this.Cursor = Cursors.Default;

            if (lastTopIndex >= 0 && listPhoneFile.Items != null)
                listPhoneFile.TopItem = listPhoneFile.Items[lastTopIndex];
        }

        private void btnPullFile_Click(object sender, EventArgs e)
        {
            //StringBuilder res;

            //AdbCmd.ExecuteADBCommand("shell busybox ls -1 -A -p --color=never /storage/sdcard0", out res);

            
            //string name = "mp3_44k_VBRI_爸爸妈妈王蓉.mp3";
            //byte[] data = System.Text.Encoding.UTF8.GetBytes(name);//system string->uft8 encoding
            //string nameUtf8 = System.Text.Encoding.Default.GetString(data);//utf8 encoding->system String
            //AdbCmd.ExecuteADBCommand("pull /mnt/sdcard/" + nameUtf8 + " D:\\dd.mp3", out res);

            //PullFileFunc(null);
            
            Thread t = new Thread(new ParameterizedThreadStart(PullFileFunc));
            t.Start();

            string str = "";
            int cnt = 0;
            foreach (ListViewItem item in this.listPhoneFile.SelectedItems)
            {
                str += item.Text + " ";
                cnt++;
                if (cnt > 4)
                    break;
            }
            str += "...";

            if (cnt > 0)
            {
                ShowProcessDialog("复制到电脑：", str);
                RefreshPcFiles();
            }
            
 
            //List<PhoneFileInfo> files;
            //AdbFile.GetAllFileInfo("/mnt/sdcard", out files);
        }

        private void btnPushFile_Click(object sender, EventArgs e)
        {
            //PushFileFunc(null);

            Thread t = new Thread(new ParameterizedThreadStart(PushFileFunc));
            t.Start();

            string str = "";
            int cnt = 0;
            foreach (ListViewItem item in this.listPCFile.SelectedItems)
            {
                str += item.Text + " ";
                cnt++;
                if (cnt > 4)
                    break;
            }
            str += "...";

            if (cnt > 0)
            {
                ShowProcessDialog("复制到设备:", str);
                RefreshPhoneFiles();
            }
        }

      

        private void kryptonCheckSet1_CheckedButtonChanged(object sender, EventArgs e)
        {
            if (checkButtonFile.Checked)
            {
                SwitchToView(ViewID.VIEW_FILE_MANAGE);
            }
            else if (checkButtonApk.Checked)
            {
                SwitchToView(ViewID.VIEW_APK_MANAGE);
            }
        }

        private delegate bool SetProgressHandler(int nValue);
        //进度条窗口
        private ProgressForm progressForm = null;
        //声明委托对象
        private SetProgressHandler setProgress = null;

        void PullFileFunc(object para)
        {
            foreach (ListViewItem item in this.listPhoneFile.SelectedItems)
            {
                AdbFile.PullFile(strPcDir + "\\", strPhoneDir + "/" + item.Text, false);
            }
            ShutProgressDialog();
        }

        void PushFileFunc(object para)
        {
            foreach (ListViewItem item in this.listPCFile.SelectedItems)
            {
                AdbFile.PushFile(strPhoneDir, strPcDir + "\\" + item.Text, false);
            }
            ShutProgressDialog();
        }

        void DeletePcFileFunc(object para)
        {
            foreach (ListViewItem item in this.listPCFile.SelectedItems)
            {
                FileInfo info = new FileInfo(strPcDir + "\\" + item.Text);
                if ((info.Attributes & FileAttributes.Directory) != 0)
                    Directory.Delete(strPcDir + "\\" + item.Text, true);
                else
                    File.Delete(strPcDir + "\\" + item.Text);
            }
            ShutProgressDialog();
        }

        void DeletePhoneFileFunc(object para)
        {
            foreach (ListViewItem item in this.listPhoneFile.SelectedItems)
            {
                PhoneFileInfo fileInfo = (PhoneFileInfo)item.Tag;
                if (!fileInfo.isFile)
                    AdbFile.DeleteFile(strPhoneDir + "/" + item.Text, true);
                else
                    AdbFile.DeleteFile(strPhoneDir + "/" + item.Text, false);
            }
            ShutProgressDialog();
        }

        void InstallApkFunc(object para)
        {
            foreach (ListViewItem item in this.listPCFile.SelectedItems)
            {
                FileInfo info = new FileInfo(strPcDir + "\\" + item.Text);
                if ((info.Attributes & FileAttributes.Directory) != 0)
                    ;
                else
                    AdbFile.InstallApk(strPcDir + "\\" + item.Text, true);
            }
            ShutProgressDialog();
        }

        void ShowProcessDialog(string title, string content)
        {
            progressForm = new ProgressForm(true);
            progressForm.setTitle(title, content);
     

            // 初始化进度条委托
            setProgress = new SetProgressHandler(progressForm.setProgress);
            progressForm.StartPosition = FormStartPosition.CenterParent;
            progressForm.ShowDialog();
            //progressForm = null;
            //setProgress = null;            
        }

        void ShowProcessDialog(string title)
        {
            progressForm = new ProgressForm(true);
            progressForm.setTitle(title, "");
          
            // 初始化进度条委托
            setProgress = new SetProgressHandler(progressForm.setProgress);
            progressForm.StartPosition = FormStartPosition.CenterParent;
            progressForm.ShowDialog();
            //progressForm = null;
            //setProgress = null;
        }

  


        private void ShutProgressDialog()
        {
            if (progressForm != null && this.setProgress != null)
            {
                this.Invoke(this.setProgress, new object[] { 1 });
                progressForm = null;
                setProgress = null;
            }
        }

        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要删除文件吗？", "警告", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            Thread t = new Thread(new ParameterizedThreadStart(DeletePcFileFunc));
            t.Start();
            string str = "";
            int cnt = 0;
            foreach (ListViewItem item in this.listPCFile.SelectedItems)
            {
                if(cnt>4)
                    break;
                str += item.Text + " ";
                cnt++;
            }
            str += "...";

            if (cnt > 0)
            {
                ShowProcessDialog("删除电脑文件：", str);
                RefreshPcFiles();
            }
        }

        private void phoneMenuDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要删除文件吗？", "警告", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            Thread t = new Thread(new ParameterizedThreadStart(DeletePhoneFileFunc));
            t.Start();
            string str = "";
            int cnt = 0;
            foreach (ListViewItem item in this.listPhoneFile.SelectedItems)
            {
                str += item.Text + " ";
                cnt++;
                if (cnt > 4)
                    break;
            }
            str += "...";

            if (cnt > 0)
            {
                ShowProcessDialog("删除设备文件：", str);
                RefreshPhoneFiles();
            }
        }

        private void phoneMenuRefresh_Click(object sender, EventArgs e)
        {
            RefreshPhoneFiles();    
        }

        private void menuItemRefresh_Click(object sender, EventArgs e)
        {
            RefreshPcFiles();   
        }

        private void menuItemInstall_Click(object sender, EventArgs e)
        {
            //InstallApkFunc(null);
            Thread t = new Thread(new ParameterizedThreadStart(InstallApkFunc));
            t.Start();
            string str = "";
            int cnt = 0;
            foreach (ListViewItem item in this.listPCFile.SelectedItems)
            {
                str += item.Text + " ";
                cnt++;
                if (cnt > 4)
                    break;
            }
            str += "...";

            if (cnt > 0)
            {
                ShowProcessDialog("正在安装：", str);
            }
        }

        private void cbxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDevices.SelectedIndex > 0)
            {
                AdbCmd.SelectDevice(cbxDevices.Items[cbxDevices.SelectedIndex].ToString());
                PopulateRootList();
            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            this.menuMore.Show(Control.MousePosition);
        }

        private void cbxDevices_DropDown(object sender, EventArgs e)
        {
            ListDevices();
        }

        private void menuItemRename_Click(object sender, EventArgs e)
        {
            if (listPCFile.SelectedItems.Count <= 0)
                return;
            ListViewItem item = listPCFile.SelectedItems[0];
            if (item != null)
            {
                oldName = item.Text;
                item.BeginEdit();
                isNewDir = false;
            }
        }

        

        private void listPCFile_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ListViewItem item = listPCFile.Items[e.Item];
            if (item == null)
                return;

            string newName = e.Label;
            if (newName == null)
                return;

            if (isNewDir)
            {
                Directory.CreateDirectory(Path.Combine(strPcDir, newName));
                isNewDir = false;
            }
            else
            {
                if (newName.Equals(oldName))
                    return;
                FileInfo info = new FileInfo(oldName);
                if ((info.Attributes & FileAttributes.Directory) != 0)
                {
                    Directory.Move(Path.Combine(strPcDir, oldName), Path.Combine(strPcDir, newName));
                }
                else
                    File.Move(Path.Combine(strPcDir, oldName), Path.Combine(strPcDir, newName));
            }
            //RefreshPcFiles();
        }

        private void menuItemNewDir_Click(object sender, EventArgs e)
        {
            if (strPcDir.Length > 0)
            {
                {
                    Point localPoint = lastRightMousePos;
                    ListViewItem item = listPCFile.GetItemAt(localPoint.X, localPoint.Y);
                    int index = 0;
                    if (item != null)
                    {
                        index = item.Index + 1;
                    }
                    ListViewItem newItem = listPCFile.Items.Insert(index, "新建文件夹");
                    newItem.ImageKey = fileIconKey[DIR_IMAGE_KEY];
                    listPCFile.SelectedItems.Clear();
                    newItem.Selected = true;
                    newItem.BeginEdit();
                    isNewDir = true;
                }
                
            }
        }

        private void listPCFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                lastRightMousePos = e.Location;
            }
        }

        private void phoneMenuNewDir_Click(object sender, EventArgs e)
        {
            if (strPhoneDir.Length > 0)
            {
                {
                    Point localPoint = lastRightMousePos;
                    ListViewItem item = listPhoneFile.GetItemAt(localPoint.X, localPoint.Y);

                    int index = 0;
                    if (item != null)
                    {
                        index = item.Index + 1;
                    }
                    ListViewItem newItem = listPhoneFile.Items.Insert(index, "NEW");
                    newItem.ImageKey = fileIconKey[DIR_IMAGE_KEY];
                    listPhoneFile.SelectedItems.Clear();
                    newItem.Selected = true;
                    newItem.BeginEdit();
                    isNewDir = true;
                }
            }
        }

        private void phoneMenuRename_Click(object sender, EventArgs e)
        {
            if (listPhoneFile.SelectedItems.Count <= 0)
                return;
            ListViewItem item = listPhoneFile.SelectedItems[0];
            if (item != null)
            {
                oldName = item.Text;
                item.BeginEdit();
                isNewDir = false;
            }
        }

        private void listPhoneFile_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ListViewItem item = listPhoneFile.Items[e.Item];
            if (item == null)
                return;

            string newName = e.Label;
            if (newName == null)
                return;

            if (isNewDir)
            {
                AdbFile.MakeDir(strPhoneDir, newName);
                isNewDir = false;
            }
            else
            {
                if (newName.Equals(oldName))
                    return;
                AdbFile.Rename(strPhoneDir, oldName, newName);
            }
            RefreshPhoneFiles();
        }

        private void listPhoneFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                lastRightMousePos = e.Location;
            }
        }


        private void listPCFile_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            oldName = listPCFile.Items[e.Item].Text;
        }

        private void listPhoneFile_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            oldName = listPhoneFile.Items[e.Item].Text;
        }

        private string[] GetPcSelection()
        {
            if (listPCFile.SelectedItems.Count == 0)
                return null;

            string[] files = new string[listPCFile.SelectedItems.Count];
            int i = 0;
            foreach (ListViewItem item in listPCFile.SelectedItems)
            {
                files[i++] = (strPcDir + "\\" + item.Text);
            }
            return files;
        }

        void CopyToClipboard(string[] files, bool cut)
        {
            if (files != null)
            {
                IDataObject data = new DataObject(DataFormats.FileDrop, files);
                MemoryStream memo = new MemoryStream(4);
                byte[] bytes = new byte[] { (byte)(cut ? 2 : 5), 0, 0, 0 };
                memo.Write(bytes, 0, bytes.Length);
                data.SetData("Preferred DropEffect", memo);
                Clipboard.SetDataObject(data);
            }
        }

        void PasteFromClipboard(string dstDir)
        {
            IDataObject data = Clipboard.GetDataObject();
            if (!data.GetDataPresent(DataFormats.FileDrop))
                return;

            string[] files = (string[])data.GetData(DataFormats.FileDrop);
            MemoryStream stream = (MemoryStream)data.GetData("Preferred DropEffect", true);
            int flag = stream.ReadByte();
            if (flag != 2 && flag != 5)
                return;
            bool cut = (flag == 2);
            foreach (string file in files)
            {
                string dest = dstDir + "\\" + Path.GetFileName(file);
                try
                {
                    if (cut)
                        File.Move(file, dest);
                    else
                        File.Copy(file, dest, false);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(this, "Failed to perform the specified operation:\n\n" + ex.Message, "File operation failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void menuItemCut_Click(object sender, EventArgs e)
        {
            string[] files = GetPcSelection();
            if (files != null)
            {
                CopyToClipboard(files, true);
            }
        }

        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            string[] files = GetPcSelection();
            if (files != null)
            {
                CopyToClipboard(files, false);
            }
        }

        private void menuItemPaste_Click(object sender, EventArgs e)
        {
            PasteFromClipboard(strPcDir);
            RefreshPcFiles();
        }

    }

}
