/*
Copyright (c) 2009
All rights reserved.

摘 要： 公钥属性页代码实现

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
    public partial class PublicKeyForm : Form
    {
        internal System.ComponentModel.Design.ByteViewer byteViewer;

        public PublicKeyForm()
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

        private void importButton_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byteViewer.SetBytes(File.ReadAllBytes(openFileDialog.FileName));
            }
        }
    }
}