namespace Crypt
{
    partial class HexForm
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
            System.Windows.Forms.GroupBox groupBox2;
            this.cryptoapiRadioButton = new System.Windows.Forms.RadioButton();
            this.cryptRadioButton = new System.Windows.Forms.RadioButton();
            this.plainRadioButton = new System.Windows.Forms.RadioButton();
            this.panel = new System.Windows.Forms.Panel();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.Controls.Add(this.cryptoapiRadioButton);
            groupBox1.Controls.Add(this.cryptRadioButton);
            groupBox1.Controls.Add(this.plainRadioButton);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(378, 94);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "存储选项";
            // 
            // cryptoapiRadioButton
            // 
            this.cryptoapiRadioButton.AutoSize = true;
            this.cryptoapiRadioButton.Location = new System.Drawing.Point(20, 67);
            this.cryptoapiRadioButton.Name = "cryptoapiRadioButton";
            this.cryptoapiRadioButton.Size = new System.Drawing.Size(269, 16);
            this.cryptoapiRadioButton.TabIndex = 2;
            this.cryptoapiRadioButton.Text = "用与Win32 CryptoAPI兼容的公钥加密方式存储";
            this.cryptoapiRadioButton.UseVisualStyleBackColor = true;
            // 
            // cryptRadioButton
            // 
            this.cryptRadioButton.AutoSize = true;
            this.cryptRadioButton.Checked = true;
            this.cryptRadioButton.Location = new System.Drawing.Point(20, 44);
            this.cryptRadioButton.Name = "cryptRadioButton";
            this.cryptRadioButton.Size = new System.Drawing.Size(107, 16);
            this.cryptRadioButton.TabIndex = 1;
            this.cryptRadioButton.TabStop = true;
            this.cryptRadioButton.Text = "用公钥加密存储";
            this.cryptRadioButton.UseVisualStyleBackColor = true;
            // 
            // plainRadioButton
            // 
            this.plainRadioButton.AutoSize = true;
            this.plainRadioButton.Location = new System.Drawing.Point(20, 21);
            this.plainRadioButton.Name = "plainRadioButton";
            this.plainRadioButton.Size = new System.Drawing.Size(71, 16);
            this.plainRadioButton.TabIndex = 0;
            this.plainRadioButton.Text = "明文存储";
            this.plainRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            groupBox2.Controls.Add(this.panel);
            groupBox2.Controls.Add(this.loadButton);
            groupBox2.Controls.Add(this.saveButton);
            groupBox2.Location = new System.Drawing.Point(13, 112);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(377, 142);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "内容";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Location = new System.Drawing.Point(19, 21);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(340, 77);
            this.panel.TabIndex = 0;
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Location = new System.Drawing.Point(203, 104);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "加载...";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Visible = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(284, 104);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "保存…";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(405, 12);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(405, 42);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // HexForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(492, 266);
            this.Controls.Add(groupBox2);
            this.Controls.Add(groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "HexForm";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Form_Load);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.RadioButton cryptoapiRadioButton;
        private System.Windows.Forms.RadioButton cryptRadioButton;
        private System.Windows.Forms.RadioButton plainRadioButton;
    }
}