namespace TomatoClock
{
    partial class FrmNotice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotice));
            this.lblMessage = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblRemain = new System.Windows.Forms.Label();
            this.timerShowForm = new System.Windows.Forms.Timer(this.components);
            this.timerShowNotifition = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMessage.Location = new System.Drawing.Point(3, 42);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(222, 27);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Time to break!";
            // 
            // panelMain
            // 
            this.panelMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMain.Controls.Add(this.lblRemain);
            this.panelMain.Controls.Add(this.lblMessage);
            this.panelMain.Location = new System.Drawing.Point(216, 129);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(200, 100);
            this.panelMain.TabIndex = 3;
            // 
            // lblRemain
            // 
            this.lblRemain.AutoSize = true;
            this.lblRemain.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblRemain.Location = new System.Drawing.Point(81, 69);
            this.lblRemain.Name = "lblRemain";
            this.lblRemain.Size = new System.Drawing.Size(31, 20);
            this.lblRemain.TabIndex = 4;
            this.lblRemain.Text = "25";
            // 
            // timerShowForm
            // 
            this.timerShowForm.Enabled = true;
            this.timerShowForm.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerShowNotifition
            // 
            this.timerShowNotifition.Enabled = true;
            this.timerShowNotifition.Interval = 3000;
            this.timerShowNotifition.Tick += new System.EventHandler(this.timerShowNotifition_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Quit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FrmNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNotice";
            this.Opacity = 0.1D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmNotice";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNotice_FormClosing);
            this.Load += new System.EventHandler(this.FrmNotice_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblRemain;
        private System.Windows.Forms.Timer timerShowForm;
        private System.Windows.Forms.Timer timerShowNotifition;
        private System.Windows.Forms.Button button1;
    }
}