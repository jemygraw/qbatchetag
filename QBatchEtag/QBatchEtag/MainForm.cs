using QBatchEtag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QBatchEtag
{
    public partial class MainForm : Form
    {
        private string LocalDir;
        private int totalDone;
        private bool cancel;
        private string jobPath;
        public MainForm()
        {
            InitializeComponent();
        }

        private void BrowseFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.LocalFolderBrowseDialog.ShowDialog(this);
            if (dr.Equals(DialogResult.OK))
            {
                this.LocalDirTextBox.Text = this.LocalFolderBrowseDialog.SelectedPath;
                this.LocalDir = this.LocalFolderBrowseDialog.SelectedPath;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.StopButton.Enabled = false;
            this.ExportResultButton.Enabled = false;
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.LocalDir))
            {
                MessageBox.Show(this, "选择的本地目录不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.totalDone = 0;
            this.cancel = false;
            this.CalcProgressLabel.Text = "已完成文件数量: 0";
            this.CalcButton.Enabled = false;
            this.ExportResultButton.Enabled = false;
            this.StopButton.Enabled = true;
            Thread t=new Thread(new ParameterizedThreadStart(this.calcDirETag));
            t.Start(this.LocalDir);
        }


        private void calcDirETag(object rootDirObject)
        {
            string rootDir = rootDirObject.ToString();
            string myDocPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appPath = Path.Combine(myDocPath, "qbatchetag");
            if (!Directory.Exists(appPath))
            {
                try
                {
                    Directory.CreateDirectory(appPath);
                }
                catch (Exception ex) {
                    this.showErrorDialog(string.Format("创建应用目录失败，{0}",ex.Message));
                    return;
                }
            }
            string calcJobId = StringUtils.md5Hash(string.Format("{0}:{1}",this.LocalDir,DateTime.Now.ToFileTime()));
            this.jobPath = Path.Combine(appPath, calcJobId);
            try
            {
                using (StreamWriter sw = new StreamWriter(jobPath, false, Encoding.UTF8))
                {
                    this.processDir(this.LocalDir, this.LocalDir, sw);
                }
            }
            catch (Exception ex)
            {

            }
            this.showResult();
        }

        private delegate void UpdateLabelCallback(string text);
        
         private void updateLabel(string text){
             if (this.InvokeRequired)
             {
                 UpdateLabelCallback callback = new UpdateLabelCallback(updateLabel);
                 this.Invoke(callback, text);
             }
             else
             {
                 this.CalcProgressLabel.Text = text;
             }
        }

         private delegate void ShowErrorDialogCallback(string message);
         private void showErrorDialog(string message)
         {
             if (this.InvokeRequired)
             {
                 ShowErrorDialogCallback callback = new ShowErrorDialogCallback(showErrorDialog);
                 this.Invoke(callback, message);
             }
             else
             {
                 try
                 {
                     MessageBox.Show(this, message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 catch (Exception) { }
             }
         }


         private delegate void ShowResultCallback();
         private void showResult()
         {
             if (this.InvokeRequired)
             {
                 ShowResultCallback callback = new ShowResultCallback(showResult);
                 this.Invoke(callback);
             }
             else
             {
                 try
                 {
                     this.StopButton.Enabled = false;
                     this.CalcButton.Enabled = true;
                     this.ExportResultButton.Enabled = true;
                     MessageBox.Show(this, string.Format("计算完成，共{0}个文件", this.totalDone),
                         "结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 catch (Exception) { }
             }
         }

        private void processDir(string rootDir,string targetDir,StreamWriter sw)
        {
            if (this.cancel)
            {
                return;
            }
            try
            {
                string[] fileEntries = Directory.GetFiles(targetDir);
                foreach (string filePath in fileEntries)
                {
                    if(this.cancel)
                    {
                        return;
                    }
                    try
                    {
                        string etag = QETag.hash(filePath);
                        if (!string.IsNullOrEmpty(etag))
                        {
                            sw.WriteLine(etag);
                            this.totalDone += 1;
                            this.updateLabel(string.Format("已完成文件数量: {0}", this.totalDone));
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                string[] subDirs = Directory.GetDirectories(targetDir);
                foreach (string subDir in subDirs)
                {
                    if (this.cancel)
                    {
                        return;
                    }
                    processDir(rootDir, subDir, sw);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ExportResultButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.ExportFileDialog.ShowDialog(this);
            if (dr.Equals(DialogResult.OK))
            {
                string filePath = this.ExportFileDialog.FileName;
                if (filePath.Equals(this.jobPath))
                {
                    showErrorDialog("导出文件不能和任务临时文件同名!");
                    return;
                }

                if (!File.Exists(filePath))
                {
                    try
                    {
                        File.Delete(filePath);
                        File.Copy(this.jobPath, filePath);
                    }
                    catch (Exception ex) {
                        showErrorDialog(string.Format("导出的目标文件已存在且无法被覆盖: {0}",ex.Message));
                        return;
                    }
                }

                MessageBox.Show(this, "导出成功！", "结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            DialogResult dr = MessageBox.Show(this, "确定要退出么？", "确定", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr.Equals(DialogResult.Yes))
            {
                this.cancel = true;
                Application.ExitThread();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            this.cancel = true;
        }
    }
}
