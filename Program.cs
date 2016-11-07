using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TomatoClock
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Properties.Settings s = Properties.Settings.Default;
            TomatoClock clock = new TomatoClock(s.TomatoTime, s.BreakTime, s.LongBreakTime, s.ClockCountToLongBreak);
            clock.start();
            
            // FrmClock.downloadBackGround(0, 10);
            // Application.Run(new FrmNotice(clock));
            Application.Run(new FrmClock(clock));
        }

    }
}
