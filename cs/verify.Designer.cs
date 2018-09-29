namespace Crypt
{
    partial class VerifyForm
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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.importButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.openButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.customRadioButton = new System.Windows.Forms.RadioButton();
            this.cipherRadioButton = new System.Windows.Forms.RadioButton();
            this.plainRadioButton = new System.Windows.Forms.RadioButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.frameworkRadioButton = new System.Windows.Forms.RadioButton();
            this.cryptoapiRadioButton = new System.Windows.Forms.RadioButton();
            this.panel = new System.Windows.Forms.Panel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(374, 56);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(94, 23);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "导入签名...";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(505, 19);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "验证";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(506, 49);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.openButton);
            this.groupBox.Controls.Add(this.textBox);
            this.groupBox.Controls.Add(this.customRadioButton);
            this.groupBox.Controls.Add(this.cipherRadioButton);
            this.groupBox.Controls.Add(this.plainRadioButton);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(487, 153);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "数据";
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.Location = new System.Drawing.Point(393, 121);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 4;
            this.openButton.Text = "浏览...";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(34, 94);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(434, 21);
            this.textBox.TabIndex = 3;
            // 
            // customRadioButton
            // 
            this.customRadioButton.AutoSize = true;
            this.customRadioButton.Checked = true;
            this.customRadioButton.Location = new System.Drawing.Point(16, 71);
            this.customRadioButton.Name = "customRadioButton";
            this.customRadioButton.Size = new System.Drawing.Size(107, 16);
            this.customRadioButton.TabIndex = 2;
            this.customRadioButton.TabStop = true;
            this.customRadioButton.Text = "下面指定的文件";
            this.customRadioButton.UseVisualStyleBackColor = true;
            // 
            // cipherRadioButton
            // 
            this.cipherRadioButton.AutoSize = true;
            this.cipherRadioButton.Location = new System.Drawing.Point(16, 48);
            this.cipherRadioButton.Name = "cipherRadioButton";
            this.cipherRadioButton.Size = new System.Drawing.Size(47, 16);
            this.cipherRadioButton.TabIndex = 1;
            this.cipherRadioButton.TabStop = true;
            this.cipherRadioButton.Text = "密文";
            this.cipherRadioButton.UseVisualStyleBackColor = true;
            // 
            // plainRadioButton
            // 
            this.plainRadioButton.AutoSize = true;
            this.plainRadioButton.Location = new System.Drawing.Point(16, 25);
            this.plainRadioButton.Name = "plainRadioButton";
            this.plainRadioButton.Size = new System.Drawing.Size(47, 16);
            this.plainRadioButton.TabIndex = 0;
            this.plainRadioButton.TabStop = true;
            this.plainRadioButton.Text = "明文";
            this.plainRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.Controls.Add(this.importButton);
            groupBox1.Controls.Add(this.panel);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(this.cryptoapiRadioButton);
            groupBox1.Controls.Add(this.frameworkRadioButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(12, 172);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(487, 182);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "签名";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 12);
            label1.TabIndex = 0;
            label1.Text = "来源：";
            // 
            // frameworkRadioButton
            // 
            this.frameworkRadioButton.AutoSize = true;
            this.frameworkRadioButton.Checked = true;
            this.frameworkRadioButton.Location = new System.Drawing.Point(61, 21);
            this.frameworkRadioButton.Name = "frameworkRadioButton";
            this.frameworkRadioButton.Size = new System.Drawing.Size(215, 16);
            this.frameworkRadioButton.TabIndex = 1;
            this.frameworkRadioButton.TabStop = true;
            this.frameworkRadioButton.Text = "签名由.NET Framework加密类库生成";
            this.frameworkRadioButton.UseVisualStyleBackColor = true;
            // 
            // cryptoapiRadioButton
            // 
            this.cryptoapiRadioButton.AutoSize = true;
            this.cryptoapiRadioButton.Location = new System.Drawing.Point(61, 43);
            this.cryptoapiRadioButton.Name = "cryptoapiRadioButton";
            this.cryptoapiRadioButton.Size = new System.Drawing.Size(173, 16);
            this.cryptoapiRadioButton.TabIndex = 2;
            this.cryptoapiRadioButton.Text = "签名由Win32 CryptoAPI生成";
            this.cryptoapiRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(14, 70);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 12);
            label2.TabIndex = 3;
            label2.Text = "内容：";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Location = new System.Drawing.Point(16, 85);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(452, 91);
            this.panel.TabIndex = 4;
            // 
            // VerifyForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(592, 366);
            this.Controls.Add(groupBox1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "VerifyForm";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "验证签名";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        internal System.Windows.Forms.RadioButton cipherRadioButton;
        internal System.Windows.Forms.RadioButton plainRadioButton;
        internal System.Windows.Forms.RadioButton customRadioButton;
        private System.Windows.Forms.RadioButton cryptoapiRadioButton;
        private System.Windows.Forms.RadioButton frameworkRadioButton;
        private System.Windows.Forms.Panel panel;

    }
}