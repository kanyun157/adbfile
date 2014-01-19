using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Management;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Text;

namespace ADBexplorer
{
    public partial class Form1 : Form
    {
        ImageList imageListFile;
        string strPcDir;
        string strPcFile;

        string strPhoneDir;
        string strPhoneFile;
        List<PhoneFileInfo> phoneFiles;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AdbCmd.SetReady();
            imageListFile = new ImageList();
            InitPcFolder();
            InitPhoneFolder();
        }

        #region pc folders
        private void InitPcFolder()
        {
            // Populate TreeView with Drive list
            treePC.ImageList = m_imageListTreeView;

            listPCFile.SmallImageList = imageListFile;

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
                    if (Directory.Exists(getPcFullPath(nodeCurrent.FullPath)) == false)
                    {
                        MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
                    }
                    else
                    {
                        //populate files
                        PopulatePcFiles(nodeCurrent);

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
        protected void PopulatePcFiles(TreeNode nodeCurrent)
        {
            //Populate listview with files
            string[] lvData = new string[4];

            //clear list
            InitPcListView();

            if (nodeCurrent.SelectedImageIndex != 0)
            {
                //check path
                if (Directory.Exists((string)getPcFullPath(nodeCurrent.FullPath)) == false)
                {
                    MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
                }
                else
                {
                    try
                    {
                        string[] stringFiles = Directory.GetFiles(getPcFullPath(nodeCurrent.FullPath));
                        string stringFileName = "";
                        DateTime dtCreateDate, dtModifyDate;
                        Int64 lFileSize = 0;

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

                            // Set a default icon for the file.
                            Icon iconForFile = SystemIcons.WinLogo;
                            iconForFile = Icon.ExtractAssociatedIcon(stringFileName);
                            // Check to see if the image collection contains an image
                            // for this extension, using the extension as a key.
                            if (!imageListFile.Images.ContainsKey(objFileSize.Extension))
                            {
                                // If not, add the image to the image list.
                                iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(stringFileName);
                                imageListFile.Images.Add(objFileSize.Extension, iconForFile);
                            }
                            lvItem.ImageKey = objFileSize.Extension;

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

        //
        protected string getPcFullPath(string stringPath)
        {
            //Get Full path
            string stringParse = "";
            //remove My Computer from path.
            stringParse = stringPath.Replace("My Computer\\", "");

            return stringParse;
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
            strPcDir = getPcFullPath(treePC.SelectedNode.FullPath);

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
        private void lvFiles_ItemActivate(object sender, EventArgs e)
        {
            if (strPcDir.Length > 0)
            {
                ListViewItem lvItem = listPCFile.SelectedItems[0];
                Process.Start(Path.Combine(strPcDir, lvItem.Text));
            }
        }

        private void listPCFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (strPcDir.Length > 0)
            {
                ListViewItem lvItem = listPCFile.SelectedItems[0];
                Process.Start(Path.Combine(strPcDir, lvItem.Text));
            }
        }

        private void listPCFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (strPcDir.Length > 0)
            {
                ListViewItem lvItem = listPCFile.SelectedItems[0];
                strPcFile = Path.Combine(strPcDir, lvItem.Text);
            }
        }

        #endregion pc folders




        private void btnNew_Click(object sender, EventArgs e)
        {
            StringBuilder res;
            
            //AdbCmd.ExecuteADBCommand("shell busybox ls -1 -A -p --color=never /storage/sdcard0", out res);

            string name = "并行优化.doc";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(name);//system string->uft8 encoding
            string nameUtf8 = System.Text.Encoding.Default.GetString(data);//utf8 encoding->system String
            AdbCmd.ExecuteADBCommand("pull /mnt/sdcard/" + nameUtf8 + " D:\\dd.doc", out res);

            //List<PhoneFileInfo> files;
            //AdbFile.GetAllFileInfo("/mnt/sdcard", out files);
        }

        private void treePhone_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Populate folders and files when a folder is selected
            this.Cursor = Cursors.WaitCursor;

            //get current selected drive or folder
            TreeNode nodeCurrent = e.Node;
            strPhoneDir = getPhoneFullPath(treePhone.SelectedNode.FullPath);

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

            PopulateRootList();
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
            listPhoneFile.Columns.Add("权限", 120, System.Windows.Forms.HorizontalAlignment.Left);
        }


        //This procedure populate the TreeView with the Drive list
        private void PopulateRootList()
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
            treePhone.Nodes.Clear();
            nodeTreeNode = new TreeNode("My Device", 0, 0);
            treePhone.Nodes.Add(nodeTreeNode);

            //set node collection
            TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;
            PopulatePhoneDirectory(nodeTreeNode, nodeCollection);

            //Init files ListView
            InitPhoneListView();

            this.Cursor = Cursors.Default;
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
                    if (AdbFile.DirExists(getPhoneFullPath(nodeCurrent.FullPath)) == false)
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
                        bool bret = false;
                        if (nodeCurrent.SelectedImageIndex == 0)
                            bret = AdbFile.GetAllFileInfo("/", out phoneFiles);
                        else
                            bret = AdbFile.GetAllFileInfo(getPhoneFullPath(nodeCurrent.FullPath), out phoneFiles);
                        if (!bret)
                            return;
                        for (int i = 0; i < phoneFiles.Count; i++)
                        {
                            PhoneFileInfo info = phoneFiles[i];
                            if (info != null)
                            {
                                if (!info.isFile)
                                {
                                    nodeDir = new TreeNode(info.name, imageIndex, selectIndex);
                                    nodeCurrentCollection.Add(nodeDir);
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

        //
        protected string getPhoneFullPath(string stringPath)
        {
            //Get Full path
            string stringParse = "";
            //remove My Computer from path.
            
            stringParse = stringPath.Replace("My Device\\", "/");
            stringParse = stringParse.Replace("\\", "/");

            return stringParse;
        }
    }
}
