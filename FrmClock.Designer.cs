namespace TomatoClock
{
    partial class FrmClock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClock));
            this.lblRemain = new System.Windows.Forms.Label();
            this.lblClockCount = new System.Windows.Forms.Label();
            this.menuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmPause = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHideFlowWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLittleView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMidleView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBigView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRemain
            // 
            this.lblRemain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemain.AutoSize = true;
            this.lblRemain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblRemain.Location = new System.Drawing.Point(22, 0);
            this.lblRemain.Name = "lblRemain";
            this.lblRemain.Size = new System.Drawing.Size(28, 21);
            this.lblRemain.TabIndex = 0;
            this.lblRemain.Text = "25";
            this.lblRemain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EMSecure_MouseDown);
            // 
            // lblClockCount
            // 
            this.lblClockCount.AutoSize = true;
            this.lblClockCount.BackColor = System.Drawing.Color.Transparent;
            this.lblClockCount.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClockCount.ForeColor = System.Drawing.Color.White;
            this.lblClockCount.Location = new System.Drawing.Point(3, 1);
            this.lblClockCount.Name = "lblClockCount";
            this.lblClockCount.Size = new System.Drawing.Size(17, 20);
            this.lblClockCount.TabIndex = 0;
            this.lblClockCount.Text = "0";
            this.lblClockCount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EMSecure_MouseDown);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPause,
            this.tsmHideFlowWindow,
            this.tsmReset,
            this.toolStripSeparator1,
            this.tsmView,
            this.toolStripSeparator2,
            this.tsmSettings,
            this.tsmQuit});
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(140, 148);
            this.menuMain.Opening += new System.ComponentModel.CancelEventHandler(this.menuMain_Opening);
            // 
            // tsmPause
            // 
            this.tsmPause.Name = "tsmPause";
            this.tsmPause.Size = new System.Drawing.Size(139, 22);
            this.tsmPause.Text = "暂停";
            this.tsmPause.Click += new System.EventHandler(this.tsmPause_Click);
            // 
            // tsmHideFlowWindow
            // 
            this.tsmHideFlowWindow.Name = "tsmHideFlowWindow";
            this.tsmHideFlowWindow.Size = new System.Drawing.Size(139, 22);
            this.tsmHideFlowWindow.Text = "隐藏悬浮窗";
            this.tsmHideFlowWindow.Click += new System.EventHandler(this.tsmHideFlowWindow_Click);
            // 
            // tsmReset
            // 
            this.tsmReset.Name = "tsmReset";
            this.tsmReset.Size = new System.Drawing.Size(139, 22);
            this.tsmReset.Text = "重置";
            this.tsmReset.Click += new System.EventHandler(this.tsmReset_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // tsmView
            // 
            this.tsmView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLittleView,
            this.tsmMidleView,
            this.tsmBigView});
            this.tsmView.Name = "tsmView";
            this.tsmView.Size = new System.Drawing.Size(139, 22);
            this.tsmView.Text = "视图";
            // 
            // tsmLittleView
            // 
            this.tsmLittleView.Name = "tsmLittleView";
            this.tsmLittleView.Size = new System.Drawing.Size(113, 22);
            this.tsmLittleView.Text = "小视图";
            this.tsmLittleView.Click += new System.EventHandler(this.tsmLittleView_Click);
            // 
            // tsmMidleView
            // 
            this.tsmMidleView.Name = "tsmMidleView";
            this.tsmMidleView.Size = new System.Drawing.Size(113, 22);
            this.tsmMidleView.Text = "中视图";
            this.tsmMidleView.Click += new System.EventHandler(this.tsmMidleView_Click);
            // 
            // tsmBigView
            // 
            this.tsmBigView.Name = "tsmBigView";
            this.tsmBigView.Size = new System.Drawing.Size(113, 22);
            this.tsmBigView.Text = "大视图";
            this.tsmBigView.Click += new System.EventHandler(this.tsmBigView_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(136, 6);
            // 
            // tsmSettings
            // 
            this.tsmSettings.Name = "tsmSettings";
            this.tsmSettings.Size = new System.Drawing.Size(139, 22);
            this.tsmSettings.Text = "设置";
            this.tsmSettings.Click += new System.EventHandler(this.tsmSettings_Click);
            // 
            // tsmQuit
            // 
            this.tsmQuit.Name = "tsmQuit";
            this.tsmQuit.Size = new System.Drawing.Size(139, 22);
            this.tsmQuit.Text = "退出";
            this.tsmQuit.Click += new System.EventHandler(this.tsmQuit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menuMain;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ChDCTomatoClock";
            this.notifyIcon.Visible = true;
            // 
            // picBackground
            // 
            this.picBackground.ContextMenuStrip = this.menuMain;
            this.picBackground.Image = global::TomatoClock.Properties.Resources.ClockBackground;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(50, 23);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 1;
            this.picBackground.TabStop = false;
            // 
            // FrmClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(219, 111);
            this.ContextMenuStrip = this.menuMain;
            this.ControlBox = false;
            this.Controls.Add(this.lblClockCount);
            this.Controls.Add(this.lblRemain);
            this.Controls.Add(this.picBackground);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClock";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ChDCTomatoClock";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmClock_FormClosing);
            this.Load += new System.EventHandler(this.FrmClock_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EMSecure_MouseDown);
            this.menuMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRemain;
        private System.Windows.Forms.Label lblClockCount;
        private System.Windows.Forms.ContextMenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem tsmPause;
        private System.Windows.Forms.ToolStripMenuItem tsmReset;
        private System.Windows.Forms.ToolStripMenuItem tsmSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmView;
        private System.Windows.Forms.ToolStripMenuItem tsmLittleView;
        private System.Windows.Forms.ToolStripMenuItem tsmMidleView;
        private System.Windows.Forms.ToolStripMenuItem tsmBigView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.ToolStripMenuItem tsmHideFlowWindow;
    }
}