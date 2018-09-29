namespace Crypt
{
    partial class NewKeyForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.privatePanel = new System.Windows.Forms.Panel();
            this.publicPanel = new System.Windows.Forms.Panel();
            this.exportPrivateButton = new System.Windows.Forms.Button();
            this.exportPublicButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.algorithmTextBox = new System.Windows.Forms.TextBox();
            this.keySizeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 244);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 12);
            label1.TabIndex = 6;
            label1.Text = "公钥：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 45);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 12);
            label2.TabIndex = 7;
            label2.Text = "私钥：";
            // 
            // privatePanel
            // 
            this.privatePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.privatePanel.Location = new System.Drawing.Point(12, 60);
            this.privatePanel.Name = "privatePanel";
            this.privatePanel.Size = new System.Drawing.Size(487, 144);
            this.privatePanel.TabIndex = 0;
            // 
            // publicPanel
            // 
            this.publicPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.publicPanel.Location = new System.Drawing.Point(12, 259);
            this.publicPanel.Name = "publicPanel";
            this.publicPanel.Size = new System.Drawing.Size(487, 120);
            this.publicPanel.TabIndex = 1;
            // 
            // exportPrivateButton
            // 
            this.exportPrivateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportPrivateButton.Location = new System.Drawing.Point(395, 210);
            this.exportPrivateButton.Name = "exportPrivateButton";
            this.exportPrivateButton.Size = new System.Drawing.Size(104, 23);
            this.exportPrivateButton.TabIndex = 2;
            this.exportPrivateButton.Text = "加密导出私钥...";
            this.exportPrivateButton.UseVisualStyleBackColor = true;
            this.exportPrivateButton.Click += new System.EventHandler(this.exportPrivateButton_Click);
            // 
            // exportPublicButton
            // 
            this.exportPublicButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportPublicButton.Location = new System.Drawing.Point(395, 385);
            this.exportPublicButton.Name = "exportPublicButton";
            this.exportPublicButton.Size = new System.Drawing.Size(104, 23);
            this.exportPublicButton.TabIndex = 3;
            this.exportPublicButton.Text = "导出公钥...";
            this.exportPublicButton.UseVisualStyleBackColor = true;
            this.exportPublicButton.Click += new System.EventHandler(this.exportPublicButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(505, 12);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(506, 42);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 17);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(41, 12);
            label3.TabIndex = 8;
            label3.Text = "算法：";
            // 
            // algorithmTextBox
            // 
            this.algorithmTextBox.Location = new System.Drawing.Point(62, 12);
            this.algorithmTextBox.Name = "algorithmTextBox";
            this.algorithmTextBox.ReadOnly = true;
            this.algorithmTextBox.Size = new System.Drawing.Size(31, 21);
            this.algorithmTextBox.TabIndex = 9;
            this.algorithmTextBox.Text = "RSA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(235, 17);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(65, 12);
            label4.TabIndex = 10;
            label4.Text = "密钥长度：";
            // 
            // keySizeTextBox
            // 
            this.keySizeTextBox.Location = new System.Drawing.Point(295, 12);
            this.keySizeTextBox.Name = "keySizeTextBox";
            this.keySizeTextBox.ReadOnly = true;
            this.keySizeTextBox.Size = new System.Drawing.Size(50, 21);
            this.keySizeTextBox.TabIndex = 11;
            this.keySizeTextBox.Text = "512";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "位";
            // 
            // NewKeyForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(592, 416);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.keySizeTextBox);
            this.Controls.Add(label4);
            this.Controls.Add(this.algorithmTextBox);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.exportPublicButton);
            this.Controls.Add(this.exportPrivateButton);
            this.Controls.Add(this.publicPanel);
            this.Controls.Add(this.privatePanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "NewKeyForm";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建非对称密钥";
            this.Load += new System.EventHandler(this.NewKeyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel privatePanel;
        private System.Windows.Forms.Panel publicPanel;
        private System.Windows.Forms.Button exportPrivateButton;
        private System.Windows.Forms.Button exportPublicButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        internal System.Windows.Forms.TextBox algorithmTextBox;
        internal System.Windows.Forms.TextBox keySizeTextBox;
        private System.Windows.Forms.Label label5;

    }
}