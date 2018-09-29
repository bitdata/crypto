/*
Copyright (c) 2009
All rights reserved.

摘 要： 密码导入界面代码实现

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
using System.IO;
using System.Security.Cryptography;

namespace Crypt
{
    public partial class HexForm : Form
    {
        internal System.ComponentModel.Design.ByteViewer byteViewer;
        internal byte[] publicKey = null;
        internal byte[] privateKey = null;

        public HexForm()
        {
            InitializeComponent();

            // Initialize the ByteViewer.
            this.byteViewer = new System.ComponentModel.Design.ByteViewer();
            this.byteViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.byteViewer.Location = new Point(0, 0);
            this.byteViewer.Size = new Size(100, 100);
            this.byteViewer.SetBytes(new byte[] { });
            this.panel.Controls.Add(byteViewer);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (publicKey != null)
            {
                saveButton.Visible = true;
            }
            if (privateKey != null)
            {
                loadButton.Visible = true;
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] bytes = File.ReadAllBytes(openFileDialog.FileName);
                if (plainRadioButton.Checked)
                {
                    byteViewer.SetBytes(bytes);
                }
                else
                {
                    using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
                    {
                        try
                        {
                            algorithm.ImportCspBlob(privateKey);
                            if (cryptoapiRadioButton.Checked)
                            {
                                Array.Reverse(bytes);
                            }
                            byteViewer.SetBytes(algorithm.Decrypt(bytes, false));
                        }
                        catch (CryptographicException exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }
                byte[] bytes = byteViewer.GetBytes();
                if (!plainRadioButton.Checked)
                {
                    using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
                    {
                        algorithm.ImportCspBlob(publicKey);
                        bytes = algorithm.Encrypt(bytes, false);
                        if (cryptoapiRadioButton.Checked)
                        {
                            Array.Reverse(bytes);
                        }
                    }
                    File.WriteAllBytes(saveFileDialog.FileName, bytes);
                }
            }
        }
    }
}