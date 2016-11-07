using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ChDCToolsNotice
{
    public partial class FrmNotification : Form
    {

        public FrmNotification(Image icon, string title, string msg)
        {
            InitializeComponent();
            picIcon.Image = icon;
            lblTitle.Text = this.Text = title;
            lblMsg.Text = msg;
            this.Left = Screen.PrimaryScreen.Bounds.Right - this.Width - 10;
            this.Top = Screen.PrimaryScreen.Bounds.Height / 10;
            // this.ClientSize = new Size(labMsg.Width + 16, labMsg.Height + 16);
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

        private void FrmNotification_Load(object sender, EventArgs e)
        {
            timerShow.Start();
        }

        private void timerShow_Tick(object sender, EventArgs e)
        {
            Opacity += .1;
            if (Opacity == 1)
            {
                timerShow.Stop();
                timerHode.Start();
            }
        }

        int hode = 0;
        Boolean focusOn = false;
        private void timerHode_Tick(object sender, EventArgs e)
        {
            if(!focusOn)
                hode++;
            if (hode >= 30)
            {
                timerHode.Stop();
                timerHide.Start();
            }
        }
        private void timerHide_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (Opacity == 0)
            {
                timerHide.Stop();
                this.Close();
            }
        }

        private void FrmNotification_MouseEnter(object sender, EventArgs e)
        {
            focusOn = true;
        }

        private void FrmNotification_MouseLeave(object sender, EventArgs e)
        {
            focusOn = false;
        }

    }
}
