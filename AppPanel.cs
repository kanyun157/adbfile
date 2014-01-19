using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using ICSharpCode.SharpZipLib.Zip;
using System.Runtime.InteropServices;

namespace ADBexplorer
{
    public partial class AppPanel : UserControl
    {
        const string APK_INSTALLED = "已安装";
        const string APK_INSTALLING = "安装中..";
        const string APK_NOT_INSTALL = "待安装";
        const string APK_INSTALL_FAILED = "安装失败";
        public AppPanel()
        {
            InitializeComponent();
            setApkIconHandler = new SetIconHandler(SetApkIcon);
            setApkStatus = new SetItemTextHandler(SetItemSubText);
        }

        void InitListView()
        {
            listApk.Clear();		//clear control
            //create column header for ListView
            listApk.Columns.Add("名称", 300, System.Windows.Forms.HorizontalAlignment.Center);
            listApk.Columns.Add("状态", 80, System.Windows.Forms.HorizontalAlignment.Center);
            //listApk.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listApk.SmallImageList = imageList1;
        }

        Image ReadApkIcon(string path, string entryPath)
        {
            Image img = null;
            FileStream fs = File.Open(path, FileMode.Open);
            if (fs == null)
                return img;

            ZipFile file = new ZipFile(fs);
            ZipEntry entry = file.GetEntry(entryPath);

            if (entry != null && entry.IsFile)
            {
                FileStream writer = File.Create(GlobalSys.tmpIconPath);//解压后的文件
                Stream stream = file.GetInputStream(entry);

                int bufferSize = 1024; //缓冲区大小
                int readCount = 0; //读入缓冲区的实际字节
                byte[] buffer = new byte[bufferSize];
                readCount = stream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    writer.Write(buffer, 0, readCount);
                    readCount = stream.Read(buffer, 0, bufferSize);
                }

                writer.Close();
                writer.Dispose();
                stream.Close();
                stream.Dispose();
                Bitmap bmp = new Bitmap(GlobalSys.tmpIconPath);
                img = new Bitmap(bmp);
                bmp.Dispose(); bmp = null;
            }
            fs.Close();
            return img;
        }
        Image ReadApkIcon(string path)
        {
            Image img = null;

            try
            {
                FileStream fs = File.Open(path, FileMode.Open);
                if (fs == null)
                    return img;
                ZipInputStream zipStream = new ZipInputStream(fs); 
                ZipEntry entry = zipStream.GetNextEntry();
                while (entry != null)
                {
                    if (!entry.IsFile)
                    {
                        continue;
                    }
                    if (entry.Name.EndsWith("drawable/ic_launcher.png")
                        || entry.Name.EndsWith("drawable/icon.png")
                        || entry.Name.EndsWith("dpi/ic_launcher.png")
                        || entry.Name.EndsWith("dpi/icon.png"))
                    {
                        FileStream writer = File.Create(GlobalSys.tmpIconPath);//解压后的文件

                        int bufferSize = 1024; //缓冲区大小
                        int readCount = 0; //读入缓冲区的实际字节
                        byte[] buffer = new byte[bufferSize];
                        readCount = zipStream.Read(buffer, 0, bufferSize);
                        while (readCount > 0)
                        {
                            writer.Write(buffer, 0, readCount);
                            readCount = zipStream.Read(buffer, 0, bufferSize);
                        }

                        writer.Close();
                        writer.Dispose();
                        Bitmap bmp = new Bitmap(GlobalSys.tmpIconPath);
                        img = new Bitmap(bmp);
                        bmp.Dispose(); bmp = null;
                        break;
                    }
                    entry = zipStream.GetNextEntry();
                }
                fs.Close();
                zipStream.Close();
                zipStream.Dispose();
                zipStream = null;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }

            
            return img;
        }

        public bool AddApk(string[] FileList)
        {
            foreach (string path in FileList)
            {
                if (path.EndsWith(".apk"))
                {
                    AddApkItem(path, null);
                }
            }

            return true;
        }

        private bool AddApkItem(string path, Image img)
        {
            string name = AdbFile.GetPcFileName(path);
            string[] lvData = new string[2] { name, APK_NOT_INSTALL };
            ListViewItem item = new ListViewItem(lvData);
            ApkInfo apkInfo;
            Aapt.GetApkInfo(path, out apkInfo);
            item.Tag = apkInfo;
            item.Checked = true;
            if (img != null)
            {
                imageList1.Images.Add(name, img);
                img.Dispose();
                img = null;
                item.ImageKey = name;
            }

            listApk.Items.Add(item);
            return true;
        }

        bool SetApkIcon(ListViewItem item, Image img)
        {
            if (img != null)
            {
                imageList1.Images.Add(item.Text, img);
                img.Dispose();
                img = null;
                item.ImageKey = item.Text;
                
            }
            return true;
        }

        bool SetItemSubText(ListViewItem item, string text)
        {
            item.SubItems[1].Text = text;
            return true;
        }

        private void btnInstallApk_Click(object sender, EventArgs e)
        {
            if (listApk.CheckedItems == null || listApk.CheckedItems.Count == 0)
                return;

            Thread t = new Thread(new ParameterizedThreadStart(InstallApkFunc));
            t.Start();
            
            /*string str = "";
            int cnt = 0;
            foreach (ListViewItem item in listApk.CheckedItems)
            {
                if (item.SubItems[1].Text.Equals(APK_NOT_INSTALL))
                {
                    str += item.Text + " ";
                    cnt++;
                }
                if (cnt > 4)
                    break;
            }
            str += "...";
            if (cnt>0)
                ShowProcessDialog("正在安装：", str);*/
        }

        delegate bool SetIconHandler(ListViewItem item, Image img);
        delegate bool SetItemTextHandler(ListViewItem item, string text);
        SetIconHandler setApkIconHandler;
        SetItemTextHandler setApkStatus;
        void updateApkIconFunc(object para)
        {
            foreach (ListViewItem item in listApk.Items)
            {
                ApkInfo apkInfo = (ApkInfo)item.Tag;
                //Image img = ReadApkIcon(apkInfo.filePath);
                Image img = ReadApkIcon(apkInfo.filePath, apkInfo.iconPath);
                this.Invoke(this.setApkIconHandler, new object[] { item, img});
            }
        }


        void InstallApkFunc(object para)
        {
            foreach (ListViewItem item in listApk.CheckedItems)
            {
                ApkInfo apkInfo = (ApkInfo)item.Tag;
                FileInfo info = new FileInfo(apkInfo.filePath);
                if (info.Exists && item.SubItems[1].Text.Equals(APK_NOT_INSTALL))
                {
                    this.Invoke(this.setApkStatus, new object[] { item, APK_INSTALLING });
                    bool bret = AdbFile.InstallApk(apkInfo, true);
                    if (bret)
                        this.Invoke(this.setApkStatus, new object[] { item, APK_INSTALLED });
                    else
                        this.Invoke(this.setApkStatus, new object[] { item, APK_INSTALL_FAILED });
                }
            }
            //ShutProgressDialog();
        }


        private delegate bool SetProgressHandler(int nValue);
        //进度条窗口
        private ProgressForm progressForm = null;
        //声明委托对象
        private SetProgressHandler setProgress = null;

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

        private void listApk_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; 
        }

        private void listApk_DragDrop(object sender, DragEventArgs e)
        {
            // Extract the data from the DataObject-Container into a string list
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            AddApk(FileList);

            
            //updateApkIconFunc(null);   
            Thread t = new Thread(new ParameterizedThreadStart(updateApkIconFunc));
            t.Start(FileList);
        }

        public void AddApkToList(string path)
        {
            AddApk(new string[] { path });
            Thread t = new Thread(new ParameterizedThreadStart(updateApkIconFunc));
            t.Start(null);
        }

        private void AppPanel_Load(object sender, EventArgs e)
        { 
            InitListView();
            textApkPath.Text = "";
            labelSize.Text = "";
            labelSystemVer.Text = "";
            labelVersion.Text = "";
            labelApkName.Text = "";
            if (this.pictureBox1.Image != null)
            {
                this.pictureBox1.Image.Dispose();
                this.pictureBox1.Image = null;
            }

            if (GlobalSys.startArg != null)
            {
                AddApk(new string[] { GlobalSys.startArg });
                Thread t = new Thread(new ParameterizedThreadStart(updateApkIconFunc));
                t.Start(null);            
            }
        }

        private void listApk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listApk.SelectedItems.Count > 0)
            {
                ApkInfo apkInfo = (ApkInfo)listApk.SelectedItems[0].Tag;
                this.textApkPath.Text = apkInfo.filePath;
                //this.pictureBox1.Image = imageList1.Images[listApk.SelectedItems[0].Text];
                if (this.pictureBox1.Image != null)
                {
                    this.pictureBox1.Image.Dispose();
                    this.pictureBox1.Image = null;
                }
                this.pictureBox1.Image = ReadApkIcon(apkInfo.filePath, apkInfo.iconPath);
                labelSystemVer.Text = apkInfo.versionDroid;
                labelVersion.Text = apkInfo.versionName;
                labelApkName.Text = apkInfo.label;

                FileInfo info = new FileInfo(this.textApkPath.Text);
                float size = 0;
                if (info.Length > 1024 * 1024)
                {
                    size = (info.Length / (1024 * 1024.0f));
                    labelSize.Text = size.ToString("#.0") + " MB";
                }
                else if (info.Length > 1024)
                {
                    size = (info.Length / (1024.0f));
                    labelSize.Text = size.ToString("#.0") + " KB";
                }
                else
                {
                    labelSize.Text = (info.Length) + " Byte";
                }
            }
            else
            {
                this.textApkPath.Text = "";
                labelSize.Text = "";
                labelSystemVer.Text = "";
                labelVersion.Text = "";
                labelApkName.Text = "";
                if (this.pictureBox1.Image != null)
                {
                    this.pictureBox1.Image.Dispose();
                    this.pictureBox1.Image = null;
                }
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listApk.Items)
                item.Checked = true;
        }

        private void 全不选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listApk.Items)
                item.Checked = false;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listApk.CheckedItems)
                item.Remove();
        }
    }
}
