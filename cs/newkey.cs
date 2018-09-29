/*
Copyright (c) 2009
All rights reserved.

ժ Ҫ�� �����ɹ�Կ/˽Կ�Դ��ڴ���ʵ��

��ǰ�汾�� 1.00
�� �ߣ� wangxj
���ʱ�䣺2009��08��04��
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
    public partial class NewKeyForm : Form
    {
        internal System.ComponentModel.Design.ByteViewer privateByteViewer;
        internal System.ComponentModel.Design.ByteViewer publicByteViewer;
        internal string algName = null;
        internal byte[] key = null;

        public NewKeyForm()
        {
            InitializeComponent();

            // Initialize the ByteViewers.
            this.privateByteViewer = new System.ComponentModel.Design.ByteViewer();
            this.privateByteViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.privateByteViewer.Location = new Point(0, 0);
            this.privateByteViewer.Size = new Size(100, 100);
            this.privateByteViewer.SetBytes(new byte[] { });
            this.privatePanel.Controls.Add(privateByteViewer);

            this.publicByteViewer = new System.ComponentModel.Design.ByteViewer();
            this.publicByteViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.publicByteViewer.Location = new Point(0, 0);
            this.publicByteViewer.Size = new Size(100, 100);
            this.publicByteViewer.SetBytes(new byte[] { });
            this.publicPanel.Controls.Add(publicByteViewer);
        }

        private void NewKeyForm_Load(object sender, EventArgs e)
        {
            if (key == null)
            {
                exportPrivateButton.Enabled = false;
            }
        }

        private void exportPrivateButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "����˽Կ";
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            byte[] inputBytes = privateByteViewer.GetBytes();
            byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            using (SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create(algName))
            {
                using (Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(stream, algorithm.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    }
                }
            }
        }

        private void exportPublicButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "���湫Կ";
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }
                publicByteViewer.SaveToFile(saveFileDialog.FileName);
            }
        }
    }
}