namespace Crypt
{
    partial class MainForm
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
            System.Windows.Forms.MenuStrip mainMenu;
            System.Windows.Forms.ToolStripMenuItem fileMenu;
            System.Windows.Forms.ToolStripMenuItem plainMenu;
            System.Windows.Forms.ToolStripMenuItem newPlainMenuItem;
            System.Windows.Forms.ToolStripMenuItem openPlainMenuItem;
            System.Windows.Forms.ToolStripMenuItem cipherMenu;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripMenuItem operationMenu;
            System.Windows.Forms.ToolStripMenuItem encodingMenu;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
            System.Windows.Forms.ToolStripMenuItem symmetricMenu;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.Windows.Forms.ToolStripMenuItem passwordMenu;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
            System.Windows.Forms.ToolStripMenuItem asymmetricMenu;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
            System.Windows.Forms.ToolStripMenuItem newKeyMenuItem;
            System.Windows.Forms.ToolStripMenuItem hashMenu;
            System.Windows.Forms.ToolStripMenuItem helpMenu;
            System.Windows.Forms.ToolStripMenuItem keyMenuItem;
            this.savePlainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCipherMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCipherMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCipherMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ecryptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.gb2312MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asciiMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unicodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utf8MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rc40MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rc128MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tripleDESMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asciiPasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unicodePasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexPasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rsaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keySize384MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keySize512MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keySize1024MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keySize2048MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keySize4096MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicKeyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.privateKeyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.md5MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sha1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.textBox = new System.Windows.Forms.TextBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            mainMenu = new System.Windows.Forms.MenuStrip();
            fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            plainMenu = new System.Windows.Forms.ToolStripMenuItem();
            newPlainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openPlainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            cipherMenu = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            operationMenu = new System.Windows.Forms.ToolStripMenuItem();
            encodingMenu = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            symmetricMenu = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            passwordMenu = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            asymmetricMenu = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            newKeyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            hashMenu = new System.Windows.Forms.ToolStripMenuItem();
            helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            keyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mainMenu.SuspendLayout();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileMenu,
            operationMenu,
            this.settingMenu,
            helpMenu});
            mainMenu.Location = new System.Drawing.Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new System.Drawing.Size(592, 24);
            mainMenu.TabIndex = 0;
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            plainMenu,
            cipherMenu,
            toolStripSeparator1,
            this.exitMenuItem});
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new System.Drawing.Size(59, 20);
            fileMenu.Text = "文件(&F)";
            // 
            // plainMenu
            // 
            plainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newPlainMenuItem,
            openPlainMenuItem,
            this.savePlainMenuItem});
            plainMenu.Name = "plainMenu";
            plainMenu.Size = new System.Drawing.Size(112, 22);
            plainMenu.Text = "明文(&P)";
            // 
            // newPlainMenuItem
            // 
            newPlainMenuItem.Name = "newPlainMenuItem";
            newPlainMenuItem.Size = new System.Drawing.Size(130, 22);
            newPlainMenuItem.Text = "新建(&N)";
            newPlainMenuItem.Click += new System.EventHandler(this.newPlainMenuItem_Click);
            // 
            // openPlainMenuItem
            // 
            openPlainMenuItem.Name = "openPlainMenuItem";
            openPlainMenuItem.Size = new System.Drawing.Size(130, 22);
            openPlainMenuItem.Text = "打开(&O)...";
            openPlainMenuItem.Click += new System.EventHandler(this.openPlainMenuItem_Click);
            // 
            // savePlainMenuItem
            // 
            this.savePlainMenuItem.Name = "savePlainMenuItem";
            this.savePlainMenuItem.Size = new System.Drawing.Size(130, 22);
            this.savePlainMenuItem.Text = "保存(&S)...";
            this.savePlainMenuItem.Click += new System.EventHandler(this.savePlainMenuItem_Click);
            // 
            // cipherMenu
            // 
            cipherMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCipherMenuItem,
            this.openCipherMenuItem,
            this.saveCipherMenuItem});
            cipherMenu.Name = "cipherMenu";
            cipherMenu.Size = new System.Drawing.Size(112, 22);
            cipherMenu.Text = "密文(&C)";
            // 
            // newCipherMenuItem
            // 
            this.newCipherMenuItem.Name = "newCipherMenuItem";
            this.newCipherMenuItem.Size = new System.Drawing.Size(130, 22);
            this.newCipherMenuItem.Text = "新建(&N)";
            this.newCipherMenuItem.Click += new System.EventHandler(this.newCipherMenuItem_Click);
            // 
            // openCipherMenuItem
            // 
            this.openCipherMenuItem.Name = "openCipherMenuItem";
            this.openCipherMenuItem.Size = new System.Drawing.Size(130, 22);
            this.openCipherMenuItem.Text = "打开(&O)...";
            this.openCipherMenuItem.Click += new System.EventHandler(this.openCipherMenuItem_Click);
            // 
            // saveCipherMenuItem
            // 
            this.saveCipherMenuItem.Name = "saveCipherMenuItem";
            this.saveCipherMenuItem.Size = new System.Drawing.Size(130, 22);
            this.saveCipherMenuItem.Text = "保存(&S)...";
            this.saveCipherMenuItem.Click += new System.EventHandler(this.saveCipherMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitMenuItem.Text = "退出(&X)";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // operationMenu
            // 
            operationMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ecryptMenuItem,
            this.decryptMenuItem,
            this.signMenuItem,
            this.verifyMenuItem});
            operationMenu.Name = "operationMenu";
            operationMenu.Size = new System.Drawing.Size(59, 20);
            operationMenu.Text = "操作(&O)";
            // 
            // ecryptMenuItem
            // 
            this.ecryptMenuItem.Name = "ecryptMenuItem";
            this.ecryptMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.ecryptMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ecryptMenuItem.Text = "加密(&E)";
            this.ecryptMenuItem.Click += new System.EventHandler(this.ecryptMenuItem_Click);
            // 
            // decryptMenuItem
            // 
            this.decryptMenuItem.Name = "decryptMenuItem";
            this.decryptMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.decryptMenuItem.Size = new System.Drawing.Size(171, 22);
            this.decryptMenuItem.Text = "解密(&D)";
            this.decryptMenuItem.Click += new System.EventHandler(this.decryptMenuItem_Click);
            // 
            // signMenuItem
            // 
            this.signMenuItem.Name = "signMenuItem";
            this.signMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.signMenuItem.Size = new System.Drawing.Size(171, 22);
            this.signMenuItem.Text = "签名(&S)...";
            this.signMenuItem.Click += new System.EventHandler(this.signMenuItem_Click);
            // 
            // verifyMenuItem
            // 
            this.verifyMenuItem.Name = "verifyMenuItem";
            this.verifyMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.verifyMenuItem.Size = new System.Drawing.Size(171, 22);
            this.verifyMenuItem.Text = "验证签名(&V)...";
            this.verifyMenuItem.Click += new System.EventHandler(this.verifyMenuItem_Click);
            // 
            // settingMenu
            // 
            this.settingMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            encodingMenu,
            toolStripSeparator4,
            symmetricMenu,
            asymmetricMenu,
            hashMenu});
            this.settingMenu.Name = "settingMenu";
            this.settingMenu.Size = new System.Drawing.Size(59, 20);
            this.settingMenu.Text = "设置(&S)";
            // 
            // encodingMenu
            // 
            encodingMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gb2312MenuItem,
            this.asciiMenuItem,
            this.unicodeMenuItem,
            this.utf8MenuItem});
            encodingMenu.Name = "encodingMenu";
            encodingMenu.Size = new System.Drawing.Size(152, 22);
            encodingMenu.Text = "明文编码(&E)";
            // 
            // gb2312MenuItem
            // 
            this.gb2312MenuItem.Checked = true;
            this.gb2312MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gb2312MenuItem.Name = "gb2312MenuItem";
            this.gb2312MenuItem.Size = new System.Drawing.Size(130, 22);
            this.gb2312MenuItem.Text = "GB2312(&G)";
            this.gb2312MenuItem.Click += new System.EventHandler(this.gb2312MenuItem_Click);
            // 
            // asciiMenuItem
            // 
            this.asciiMenuItem.Name = "asciiMenuItem";
            this.asciiMenuItem.Size = new System.Drawing.Size(130, 22);
            this.asciiMenuItem.Text = "ASCII(&A)";
            this.asciiMenuItem.Click += new System.EventHandler(this.asciiMenuItem_Click);
            // 
            // unicodeMenuItem
            // 
            this.unicodeMenuItem.Name = "unicodeMenuItem";
            this.unicodeMenuItem.Size = new System.Drawing.Size(130, 22);
            this.unicodeMenuItem.Text = "UNICODE(&U)";
            this.unicodeMenuItem.Click += new System.EventHandler(this.unicodeMenuItem_Click);
            // 
            // utf8MenuItem
            // 
            this.utf8MenuItem.Name = "utf8MenuItem";
            this.utf8MenuItem.Size = new System.Drawing.Size(130, 22);
            this.utf8MenuItem.Text = "UTF-8(&8)";
            this.utf8MenuItem.Click += new System.EventHandler(this.utf8MenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // symmetricMenu
            // 
            symmetricMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rc40MenuItem,
            this.rc128MenuItem,
            this.tripleDESMenuItem,
            toolStripSeparator3,
            passwordMenu,
            keyMenuItem});
            symmetricMenu.Name = "symmetricMenu";
            symmetricMenu.Size = new System.Drawing.Size(152, 22);
            symmetricMenu.Text = "对称加密(&S)";
            // 
            // rc40MenuItem
            // 
            this.rc40MenuItem.Name = "rc40MenuItem";
            this.rc40MenuItem.Size = new System.Drawing.Size(195, 22);
            this.rc40MenuItem.Text = "RC2 40位(&4)";
            this.rc40MenuItem.Click += new System.EventHandler(this.rc40MenuItem_Click);
            // 
            // rc128MenuItem
            // 
            this.rc128MenuItem.Name = "rc128MenuItem";
            this.rc128MenuItem.Size = new System.Drawing.Size(195, 22);
            this.rc128MenuItem.Text = "RC2 128位(&1)";
            this.rc128MenuItem.Click += new System.EventHandler(this.rc128MenuItem_Click);
            // 
            // tripleDESMenuItem
            // 
            this.tripleDESMenuItem.Checked = true;
            this.tripleDESMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tripleDESMenuItem.Name = "tripleDESMenuItem";
            this.tripleDESMenuItem.Size = new System.Drawing.Size(195, 22);
            this.tripleDESMenuItem.Text = "3DES(&3)";
            this.tripleDESMenuItem.Click += new System.EventHandler(this.tripleDESMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(192, 6);
            // 
            // passwordMenu
            // 
            passwordMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asciiPasswordMenuItem,
            this.unicodePasswordMenuItem,
            this.hexPasswordMenuItem,
            toolStripSeparator6,
            this.passwordMenuItem});
            passwordMenu.Name = "passwordMenu";
            passwordMenu.Size = new System.Drawing.Size(195, 22);
            passwordMenu.Text = "密码(&P)";
            // 
            // asciiPasswordMenuItem
            // 
            this.asciiPasswordMenuItem.Checked = true;
            this.asciiPasswordMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.asciiPasswordMenuItem.Name = "asciiPasswordMenuItem";
            this.asciiPasswordMenuItem.Size = new System.Drawing.Size(195, 22);
            this.asciiPasswordMenuItem.Text = "ASCII字符串(&A)";
            this.asciiPasswordMenuItem.Click += new System.EventHandler(this.asciiPasswordMenuItem_Click);
            // 
            // unicodePasswordMenuItem
            // 
            this.unicodePasswordMenuItem.Name = "unicodePasswordMenuItem";
            this.unicodePasswordMenuItem.Size = new System.Drawing.Size(195, 22);
            this.unicodePasswordMenuItem.Text = "UNICODE字符串(&U)";
            this.unicodePasswordMenuItem.Click += new System.EventHandler(this.unicodePasswordMenuItem_Click);
            // 
            // hexPasswordMenuItem
            // 
            this.hexPasswordMenuItem.Name = "hexPasswordMenuItem";
            this.hexPasswordMenuItem.Size = new System.Drawing.Size(195, 22);
            this.hexPasswordMenuItem.Text = "二进制数据(&H)";
            this.hexPasswordMenuItem.Click += new System.EventHandler(this.hexPasswordMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(192, 6);
            // 
            // passwordMenuItem
            // 
            this.passwordMenuItem.Name = "passwordMenuItem";
            this.passwordMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.passwordMenuItem.Size = new System.Drawing.Size(195, 22);
            this.passwordMenuItem.Text = "设置密码(&P)...";
            this.passwordMenuItem.Click += new System.EventHandler(this.passwordMenuItem_Click);
            // 
            // asymmetricMenu
            // 
            asymmetricMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rsaMenuItem,
            this.dsaMenuItem,
            toolStripSeparator2,
            this.keySize384MenuItem,
            this.keySize512MenuItem,
            this.keySize1024MenuItem,
            this.keySize2048MenuItem,
            this.keySize4096MenuItem,
            toolStripSeparator5,
            newKeyMenuItem,
            this.publicKeyMenuItem,
            this.privateKeyMenuItem});
            asymmetricMenu.Name = "asymmetricMenu";
            asymmetricMenu.Size = new System.Drawing.Size(152, 22);
            asymmetricMenu.Text = "非对称加密(&A)";
            // 
            // rsaMenuItem
            // 
            this.rsaMenuItem.Checked = true;
            this.rsaMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rsaMenuItem.Name = "rsaMenuItem";
            this.rsaMenuItem.Size = new System.Drawing.Size(195, 22);
            this.rsaMenuItem.Text = "RSA(&R)";
            this.rsaMenuItem.Click += new System.EventHandler(this.rsaMenuItem_Click);
            // 
            // dsaMenuItem
            // 
            this.dsaMenuItem.Name = "dsaMenuItem";
            this.dsaMenuItem.Size = new System.Drawing.Size(195, 22);
            this.dsaMenuItem.Text = "DSA(&D)";
            this.dsaMenuItem.Click += new System.EventHandler(this.dsaMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // keySize384MenuItem
            // 
            this.keySize384MenuItem.Name = "keySize384MenuItem";
            this.keySize384MenuItem.Size = new System.Drawing.Size(195, 22);
            this.keySize384MenuItem.Text = "384位(&3)";
            this.keySize384MenuItem.Click += new System.EventHandler(this.keySize384MenuItem_Click);
            // 
            // keySize512MenuItem
            // 
            this.keySize512MenuItem.Checked = true;
            this.keySize512MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keySize512MenuItem.Name = "keySize512MenuItem";
            this.keySize512MenuItem.Size = new System.Drawing.Size(195, 22);
            this.keySize512MenuItem.Text = "512位(&5)";
            this.keySize512MenuItem.Click += new System.EventHandler(this.keySize512MenuItem_Click);
            // 
            // keySize1024MenuItem
            // 
            this.keySize1024MenuItem.Name = "keySize1024MenuItem";
            this.keySize1024MenuItem.Size = new System.Drawing.Size(195, 22);
            this.keySize1024MenuItem.Text = "1024位(&1)";
            this.keySize1024MenuItem.Click += new System.EventHandler(this.keySize1024MenuItem_Click);
            // 
            // keySize2048MenuItem
            // 
            this.keySize2048MenuItem.Name = "keySize2048MenuItem";
            this.keySize2048MenuItem.Size = new System.Drawing.Size(195, 22);
            this.keySize2048MenuItem.Text = "2048位(&2)";
            this.keySize2048MenuItem.Click += new System.EventHandler(this.keySize2048MenuItem_Click);
            // 
            // keySize4096MenuItem
            // 
            this.keySize4096MenuItem.Name = "keySize4096MenuItem";
            this.keySize4096MenuItem.Size = new System.Drawing.Size(195, 22);
            this.keySize4096MenuItem.Text = "4096位(&4)";
            this.keySize4096MenuItem.Click += new System.EventHandler(this.keySize4096MenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(192, 6);
            // 
            // newKeyMenuItem
            // 
            newKeyMenuItem.Name = "newKeyMenuItem";
            newKeyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            newKeyMenuItem.Size = new System.Drawing.Size(195, 22);
            newKeyMenuItem.Text = "生成密钥(&N)...";
            newKeyMenuItem.Click += new System.EventHandler(this.newKeyMenuItem_Click);
            // 
            // publicKeyMenuItem
            // 
            this.publicKeyMenuItem.Name = "publicKeyMenuItem";
            this.publicKeyMenuItem.Size = new System.Drawing.Size(195, 22);
            this.publicKeyMenuItem.Text = "公钥(&P)...";
            this.publicKeyMenuItem.Click += new System.EventHandler(this.publicKeyMenuItem_Click);
            // 
            // privateKeyMenuItem
            // 
            this.privateKeyMenuItem.Name = "privateKeyMenuItem";
            this.privateKeyMenuItem.Size = new System.Drawing.Size(195, 22);
            this.privateKeyMenuItem.Text = "私钥(&R)...";
            this.privateKeyMenuItem.Click += new System.EventHandler(this.privateKeyMenuItem_Click);
            // 
            // hashMenu
            // 
            hashMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.md5MenuItem,
            this.sha1MenuItem});
            hashMenu.Name = "hashMenu";
            hashMenu.Size = new System.Drawing.Size(152, 22);
            hashMenu.Text = "散列(&H)";
            // 
            // md5MenuItem
            // 
            this.md5MenuItem.Checked = true;
            this.md5MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.md5MenuItem.Name = "md5MenuItem";
            this.md5MenuItem.Size = new System.Drawing.Size(112, 22);
            this.md5MenuItem.Text = "MD5(&M)";
            this.md5MenuItem.Click += new System.EventHandler(this.md5MenuItem_Click);
            // 
            // sha1MenuItem
            // 
            this.sha1MenuItem.Name = "sha1MenuItem";
            this.sha1MenuItem.Size = new System.Drawing.Size(112, 22);
            this.sha1MenuItem.Text = "SHA1(&S)";
            this.sha1MenuItem.Click += new System.EventHandler(this.sha1MenuItem_Click);
            // 
            // helpMenu
            // 
            helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new System.Drawing.Size(59, 20);
            helpMenu.Text = "帮助(&H)";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(130, 22);
            this.aboutMenuItem.Text = "关于(&A)...";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(0, 24);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.textBox);
            this.splitter.Size = new System.Drawing.Size(592, 370);
            this.splitter.SplitterDistance = 275;
            this.splitter.TabIndex = 2;
            // 
            // textBox
            // 
            this.textBox.AcceptsReturn = true;
            this.textBox.AcceptsTab = true;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(275, 370);
            this.textBox.TabIndex = 0;
            this.textBox.WordWrap = false;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 394);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(592, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // keyMenuItem
            // 
            keyMenuItem.Name = "keyMenuItem";
            keyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            keyMenuItem.Size = new System.Drawing.Size(195, 22);
            keyMenuItem.Text = "导入密钥(&K)...";
            keyMenuItem.Click += new System.EventHandler(this.keyMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 416);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(mainMenu);
            this.MainMenuStrip = mainMenu;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "加密工具";
            this.Load += new System.EventHandler(this.Form_Load);
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel1.PerformLayout();
            this.splitter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ToolStripMenuItem savePlainMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCipherMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCipherMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCipherMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ecryptMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decryptMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verifyMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.ToolStripMenuItem settingMenu;
        private System.Windows.Forms.ToolStripMenuItem md5MenuItem;
        private System.Windows.Forms.ToolStripMenuItem sha1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem rc40MenuItem;
        private System.Windows.Forms.ToolStripMenuItem tripleDESMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rsaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dsaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gb2312MenuItem;
        private System.Windows.Forms.ToolStripMenuItem asciiMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unicodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utf8MenuItem;
        private System.Windows.Forms.ToolStripMenuItem publicKeyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem privateKeyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keySize384MenuItem;
        private System.Windows.Forms.ToolStripMenuItem keySize512MenuItem;
        private System.Windows.Forms.ToolStripMenuItem keySize1024MenuItem;
        private System.Windows.Forms.ToolStripMenuItem keySize2048MenuItem;
        private System.Windows.Forms.ToolStripMenuItem keySize4096MenuItem;
        private System.Windows.Forms.ToolStripMenuItem rc128MenuItem;
        private System.Windows.Forms.ToolStripMenuItem asciiPasswordMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unicodePasswordMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexPasswordMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordMenuItem;

    }
}

