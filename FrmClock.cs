using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TomatoClock
{
    public partial class FrmClock : Form
    {
        private TomatoClock clock;
        private ClockShowView showView;
        private Properties.Settings settings;

        public enum ClockShowView
        {
            Little,
            Middle,
            Big,
        }

        public FrmClock(TomatoClock clock)
        {
            InitializeComponent();
            this.clock = clock;
            AllowTransparency = true;
            TransparencyKey = BackColor;
            settings = Properties.Settings.Default;
            HideFlowWindow = settings.HideFlowWindow;
            HideNotifyIcon = settings.HideNotifyIcon;
        }

        public bool HideNotifyIcon
        {
            get
            {
                return !notifyIcon.Visible;
            }
            set
            {
                if (value == notifyIcon.Visible)
                {
                    notifyIcon.Visible = !value || !this.Visible;

                }
            }
        }

        public bool HideFlowWindow
        {
            get
            {
                return !this.Visible;
            }
            set
            {
                if (value == this.Visible)
                {
                    if (value)
                    {
                        // hide nofityIcon
                        if (!notifyIcon.Visible)
                            notifyIcon.Visible = true;
                    }
                    else
                    {
                        if(notifyIcon.Visible && settings.HideNotifyIcon)
                            notifyIcon.Visible = false;
                    }
                    this.Visible = !value;
                    settings.HideFlowWindow = value;
                    settings.Save();
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x00000080; // WS_EX_TOOLWINDOW
                return cp;
            }
        }

        private void FrmClock_Load(object sender, EventArgs e)
        {
            ShowView = (ClockShowView)Enum.Parse(typeof(ClockShowView), settings.ShowView);
            this.Left = settings.LocationX;
            this.Top = settings.LocationY;
            clock.ClockCountChanged += Clock_ClockCountChanged;
            clock.RemainSecondsChanged += Clock_RemainSecondsChanged;
            clock.ResetTimer += Clock_ResetTimer;
            clock.TimeIsUp += Clock_TimeIsUp;

            Helper.setTransparent(lblClockCount, picBackground);
            Helper.setTransparent(lblRemain, picBackground);
        }

        private ClockShowView ShowView
        {
            get { return showView; }
            set
            {
                showView = value;
                settings.ShowView = showView.ToString();
                settings.Save();

                int bgLeft = -21;
                switch (showView)
                {
                    case ClockShowView.Little:
                        
                        picBackground.Size = new Size(50, 23);
                        picBackground.Location = new Point(bgLeft, 0);
                        lblRemain.Font = new Font(lblRemain.Font.FontFamily, 12, lblRemain.Font.Style);
                        lblClockCount.Font = new Font(lblClockCount.Font.FontFamily, 10, lblClockCount.Font.Style);
                        break;
                    case ClockShowView.Middle:
                        picBackground.Size = new Size(50, 23);
                        picBackground.Location = new Point(0, 0);
                        lblRemain.Font = new Font(lblRemain.Font.FontFamily, 12, lblRemain.Font.Style);
                        lblClockCount.Font = new Font(lblClockCount.Font.FontFamily, 10, lblClockCount.Font.Style);
                        break;
                    case ClockShowView.Big:
                        picBackground.Size = new Size(60, 27);
                        picBackground.Location = new Point(0, 0);
                        lblRemain.Font = new Font(lblRemain.Font.FontFamily, 15, lblRemain.Font.Style);
                        lblClockCount.Font = new Font(lblClockCount.Font.FontFamily, 13, lblClockCount.Font.Style);
                        break;
                }
                this.Width = picBackground.Width + picBackground.Left;
                this.Height = picBackground.Height + picBackground.Top;
            }
        }

        private void Clock_TimeIsUp(object sender, TomatoClock.TimeIsUpEventArgs e)
        {
            if (e.tomatoTimeIsUp)
            {
                // show break notification
                this.Invoke(new Action(() => {
                    new FrmNotice(clock).Show();
                }));
                // MessageBox.Show("Break time");
            }
            else
            {
                // show back to work nofication
            }

        }

        private void Clock_ResetTimer(object sender, EventArgs e)
        {
            this.Invoke(new Action(()  =>
            {
                lblRemain.ForeColor = Color.Blue;
            }));
        }

        private void Clock_RemainSecondsChanged(object sender, TomatoClock.RemainSecondsChangedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                if (e.newValue < 60 && lblRemain.ForeColor != Color.Red)
                {
                    lblRemain.ForeColor = Color.Red;
                    new ChDCToolsNotice.FrmNotification(this.Icon.ToBitmap(), this.Text, "Only One Minute!").Show();
                    
                    // downloadBackground
                    new Action<int, int>(downloadBackGround).BeginInvoke(0, 10, null, null);
                }
                int showValue = e.newValue >= 60 ? e.newValue / 60 : e.newValue;
                if (lblRemain.Text != showValue.ToString())
                    lblRemain.Text = showValue.ToString();
                if (notifyIcon.Visible)
                    notifyIcon.Text = showValue.ToString();
            }));
        }

        public static void downloadBackGround(int start, int length)
        {
            try
            {
                BingWallpaper[] wallpapers = BingWallpaper.getBingWallpaperUrl(start, length);
                Random rand = new Random((int)DateTime.Now.Ticks);
                BingWallpaper wallpaper = wallpapers[rand.Next(0, wallpapers.Length)];
                string imgFile = Helper.HttpDownloadFile(wallpaper.Url, Path.GetTempFileName());
                FrmNotice.backgroundFile = imgFile;
            }
            catch //(Exception e)
            {

            }
        }
        private void Clock_ClockCountChanged(object sender, TomatoClock.ClockCountChangedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                lblClockCount.Text = e.newValue.ToString();
            }));
        }

        #region 拖动无标题窗

        //该函数从当前线程中窗口释放鼠标捕获  
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        //发送消息移动窗体  
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;    //向窗口发送消息  
        public const int SC_MOVE = 0xF010;          //向窗口发送移动的消息  
        public const int HTCAPTION = 0x0002;

        //鼠标位于窗体(底部位置)按下移动操作  
        private void EMSecure_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion

        private void menuMain_Opening(object sender, CancelEventArgs e)
        {
            tsmPause.Text = clock.Enable ? "暂停" : "开始";
            tsmHideFlowWindow.Text = this.Visible ? "隐藏悬浮窗" : "显示悬浮窗";
            switch(ShowView)
            {
                case ClockShowView.Little:
                    tsmLittleView.Checked = true;
                    tsmMidleView.Checked = false;
                    tsmBigView.Checked = false;
                    break;
                case ClockShowView.Middle:
                    tsmLittleView.Checked = false;
                    tsmMidleView.Checked = true;
                    tsmBigView.Checked = false;
                    break;
                case ClockShowView.Big:
                    tsmLittleView.Checked = false;
                    tsmMidleView.Checked = false;
                    tsmBigView.Checked = true;
                    break;
            }
        }

        private void tsmPause_Click(object sender, EventArgs e)
        {
            if (clock.Enable && canPause())
                clock.pause();
            else if(!clock.Enable)
                clock.resume();
        }

        private void tsmReset_Click(object sender, EventArgs e)
        {
            if(canPause())
                clock.start();
        }

        /// <summary>
        /// 是否可以退出或暂停
        /// </summary>
        /// <returns></returns>
        private bool canPause()
        {
            if (clock.IsInTomatoTime && clock.RemainSeconds < 60 || !clock.IsInTomatoTime)
                return false;
            else
                return true;
        }

        private void tsmQuit_Click(object sender, EventArgs e)
        {
            if(canPause())
                Application.Exit();
        }

        private void tsmSettings_Click(object sender, EventArgs e)
        {
            if(canPause())
                new FrmSettings(clock, this).Show();
        }

        private void FrmClock_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.LocationX = this.Left;
            settings.LocationY = this.Top;
            settings.Save();
        }

        private void tsmLittleView_Click(object sender, EventArgs e)
        {
            ShowView = ClockShowView.Little;
        }

        private void tsmMidleView_Click(object sender, EventArgs e)
        {
            ShowView = ClockShowView.Middle;
        }

        private void tsmBigView_Click(object sender, EventArgs e)
        {
            ShowView = ClockShowView.Big;
        }

        private void tsmHideFlowWindow_Click(object sender, EventArgs e)
        {
            HideFlowWindow = !HideFlowWindow;
        }
    }
}
