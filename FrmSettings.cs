using System;
using System.Windows.Forms;

namespace TomatoClock
{
    public partial class FrmSettings : Form
    {
        private Properties.Settings settings;
        private TomatoClock clock;
        private FrmClock frmClock;
        public FrmSettings(TomatoClock clock, FrmClock frmClock)
        {
            InitializeComponent();
            this.clock = clock;
            this.frmClock = frmClock;
            settings = Properties.Settings.Default;
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            clock.pause();
            loadSetttings();
        }

        private void loadSetttings()
        {
            numBreakTime.Value = settings.BreakTime;
            numTomatoTime.Value = settings.TomatoTime;
            numLongBreakTime.Value = settings.LongBreakTime;
            numClockCountToLongBreakTime.Value = settings.ClockCountToLongBreak;
            chkHideNotifyIcon.Checked = settings.HideNotifyIcon;
        }

        public void saveSettings()
        {
            settings.BreakTime = Decimal.ToInt32(numBreakTime.Value);
            settings.TomatoTime = Decimal.ToInt32(numTomatoTime.Value);
            settings.LongBreakTime = Decimal.ToInt32(numLongBreakTime.Value);
            settings.ClockCountToLongBreak = Decimal.ToInt32(numClockCountToLongBreakTime.Value);
            settings.HideNotifyIcon = chkHideNotifyIcon.Checked;
            settings.Save();
        }

        public void applySettings()
        {
            clock.BreakTime = Decimal.ToInt32(numBreakTime.Value);
            clock.TomatoTime = Decimal.ToInt32(numTomatoTime.Value);
            clock.LongBreakTime = Decimal.ToInt32(numLongBreakTime.Value);
            clock.ClockCountToLongBreak = Decimal.ToInt32(numClockCountToLongBreakTime.Value);
            frmClock.HideNotifyIcon = chkHideNotifyIcon.Checked;
            clock.start();
        }

        private void FrmSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            clock.resume();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveSettings();
            applySettings();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
