namespace ADBexplorer
{
    partial class ProgressForm
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.labelContent = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labelTitle = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.loadingProgress1 = new CSharpWin.LoadingProgress();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.labelContent);
            this.kryptonPanel1.Controls.Add(this.labelTitle);
            this.kryptonPanel1.Controls.Add(this.loadingProgress1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(364, 90);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // labelContent
            // 
            this.labelContent.Location = new System.Drawing.Point(106, 21);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(88, 20);
            this.labelContent.TabIndex = 2;
            this.labelContent.Text = "kryptonLabel1";
            this.labelContent.Values.ExtraText = "";
            this.labelContent.Values.Image = null;
            this.labelContent.Values.Text = "kryptonLabel1";
            // 
            // labelTitle
            // 
            this.labelTitle.Location = new System.Drawing.Point(106, 47);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(88, 20);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "kryptonLabel1";
            this.labelTitle.Values.ExtraText = "";
            this.labelTitle.Values.Image = null;
            this.labelTitle.Values.Text = "kryptonLabel1";
            // 
            // loadingProgress1
            // 
            this.loadingProgress1.BackColor = System.Drawing.Color.Transparent;
            this.loadingProgress1.Location = new System.Drawing.Point(12, 12);
            this.loadingProgress1.Name = "loadingProgress1";
            this.loadingProgress1.Size = new System.Drawing.Size(70, 64);
            this.loadingProgress1.TabIndex = 0;
            this.loadingProgress1.Text = "loadingProgress1";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 90);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请稍候";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private CSharpWin.LoadingProgress loadingProgress1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelTitle;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelContent;
    }
}