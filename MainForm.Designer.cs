namespace HideInBMP {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menu = new MenuStrip();
            basicMenu = new ToolStripMenuItem();
            reset = new ToolStripMenuItem();
            exit = new ToolStripMenuItem();
            help = new ToolStripMenuItem();
            about = new ToolStripMenuItem();
            fromFile = new OpenFileDialog();
            outputFile = new FolderBrowserDialog();
            preview = new Label();
            outputBMP = new PictureBox();
            outputPreview = new Label();
            outputPanel = new Panel();
            outputPath = new TextBox();
            outputBrowser = new Button();
            outputFileTip = new Label();
            hideFilePanel = new Panel();
            hideSize = new Label();
            hideOrExtractFileLabel = new Label();
            hideSizeLabel = new Label();
            maxHideSize = new Label();
            hideBrowser = new Button();
            hideOrExtractPath = new TextBox();
            hideSize1 = new Label();
            fromPath = new TextBox();
            fromBMP = new PictureBox();
            fromFilePanel = new Panel();
            fromSize = new Label();
            fromBrowser = new Button();
            fromFileTip = new Label();
            fileSize1 = new Label();
            hideFile = new OpenFileDialog();
            operateButtons = new Panel();
            startExtract = new Button();
            check = new Button();
            startHide = new Button();
            progressPanel = new Panel();
            statusLabel = new Label();
            progressBar = new ProgressBar();
            menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)outputBMP).BeginInit();
            outputPanel.SuspendLayout();
            hideFilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fromBMP).BeginInit();
            fromFilePanel.SuspendLayout();
            operateButtons.SuspendLayout();
            progressPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(32, 32);
            menu.Items.AddRange(new ToolStripItem[] { basicMenu, help });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(1174, 39);
            menu.TabIndex = 9;
            menu.Text = "menuStrip1";
            // 
            // basicMenu
            // 
            basicMenu.DropDownItems.AddRange(new ToolStripItem[] { reset, exit });
            basicMenu.Name = "basicMenu";
            basicMenu.Size = new Size(130, 35);
            basicMenu.Text = "基础菜单";
            // 
            // reset
            // 
            reset.Image = Properties.Resources.重置;
            reset.Name = "reset";
            reset.Size = new Size(195, 44);
            reset.Text = "重置";
            reset.Click += reset_Click;
            // 
            // exit
            // 
            exit.Image = Properties.Resources.退出;
            exit.Name = "exit";
            exit.Size = new Size(195, 44);
            exit.Text = "退出";
            exit.Click += exit_Click;
            // 
            // help
            // 
            help.DropDownItems.AddRange(new ToolStripItem[] { about });
            help.Name = "help";
            help.Size = new Size(82, 35);
            help.Text = "帮助";
            // 
            // about
            // 
            about.Image = Properties.Resources.关于;
            about.Name = "about";
            about.Size = new Size(195, 44);
            about.Text = "关于";
            about.Click += about_Click;
            // 
            // fromFile
            // 
            fromFile.Filter = "BMP图片文件(*.bmp) | *.bmp";
            fromFile.Title = "选择要隐写入的图片(仅限BMP图片)";
            // 
            // outputFile
            // 
            outputFile.Description = "选择隐写后输出文件夹";
            // 
            // preview
            // 
            preview.AutoSize = true;
            preview.BackColor = Color.Transparent;
            preview.Location = new Point(32, 47);
            preview.Name = "preview";
            preview.Size = new Size(174, 31);
            preview.TabIndex = 12;
            preview.Text = "图片浏览(原图)";
            // 
            // outputBMP
            // 
            outputBMP.BackColor = SystemColors.ControlLightLight;
            outputBMP.BorderStyle = BorderStyle.FixedSingle;
            outputBMP.Location = new Point(603, 87);
            outputBMP.MinimumSize = new Size(550, 550);
            outputBMP.Name = "outputBMP";
            outputBMP.Size = new Size(550, 550);
            outputBMP.SizeMode = PictureBoxSizeMode.Zoom;
            outputBMP.TabIndex = 22;
            outputBMP.TabStop = false;
            // 
            // outputPreview
            // 
            outputPreview.AutoSize = true;
            outputPreview.BackColor = Color.Transparent;
            outputPreview.Location = new Point(603, 51);
            outputPreview.Name = "outputPreview";
            outputPreview.Size = new Size(198, 31);
            outputPreview.TabIndex = 23;
            outputPreview.Text = "图片浏览(输出图)";
            // 
            // outputPanel
            // 
            outputPanel.BorderStyle = BorderStyle.FixedSingle;
            outputPanel.Controls.Add(outputPath);
            outputPanel.Controls.Add(outputBrowser);
            outputPanel.Controls.Add(outputFileTip);
            outputPanel.Location = new Point(603, 641);
            outputPanel.Name = "outputPanel";
            outputPanel.Size = new Size(550, 146);
            outputPanel.TabIndex = 24;
            // 
            // outputPath
            // 
            outputPath.BorderStyle = BorderStyle.FixedSingle;
            outputPath.Location = new Point(-1, 33);
            outputPath.MinimumSize = new Size(550, 38);
            outputPath.Name = "outputPath";
            outputPath.ReadOnly = true;
            outputPath.Size = new Size(550, 38);
            outputPath.TabIndex = 3;
            outputPath.TabStop = false;
            // 
            // outputBrowser
            // 
            outputBrowser.Location = new Point(399, 77);
            outputBrowser.Name = "outputBrowser";
            outputBrowser.Size = new Size(150, 46);
            outputBrowser.TabIndex = 5;
            outputBrowser.Text = "浏览";
            outputBrowser.UseVisualStyleBackColor = true;
            outputBrowser.Click += outputBrowser_Click;
            // 
            // outputFileTip
            // 
            outputFileTip.AutoSize = true;
            outputFileTip.BackColor = Color.Transparent;
            outputFileTip.Location = new Point(-1, 1);
            outputFileTip.Name = "outputFileTip";
            outputFileTip.Size = new Size(134, 31);
            outputFileTip.TabIndex = 11;
            outputFileTip.Text = "输出文件夹";
            // 
            // hideFilePanel
            // 
            hideFilePanel.BorderStyle = BorderStyle.FixedSingle;
            hideFilePanel.Controls.Add(hideSize);
            hideFilePanel.Controls.Add(hideSizeLabel);
            hideFilePanel.Controls.Add(maxHideSize);
            hideFilePanel.Controls.Add(hideBrowser);
            hideFilePanel.Controls.Add(hideOrExtractPath);
            hideFilePanel.Controls.Add(hideSize1);
            hideFilePanel.Controls.Add(hideOrExtractFileLabel);
            hideFilePanel.Location = new Point(32, 785);
            hideFilePanel.Name = "hideFilePanel";
            hideFilePanel.Size = new Size(550, 146);
            hideFilePanel.TabIndex = 27;
            // 
            // hideSize
            // 
            hideSize.AutoSize = true;
            hideSize.BackColor = Color.Transparent;
            hideSize.Location = new Point(160, 97);
            hideSize.Name = "hideSize";
            hideSize.Size = new Size(28, 31);
            hideSize.TabIndex = 12;
            hideSize.Text = "0";
            hideSize.MouseLeave += hideSize_MouseLeave;
            hideSize.MouseHover += hideSize_MouseHover;
            // 
            // hideOrExtractFileLabel
            // 
            hideOrExtractFileLabel.AutoSize = true;
            hideOrExtractFileLabel.Location = new Point(0, 4);
            hideOrExtractFileLabel.Name = "hideOrExtractFileLabel";
            hideOrExtractFileLabel.Size = new Size(188, 31);
            hideOrExtractFileLabel.TabIndex = 18;
            hideOrExtractFileLabel.Text = "隐写/提取文件 | ";
            // 
            // hideSizeLabel
            // 
            hideSizeLabel.AutoSize = true;
            hideSizeLabel.BackColor = Color.Transparent;
            hideSizeLabel.Location = new Point(-1, 97);
            hideSizeLabel.Name = "hideSizeLabel";
            hideSizeLabel.Size = new Size(189, 31);
            hideSizeLabel.TabIndex = 11;
            hideSizeLabel.Text = "当前文件大小： ";
            // 
            // maxHideSize
            // 
            maxHideSize.AutoSize = true;
            maxHideSize.BackColor = Color.Transparent;
            maxHideSize.Location = new Point(407, 4);
            maxHideSize.Name = "maxHideSize";
            maxHideSize.Size = new Size(28, 31);
            maxHideSize.TabIndex = 17;
            maxHideSize.Text = "0";
            maxHideSize.MouseLeave += maxHideSize_MouseLeave;
            maxHideSize.MouseHover += maxHideSize_MouseHover;
            // 
            // hideBrowser
            // 
            hideBrowser.Location = new Point(400, 82);
            hideBrowser.Name = "hideBrowser";
            hideBrowser.Size = new Size(150, 46);
            hideBrowser.TabIndex = 16;
            hideBrowser.Text = "浏览";
            hideBrowser.UseVisualStyleBackColor = true;
            hideBrowser.Click += hideBrowser_Click;
            // 
            // hideOrExtractPath
            // 
            hideOrExtractPath.BorderStyle = BorderStyle.FixedSingle;
            hideOrExtractPath.Location = new Point(-1, 38);
            hideOrExtractPath.MinimumSize = new Size(550, 38);
            hideOrExtractPath.Name = "hideOrExtractPath";
            hideOrExtractPath.ReadOnly = true;
            hideOrExtractPath.Size = new Size(550, 38);
            hideOrExtractPath.TabIndex = 15;
            hideOrExtractPath.TabStop = false;
            hideOrExtractPath.TextChanged += hideOrExtractPath_TextChanged;
            // 
            // hideSize1
            // 
            hideSize1.AutoSize = true;
            hideSize1.BackColor = Color.Transparent;
            hideSize1.Location = new Point(174, 4);
            hideSize1.Name = "hideSize1";
            hideSize1.Size = new Size(261, 31);
            hideSize1.TabIndex = 14;
            hideSize1.Text = "最大可隐写文件大小： ";
            // 
            // fromPath
            // 
            fromPath.BorderStyle = BorderStyle.FixedSingle;
            fromPath.Location = new Point(32, 675);
            fromPath.MinimumSize = new Size(550, 38);
            fromPath.Name = "fromPath";
            fromPath.ReadOnly = true;
            fromPath.Size = new Size(550, 38);
            fromPath.TabIndex = 26;
            fromPath.TabStop = false;
            fromPath.TextChanged += fromPath_TextChanged;
            // 
            // fromBMP
            // 
            fromBMP.BackColor = SystemColors.ControlLightLight;
            fromBMP.BorderStyle = BorderStyle.FixedSingle;
            fromBMP.Location = new Point(32, 87);
            fromBMP.MinimumSize = new Size(550, 550);
            fromBMP.Name = "fromBMP";
            fromBMP.Size = new Size(550, 550);
            fromBMP.SizeMode = PictureBoxSizeMode.Zoom;
            fromBMP.TabIndex = 25;
            fromBMP.TabStop = false;
            // 
            // fromFilePanel
            // 
            fromFilePanel.BorderStyle = BorderStyle.FixedSingle;
            fromFilePanel.Controls.Add(fromSize);
            fromFilePanel.Controls.Add(fromBrowser);
            fromFilePanel.Controls.Add(fromFileTip);
            fromFilePanel.Controls.Add(fileSize1);
            fromFilePanel.Location = new Point(32, 641);
            fromFilePanel.Name = "fromFilePanel";
            fromFilePanel.Size = new Size(550, 146);
            fromFilePanel.TabIndex = 28;
            // 
            // fromSize
            // 
            fromSize.AutoSize = true;
            fromSize.BackColor = Color.Transparent;
            fromSize.Location = new Point(160, 94);
            fromSize.Name = "fromSize";
            fromSize.Size = new Size(28, 31);
            fromSize.TabIndex = 8;
            fromSize.Text = "0";
            fromSize.MouseLeave += fromSize_MouseLeave;
            fromSize.MouseHover += fromSize_MouseHover;
            // 
            // fromBrowser
            // 
            fromBrowser.Location = new Point(399, 79);
            fromBrowser.Name = "fromBrowser";
            fromBrowser.Size = new Size(150, 46);
            fromBrowser.TabIndex = 4;
            fromBrowser.Text = "浏览";
            fromBrowser.UseVisualStyleBackColor = true;
            fromBrowser.Click += fromBrowser_Click;
            // 
            // fromFileTip
            // 
            fromFileTip.AutoSize = true;
            fromFileTip.BackColor = Color.Transparent;
            fromFileTip.Location = new Point(-1, 1);
            fromFileTip.Name = "fromFileTip";
            fromFileTip.Size = new Size(323, 31);
            fromFileTip.TabIndex = 10;
            fromFileTip.Text = "隐写目标图片(仅限BMP图片)";
            // 
            // fileSize1
            // 
            fileSize1.AutoSize = true;
            fileSize1.BackColor = Color.Transparent;
            fileSize1.Location = new Point(-1, 94);
            fileSize1.Name = "fileSize1";
            fileSize1.Size = new Size(189, 31);
            fileSize1.TabIndex = 6;
            fileSize1.Text = "当前文件大小： ";
            // 
            // hideFile
            // 
            hideFile.Filter = "BMP图片文件(*.bmp)|*.bmp|所有文件(*.*)|*.*";
            hideFile.FilterIndex = 2;
            hideFile.Title = "选择想要隐藏的文件(注意大小限制)";
            // 
            // operateButtons
            // 
            operateButtons.BorderStyle = BorderStyle.FixedSingle;
            operateButtons.Controls.Add(startExtract);
            operateButtons.Controls.Add(check);
            operateButtons.Controls.Add(startHide);
            operateButtons.Location = new Point(32, 937);
            operateButtons.Name = "operateButtons";
            operateButtons.Size = new Size(1121, 73);
            operateButtons.TabIndex = 29;
            // 
            // startExtract
            // 
            startExtract.Enabled = false;
            startExtract.Location = new Point(749, 3);
            startExtract.Name = "startExtract";
            startExtract.Size = new Size(369, 65);
            startExtract.TabIndex = 2;
            startExtract.Text = "提取";
            startExtract.UseVisualStyleBackColor = true;
            startExtract.Click += startExtract_Click;
            // 
            // check
            // 
            check.Enabled = false;
            check.Location = new Point(376, 3);
            check.Name = "check";
            check.Size = new Size(369, 65);
            check.TabIndex = 1;
            check.Text = "校验";
            check.UseVisualStyleBackColor = true;
            check.Click += check_Click;
            // 
            // startHide
            // 
            startHide.Enabled = false;
            startHide.Location = new Point(3, 3);
            startHide.Name = "startHide";
            startHide.Size = new Size(369, 65);
            startHide.TabIndex = 0;
            startHide.Text = "隐写";
            startHide.UseVisualStyleBackColor = true;
            startHide.Click += startHide_Click;
            // 
            // progressPanel
            // 
            progressPanel.BorderStyle = BorderStyle.FixedSingle;
            progressPanel.Controls.Add(statusLabel);
            progressPanel.Controls.Add(progressBar);
            progressPanel.Location = new Point(603, 785);
            progressPanel.Name = "progressPanel";
            progressPanel.Size = new Size(550, 146);
            progressPanel.TabIndex = 30;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.BackColor = Color.Transparent;
            statusLabel.Location = new Point(0, 26);
            statusLabel.MinimumSize = new Size(550, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(550, 31);
            statusLabel.TabIndex = 33;
            statusLabel.Text = "0%";
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(-1, 70);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(550, 46);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 31;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1174, 1029);
            Controls.Add(progressPanel);
            Controls.Add(operateButtons);
            Controls.Add(hideFilePanel);
            Controls.Add(fromPath);
            Controls.Add(fromBMP);
            Controls.Add(fromFilePanel);
            Controls.Add(outputBMP);
            Controls.Add(outputPreview);
            Controls.Add(outputPanel);
            Controls.Add(preview);
            Controls.Add(menu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menu;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BMP隐写文件 —— By SDSC0623";
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)outputBMP).EndInit();
            outputPanel.ResumeLayout(false);
            outputPanel.PerformLayout();
            hideFilePanel.ResumeLayout(false);
            hideFilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fromBMP).EndInit();
            fromFilePanel.ResumeLayout(false);
            fromFilePanel.PerformLayout();
            operateButtons.ResumeLayout(false);
            progressPanel.ResumeLayout(false);
            progressPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menu;
        private ToolStripMenuItem basicMenu;
        private ToolStripMenuItem exit;
        private ToolStripMenuItem help;
        private ToolStripMenuItem about;
        private OpenFileDialog fromFile;
        private FolderBrowserDialog outputFile;
        private Label preview;
        private PictureBox outputBMP;
        private Label outputPreview;
        private Panel outputPanel;
        private TextBox outputPath;
        private Button outputBrowser;
        private Label outputFileTip;
        private Panel hideFilePanel;
        private Label hideOrExtractFileLabel;
        private Label maxHideSize;
        private Button hideBrowser;
        private TextBox hideOrExtractPath;
        private Label hideSize1;
        private TextBox fromPath;
        private PictureBox fromBMP;
        private Panel fromFilePanel;
        private Label fileSize1;
        private Label fromSize;
        private Button fromBrowser;
        private Label fromFileTip;
        private OpenFileDialog hideFile;
        private Panel operateButtons;
        private Button startHide;
        private Button startExtract;
        private Button check;
        private Panel progressPanel;
        private ProgressBar progressBar;
        private ToolStripMenuItem reset;
        private Label hideSize;
        private Label hideSizeLabel;
        private Label statusLabel;
    }
}
