using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TomatoClock
{
    public partial class FrmNotice : Form
    {
        private TomatoClock clock;
        public static string backgroundFile;

        public FrmNotice(TomatoClock clock)
        {
            InitializeComponent();
            this.clock = clock;

            Helper.setTransparent(panelMain, this);
            Helper.fullScreen(this);

            try
            {
                string bgFile = (backgroundFile != null && File.Exists(backgroundFile)) ? backgroundFile : "bg.jpg";
                this.BackgroundImage = Image.FromFile(bgFile);
            }
            catch { }
            
        }



        private void button1_Click(object sender, EventArgs e)
        {
            closeWindow();
        }

        private bool allowClose = false;
        private void closeWindow()
        {
            allowClose = true;
            this.Close();
        }


        private void FrmNotice_Load(object sender, EventArgs e)
        {
            
            // clock.ClockCountChanged += Clock_ClockCountChanged;
            clock.RemainSecondsChanged += Clock_RemainSecondsChanged;
            // clock.ResetTimer += Clock_ResetTimer;
            clock.TimeIsUp += Clock_TimeIsUp;
        }




        private void Clock_RemainSecondsChanged(object sender, TomatoClock.RemainSecondsChangedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                if (e.newValue < 60 && lblRemain.ForeColor != Color.Red)
                {
                    lblRemain.ForeColor = Color.Red;
                }
                int showValue = e.newValue >= 60 ? e.newValue / 60 : e.newValue;
                if (lblRemain.Text != showValue.ToString())
                    lblRemain.Text = showValue.ToString();
            }));
        }

        private void Clock_TimeIsUp(object sender, TomatoClock.TimeIsUpEventArgs e)
        {
            // clock.ClockCountChanged -= Clock_ClockCountChanged;
            clock.RemainSecondsChanged -= Clock_RemainSecondsChanged;
            // clock.ResetTimer -= Clock_ResetTimer;
            clock.TimeIsUp -= Clock_TimeIsUp;
            this.Invoke(new Action(closeWindow));
        }

        private void FrmNotice_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !allowClose;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.Opacity < 1)
                this.Opacity += 0.1;
            else
            {
                timerShowForm.Stop();
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

        private void timerShowNotifition_Tick(object sender, EventArgs e)
        {
            lblMessage.Hide();
            timerShowNotifition.Stop();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            closeWindow();
        }
    }
}
