namespace QBatchEtag
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.CalcProgressLabel = new System.Windows.Forms.Label();
            this.ExportResultButton = new System.Windows.Forms.Button();
            this.CalcButton = new System.Windows.Forms.Button();
            this.BrowseFolderButton = new System.Windows.Forms.Button();
            this.LocalDirTextBox = new System.Windows.Forms.TextBox();
            this.LocalDirLabel = new System.Windows.Forms.Label();
            this.LocalFolderBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ExportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MainGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainGroupBox.Controls.Add(this.StopButton);
            this.MainGroupBox.Controls.Add(this.CalcProgressLabel);
            this.MainGroupBox.Controls.Add(this.ExportResultButton);
            this.MainGroupBox.Controls.Add(this.CalcButton);
            this.MainGroupBox.Controls.Add(this.BrowseFolderButton);
            this.MainGroupBox.Controls.Add(this.LocalDirTextBox);
            this.MainGroupBox.Controls.Add(this.LocalDirLabel);
            this.MainGroupBox.Location = new System.Drawing.Point(12, 12);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(444, 174);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "计算&&导出";
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(241, 130);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(92, 25);
            this.StopButton.TabIndex = 7;
            this.StopButton.Text = "停止计算";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // CalcProgressLabel
            // 
            this.CalcProgressLabel.AutoSize = true;
            this.CalcProgressLabel.Location = new System.Drawing.Point(15, 96);
            this.CalcProgressLabel.Name = "CalcProgressLabel";
            this.CalcProgressLabel.Size = new System.Drawing.Size(107, 12);
            this.CalcProgressLabel.TabIndex = 6;
            this.CalcProgressLabel.Text = "已完成文件数量: 0";
            // 
            // ExportResultButton
            // 
            this.ExportResultButton.Location = new System.Drawing.Point(339, 130);
            this.ExportResultButton.Name = "ExportResultButton";
            this.ExportResultButton.Size = new System.Drawing.Size(92, 25);
            this.ExportResultButton.TabIndex = 5;
            this.ExportResultButton.Text = "导出结果";
            this.ExportResultButton.UseVisualStyleBackColor = true;
            this.ExportResultButton.Click += new System.EventHandler(this.ExportResultButton_Click);
            // 
            // CalcButton
            // 
            this.CalcButton.Location = new System.Drawing.Point(17, 130);
            this.CalcButton.Name = "CalcButton";
            this.CalcButton.Size = new System.Drawing.Size(92, 25);
            this.CalcButton.TabIndex = 4;
            this.CalcButton.Text = "开始计算";
            this.CalcButton.UseVisualStyleBackColor = true;
            this.CalcButton.Click += new System.EventHandler(this.CalcButton_Click);
            // 
            // BrowseFolderButton
            // 
            this.BrowseFolderButton.Location = new System.Drawing.Point(356, 55);
            this.BrowseFolderButton.Name = "BrowseFolderButton";
            this.BrowseFolderButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseFolderButton.TabIndex = 2;
            this.BrowseFolderButton.Text = "浏览 ...";
            this.BrowseFolderButton.UseVisualStyleBackColor = true;
            this.BrowseFolderButton.Click += new System.EventHandler(this.BrowseFolderButton_Click);
            // 
            // LocalDirTextBox
            // 
            this.LocalDirTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.LocalDirTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LocalDirTextBox.Location = new System.Drawing.Point(17, 56);
            this.LocalDirTextBox.Name = "LocalDirTextBox";
            this.LocalDirTextBox.ReadOnly = true;
            this.LocalDirTextBox.Size = new System.Drawing.Size(333, 21);
            this.LocalDirTextBox.TabIndex = 1;
            // 
            // LocalDirLabel
            // 
            this.LocalDirLabel.AutoSize = true;
            this.LocalDirLabel.Location = new System.Drawing.Point(14, 29);
            this.LocalDirLabel.Name = "LocalDirLabel";
            this.LocalDirLabel.Size = new System.Drawing.Size(53, 12);
            this.LocalDirLabel.TabIndex = 0;
            this.LocalDirLabel.Text = "本地目录";
            // 
            // LocalFolderBrowseDialog
            // 
            this.LocalFolderBrowseDialog.ShowNewFolderButton = false;
            // 
            // ExportFileDialog
            // 
            this.ExportFileDialog.DefaultExt = "txt";
            this.ExportFileDialog.Filter = "TXT (*.txt)|*.txt";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 198);
            this.Controls.Add(this.MainGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QETag批量计算工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainGroupBox.ResumeLayout(false);
            this.MainGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.Label LocalDirLabel;
        private System.Windows.Forms.Button BrowseFolderButton;
        private System.Windows.Forms.TextBox LocalDirTextBox;
        private System.Windows.Forms.Button ExportResultButton;
        private System.Windows.Forms.Button CalcButton;
        private System.Windows.Forms.Label CalcProgressLabel;
        private System.Windows.Forms.FolderBrowserDialog LocalFolderBrowseDialog;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.SaveFileDialog ExportFileDialog;
    }
}

