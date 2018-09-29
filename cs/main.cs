/*
Copyright (c) 2009
All rights reserved.

摘 要： 主窗口代码实现，与CryptAPI兼容

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

[assembly: CLSCompliant(true)]
namespace Crypt
{
    public partial class MainForm : Form
    {
        private System.ComponentModel.Design.ByteViewer byteViewer;

        public MainForm()
        {
            InitializeComponent();

            // Initialize the ByteViewer.
            this.byteViewer = new System.ComponentModel.Design.ByteViewer();
            this.byteViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.byteViewer.Location = new Point(0, 0);
            this.byteViewer.Size = new Size(100, 100);
            this.byteViewer.SetBytes(new byte[] { });
            this.splitter.Panel2.Controls.Add(byteViewer);
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newPlainMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        private void openPlainMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName, Encoding.GetEncoding("GB2312"));
            }
        }

        private void savePlainMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text, Encoding.GetEncoding("GB2312"));
            }
        }

        private void newCipherMenuItem_Click(object sender, EventArgs e)
        {
            byteViewer.SetBytes(new byte[] { });
        }

        private void openCipherMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byteViewer.SetBytes(File.ReadAllBytes(openFileDialog.FileName));
            }
        }

        private void saveCipherMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }
                byteViewer.SaveToFile(saveFileDialog.FileName);
            }
        }

        private void ecryptMenuItem_Click(object sender, EventArgs e)
        {
            if (key == null)
            {
                passwordMenuItem.PerformClick();
                if (key == null)
                    return;
            }

            byte[] inputBytes = GetEncoding().GetBytes(textBox.Text);
            byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            string algName = GetSymmetricName();
            using (SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create(algName))
            {
                using (ICryptoTransform transform = algorithm.CreateEncryptor(key, iv))
                {
                    byte[] outputBytes = transform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                    byteViewer.SetBytes(outputBytes);
                }
            }
        }

        private void decryptMenuItem_Click(object sender, EventArgs e)
        {
            byte[] inputBytes = byteViewer.GetBytes();
            if (inputBytes == null || inputBytes.Length == 0)
                return;

            if (key == null)
            {
                passwordMenuItem.PerformClick();
                if (key == null)
                    return;
            }

            textBox.Clear();

            byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            string algName = GetSymmetricName();
            using (SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create(algName))
            {
                try
                {
                    using (ICryptoTransform transform = algorithm.CreateDecryptor(key, iv))
                    {
                        byte[] outputBytes = transform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                        textBox.Text = GetEncoding().GetString(outputBytes);
                    }
                }
                catch (CryptographicException exception)
                {
                    MessageBox.Show(exception.Message, "解密失败");
                }
            }
        }

        private void signMenuItem_Click(object sender, EventArgs e)
        {
            if (privateKey == null)
            {
                privateKeyMenuItem.PerformClick();
                if (privateKey == null)
                    return;
            }

            using (SignForm form = new SignForm())
            {
                form.privateKey = privateKey;
                form.algName = GetAsymmetricName();
                form.hashName = GetHashName();
                form.cipherBytes = byteViewer.GetBytes();
                if (form.cipherBytes.Length == 0)
                {
                    form.cipherRadioButton.Enabled = false;
                }
                else
                {
                    form.cipherRadioButton.Checked = true;
                }
                form.plainBytes = GetEncoding().GetBytes(textBox.Text);
                if (form.plainBytes.Length == 0)
                {
                    form.plainRadioButton.Enabled = false;
                }
                else
                {
                    form.plainRadioButton.Checked = true;
                }
                form.ShowDialog();
            }
        }

        private void verifyMenuItem_Click(object sender, EventArgs e)
        {
            if (publicKey == null)
            {
                publicKeyMenuItem.PerformClick();
                if (publicKey == null)
                    return;
            }

            using (VerifyForm form = new VerifyForm())
            {
                form.publicKey = publicKey;
                form.algName = GetAsymmetricName();
                form.hashName = GetHashName();
                form.cipherBytes = byteViewer.GetBytes();
                if (form.cipherBytes.Length == 0)
                {
                    form.cipherRadioButton.Enabled = false;
                }
                else
                {
                    form.cipherRadioButton.Checked = true;
                }
                form.plainBytes = GetEncoding().GetBytes(textBox.Text);
                if (form.plainBytes.Length == 0)
                {
                    form.plainRadioButton.Enabled = false;
                }
                else
                {
                    form.plainRadioButton.Checked = true;
                }
                form.ShowDialog();
            }
        }

        private void gb2312MenuItem_Click(object sender, EventArgs e)
        {
            gb2312MenuItem.Checked = true;
            asciiMenuItem.Checked = false;
            unicodeMenuItem.Checked = false;
            utf8MenuItem.Checked = false;
        }

        private void asciiMenuItem_Click(object sender, EventArgs e)
        {
            gb2312MenuItem.Checked = false;
            asciiMenuItem.Checked = true;
            unicodeMenuItem.Checked = false;
            utf8MenuItem.Checked = false;
        }

        private void unicodeMenuItem_Click(object sender, EventArgs e)
        {
            gb2312MenuItem.Checked = false;
            asciiMenuItem.Checked = false;
            unicodeMenuItem.Checked = true;
            utf8MenuItem.Checked = false;
        }

        private void utf8MenuItem_Click(object sender, EventArgs e)
        {
            gb2312MenuItem.Checked = false;
            asciiMenuItem.Checked = false;
            unicodeMenuItem.Checked = false;
            utf8MenuItem.Checked = true;
        }

        private void rc40MenuItem_Click(object sender, EventArgs e)
        {
            rc40MenuItem.Checked = true;
            rc128MenuItem.Checked = false;
            tripleDESMenuItem.Checked = false;
        }

        private void rc128MenuItem_Click(object sender, EventArgs e)
        {
            rc40MenuItem.Checked = false;
            rc128MenuItem.Checked = true;
            tripleDESMenuItem.Checked = false;
        }

        private void tripleDESMenuItem_Click(object sender, EventArgs e)
        {
            rc40MenuItem.Checked = false;
            rc128MenuItem.Checked = false;
            tripleDESMenuItem.Checked = true;
        }

        private void asciiPasswordMenuItem_Click(object sender, EventArgs e)
        {
            asciiPasswordMenuItem.Checked = true;
            unicodePasswordMenuItem.Checked = false;
            hexPasswordMenuItem.Checked = false;
        }

        private void unicodePasswordMenuItem_Click(object sender, EventArgs e)
        {
            asciiPasswordMenuItem.Checked = false;
            unicodeMenuItem.Checked = true;
            hexPasswordMenuItem.Checked = false;
        }

        private void hexPasswordMenuItem_Click(object sender, EventArgs e)
        {
            asciiPasswordMenuItem.Checked = false;
            unicodePasswordMenuItem.Checked = false;
            hexPasswordMenuItem.Checked = true;
        }

        private void passwordMenuItem_Click(object sender, EventArgs e)
        {
            if (asciiPasswordMenuItem.Checked)
            {
                using (PasswordForm form = new PasswordForm())
                {
                    if (password != null)
                    {
                        form.textBox.Text = Encoding.GetEncoding("GB2312").GetString(password);
                    }
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        password = Encoding.GetEncoding("GB2312").GetBytes(form.textBox.Text);
                        PasswordToKey();
                    }
                }
            }
            else if (unicodePasswordMenuItem.Checked)
            {
                using (PasswordForm form = new PasswordForm())
                {
                    if (password != null)
                    {
                        form.textBox.Text = Encoding.Unicode.GetString(password);
                    }
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        password = Encoding.Unicode.GetBytes(form.textBox.Text);
                        PasswordToKey();
                    }
                }
            }
            else
            {
                using (HexForm form = new HexForm())
                {
                    form.Text = "密码";
                    if ("RSA" == GetAsymmetricName())
                    {
                        form.publicKey = publicKey;
                        form.privateKey = privateKey;
                    }
                    if (password != null)
                    {
                        form.byteViewer.SetBytes(password);
                    }
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        password = form.byteViewer.GetBytes();
                        PasswordToKey();
                    }
                }
            }
        }

        private void keyMenuItem_Click(object sender, EventArgs e)
        {
            using (HexForm form = new HexForm())
            {
                form.Text = "密钥";
                if ("RSA" == GetAsymmetricName())
                {
                    form.publicKey = publicKey;
                    form.privateKey = privateKey;
                }
                if (key != null)
                {
                    form.byteViewer.SetBytes(key);
                }
                if (form.ShowDialog() == DialogResult.OK)
                {
                    key = form.byteViewer.GetBytes();
                }
            }
        }

        private void rsaMenuItem_Click(object sender, EventArgs e)
        {
            rsaMenuItem.Checked = true;
            dsaMenuItem.Checked = false;
        }

        private void dsaMenuItem_Click(object sender, EventArgs e)
        {
            dsaMenuItem.Checked = true;
            rsaMenuItem.Checked = false;
        }

        private void keySize384MenuItem_Click(object sender, EventArgs e)
        {
            keySize384MenuItem.Checked = true;
            keySize512MenuItem.Checked = false;
            keySize1024MenuItem.Checked = false;
            keySize2048MenuItem.Checked = false;
            keySize4096MenuItem.Checked = false;
        }

        private void keySize512MenuItem_Click(object sender, EventArgs e)
        {
            keySize384MenuItem.Checked = false;
            keySize512MenuItem.Checked = true;
            keySize1024MenuItem.Checked = false;
            keySize2048MenuItem.Checked = false;
            keySize4096MenuItem.Checked = false;
        }

        private void keySize1024MenuItem_Click(object sender, EventArgs e)
        {
            keySize384MenuItem.Checked = false;
            keySize512MenuItem.Checked = false;
            keySize1024MenuItem.Checked = true;
            keySize2048MenuItem.Checked = false;
            keySize4096MenuItem.Checked = false;
        }

        private void keySize2048MenuItem_Click(object sender, EventArgs e)
        {
            keySize384MenuItem.Checked = false;
            keySize512MenuItem.Checked = false;
            keySize1024MenuItem.Checked = false;
            keySize2048MenuItem.Checked = true;
            keySize4096MenuItem.Checked = false;
        }

        private void keySize4096MenuItem_Click(object sender, EventArgs e)
        {
            keySize384MenuItem.Checked = false;
            keySize512MenuItem.Checked = false;
            keySize1024MenuItem.Checked = false;
            keySize2048MenuItem.Checked = false;
            keySize4096MenuItem.Checked = true;
        }

        private void newKeyMenuItem_Click(object sender, EventArgs e)
        {
            byte[] privateBlob, publicBlob;
            if (rsaMenuItem.Checked)
            {
                using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider(GetAsymmetricKeySize()))
                {
                    privateBlob = algorithm.ExportCspBlob(true);
                    publicBlob = algorithm.ExportCspBlob(false);
                }
            }
            else
            {
                using (DSACryptoServiceProvider algorithm = new DSACryptoServiceProvider(GetAsymmetricKeySize()))
                {
                    privateBlob = algorithm.ExportCspBlob(true);
                    publicBlob = algorithm.ExportCspBlob(false);
                }
            }
            using (NewKeyForm form = new NewKeyForm())
            {
                form.algorithmTextBox.Text = GetAsymmetricName();
                form.keySizeTextBox.Text = GetAsymmetricKeySize().ToString();
                form.privateByteViewer.SetBytes(privateBlob);
                form.publicByteViewer.SetBytes(publicBlob);
                form.algName = GetSymmetricName();
                form.key = key;
                if (DialogResult.OK == form.ShowDialog())
                {
                    privateKey = privateBlob;
                    publicKey = publicBlob;
                }
            }
        }

        private void publicKeyMenuItem_Click(object sender, EventArgs e)
        {
            using (PublicKeyForm form = new PublicKeyForm())
            {
                if (publicKey != null)
                {
                    form.byteViewer.SetBytes(publicKey);
                }
                if (form.ShowDialog() == DialogResult.OK)
                {
                    publicKey = form.byteViewer.GetBytes();
                    if (publicKey.Length == 0)
                    {
                        publicKey = null;
                    }
                }
            }
        }

        private void privateKeyMenuItem_Click(object sender, EventArgs e)
        {
            using (PrivateKeyForm form = new PrivateKeyForm())
            {
                form.algName = GetSymmetricName();
                form.key = key;
                if (privateKey != null)
                {
                    form.byteViewer.SetBytes(privateKey);
                }
                if (form.ShowDialog() == DialogResult.OK)
                {
                    privateKey = form.byteViewer.GetBytes();
                    if (privateKey.Length == 0)
                    {
                        privateKey = null;
                    }
                }
            }
        }

        private void md5MenuItem_Click(object sender, EventArgs e)
        {
            md5MenuItem.Checked = true;
            sha1MenuItem.Checked = false;
        }

        private void sha1MenuItem_Click(object sender, EventArgs e)
        {
            sha1MenuItem.Checked = true;
            md5MenuItem.Checked = false;
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            using (Form form = new AboutBox())
            {
                form.ShowDialog();
            }
        }

        private byte[] password = null;     // 用于生成对称密钥的密码
        private byte[] key = null;          // 对称密钥
        private byte[] publicKey = null;    // 公钥
        private byte[] privateKey = null;   // 私钥

        /// <summary>
        /// .根据密码生成对称密钥
        /// </summary>
        void PasswordToKey()
        {
            byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(password, null);
            key = bytes.CryptDeriveKey(GetSymmetricName(), GetHashName(), GetSymmetricKeySize(), iv);
        }

        /// <summary>
        /// 获取明文编码方式
        /// </summary>
        /// <returns></returns>
        Encoding GetEncoding()
        {
            if (gb2312MenuItem.Checked)
                return Encoding.GetEncoding("GB2312");
            if (asciiMenuItem.Checked)
                return Encoding.ASCII;
            if (unicodeMenuItem.Checked)
                return Encoding.Unicode;
            return Encoding.UTF8;
        }

        /// <summary>
        /// 获取对称加密算法
        /// </summary>
        /// <returns></returns>
        string GetSymmetricName()
        {
            if(tripleDESMenuItem.Checked)
                return "TripleDES";
            return "RC2";
        }

        /// <summary>
        /// 获取非对称加密算法
        /// </summary>
        /// <returns></returns>
        string GetAsymmetricName()
        {
            if (rsaMenuItem.Checked)
                return "RSA";
            return "DSA";
        }

        /// <summary>
        /// 获取散列算法
        /// </summary>
        /// <returns></returns>
        string GetHashName()
        {
            if (md5MenuItem.Checked)
                return "MD5";
            return "SHA1";
        }

        /// <summary>
        /// 获取对称密钥长度
        /// </summary>
        /// <returns></returns>
        int GetSymmetricKeySize()
        {
            if (rc40MenuItem.Checked)
                return 40;
            if (rc128MenuItem.Checked)
                return 128;
            return 168;
        }

        /// <summary>
        /// 获取非对称密钥长度，仅用在新产生密钥对时
        /// </summary>
        /// <returns></returns>
        int GetAsymmetricKeySize()
        {
            if (keySize384MenuItem.Checked)
                return 384;
            if (keySize512MenuItem.Checked)
                return 512;
            if (keySize1024MenuItem.Checked)
                return 1024;
            if (keySize2048MenuItem.Checked)
                return 2048;
            return 4096;
        }

        //private static string BinToHex(byte[] bytes)
        //{
        //    if (bytes == null)
        //        return null;
        //    if (bytes.Length == 0)
        //        return "";
        //    StringBuilder strings = new StringBuilder(8192);
        //    strings.Append(bytes[0].ToString("X2"));
        //    for (int i = 1; i < bytes.Length; i++)
        //    {
        //        strings.Append(" " + bytes[i].ToString("X2"));
        //    }
        //    return strings.ToString();
        //    return BitConverter.ToString(bytes).Replace('-', ' ');
        //}
    }
}