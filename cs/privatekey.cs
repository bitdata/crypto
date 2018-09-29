/*
Copyright (c) 2009
All rights reserved.

摘 要： 私钥属性页代码实现

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
    public partial class PrivateKeyForm : Form
    {
        internal System.ComponentModel.Design.ByteViewer byteViewer;
        internal string algName = null;
        internal byte[] key = null;

        public PrivateKeyForm()
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

        private void PrivateKeyForm_Load(object sender, EventArgs e)
        {
            if (key == null)
            {
                importButton.Enabled = false;
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            using (SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create(algName))
            {
                try
                {
                    using (Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(stream, algorithm.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                        {
                            byte[] outputBytes = new byte[stream.Length];
                            int size =cryptoStream.Read(outputBytes, 0, outputBytes.Length);
                            if (size < outputBytes.Length)
                            {
                                Array.Resize(ref outputBytes, size);
                            }
                            byteViewer.SetBytes(outputBytes);
                        }
                    }
                }
                catch (CryptographicException exception)
                {
                    MessageBox.Show(exception.Message, "解密失败");
                }
            }
        }
    }
}