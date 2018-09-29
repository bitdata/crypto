/*
Copyright (c) 2009
All rights reserved.

摘 要： 签名窗口代码实现

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
    public partial class SignForm : Form
    {
        internal System.ComponentModel.Design.ByteViewer byteViewer;
        internal byte[] plainBytes = null;
        internal byte[] cipherBytes = null;
        internal byte[] privateKey = null;
        internal string algName = null;
        internal string hashName = null;

        public SignForm()
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

        private void exportButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }
                byte[] bytes = byteViewer.GetBytes();
                if (cryptoapiRadioButton.Checked)
                {
                    Array.Reverse(bytes);
                }
                File.WriteAllBytes(saveFileDialog.FileName, bytes);
            }
        }

        private void plainRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            byteViewer.SetBytes(SignData(plainBytes));
        }

        private void cipherRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            byteViewer.SetBytes(SignData(cipherBytes));
        }

        private void customRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists(textBox.Text))
            {
                byteViewer.SetBytes(SignData(File.ReadAllBytes(textBox.Text)));
            }
            else
            {
                byteViewer.SetBytes(new byte[]{});
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (customRadioButton.Checked)
            {
                customRadioButton_CheckedChanged(sender, e);
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

        private byte[] SignData(byte[] buffer)
        {
            if (algName == "RSA")
            {
                using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
                {
                    algorithm.ImportCspBlob(privateKey);
                    return algorithm.SignData(buffer, HashAlgorithm.Create(hashName));
                }
            }
            if (algName == "DSA")
            {
                using (DSACryptoServiceProvider algorithm = new DSACryptoServiceProvider())
                {
                    algorithm.ImportCspBlob(privateKey);
                    return algorithm.SignData(buffer);
                }
            }
            return null;
        }
    }
}