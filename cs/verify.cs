/*
Copyright (c) 2009
All rights reserved.

摘 要： 验证签名窗口代码实现

当前版本： 1.00
作 者： wangxj
完成时间：2009年08月04日
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Crypt
{
    public partial class VerifyForm : Form
    {
        internal System.ComponentModel.Design.ByteViewer byteViewer;
        internal byte[] plainBytes = null;
        internal byte[] cipherBytes = null;
        internal byte[] publicKey = null;
        internal string algName = null;
        internal string hashName = null;

        public VerifyForm()
        {
            InitializeComponent();

            // Initialize the ByteViewers.

            this.byteViewer = new System.ComponentModel.Design.ByteViewer();
            this.byteViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.byteViewer.Location = new Point(0, 0);
            this.byteViewer.Size = new Size(100, 100);
            this.byteViewer.SetBytes(new byte[] { });
            this.panel.Controls.Add(byteViewer);
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byteViewer.SetBytes(File.ReadAllBytes(openFileDialog.FileName));
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = openFileDialog.FileName;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            byte[] signature=byteViewer.GetBytes();
            if(signature.Length==0)
                return;

            if (cryptoapiRadioButton.Checked)
            {
                Array.Reverse(signature);
            }

            byte[] buffer;
            if (plainRadioButton.Checked)
            {
                buffer = plainBytes;
            }
            else if (cipherRadioButton.Checked)
            {
                buffer = cipherBytes;
            }
            else
            {
                if (!File.Exists(textBox.Text))
                    return;
                buffer = File.ReadAllBytes(textBox.Text);
            }

            if (algName == "RSA")
            {
                using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
                {
                    algorithm.ImportCspBlob(publicKey);
                    if (!algorithm.VerifyData(buffer, HashAlgorithm.Create(hashName), signature))
                    {
                        MessageBox.Show("签名不一致");
                        return;
                    }
                }
            }
            else
            {
                using (DSACryptoServiceProvider algorithm = new DSACryptoServiceProvider())
                {
                    algorithm.ImportCspBlob(publicKey);
                    if (!algorithm.VerifyData(buffer, signature))
                    {
                        MessageBox.Show("签名不一致");
                        return;
                    }
                }
            }
            Close();
            MessageBox.Show("签名一致");
        }
    }
}