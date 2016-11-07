using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace TomatoClock
{

    public class TomatoClock
    {
        public class ClockCountChangedEventArgs : EventArgs
        {
            public readonly int oldValue;
            public readonly int newValue;

            public ClockCountChangedEventArgs(int oldValue, int newValue)
            {
                this.oldValue = oldValue;
                this.newValue = newValue;
            }
        }

        public class RemainSecondsChangedEventArgs : EventArgs
        {
            public readonly int oldValue;
            public readonly int newValue;

            public RemainSecondsChangedEventArgs(int oldValue, int newValue)
            {
                this.oldValue = oldValue;
                this.newValue = newValue;
            }
        }
        public class TimeIsUpEventArgs : EventArgs
        {
            public readonly bool tomatoTimeIsUp;

            public TimeIsUpEventArgs(bool tomatoTimeIsUp)
            {
                this.tomatoTimeIsUp = tomatoTimeIsUp;
            }
        }

        /// <summary>
        /// 积攒的番茄数目修改事件
        /// </summary>
        public event EventHandler<ClockCountChangedEventArgs> ClockCountChanged;
        public event EventHandler<RemainSecondsChangedEventArgs> RemainSecondsChanged;
        public event EventHandler ResetTimer;
        public event EventHandler<TimeIsUpEventArgs> TimeIsUp;

        #region Attributes
        protected int tomatoTime = 1; // mins
        protected int breakTime = 1; // mins
        protected int longBreakTime = 1; // mins
        protected int clockCountToLongBreak = 2;

        protected int clockCount;
        protected int remainSeconds; // 剩余秒数
        protected bool isInTomatoTime;
        protected Timer timer;
        /// <summary>
        /// 当前积攒的番茄数目
        /// </summary>
        public int ClockCount
        {
            get { return clockCount; }
            protected set
            {
                int oldValue = clockCount;
                clockCount = value;
                if (ClockCountChanged != null)
                    ClockCountChanged(this, new ClockCountChangedEventArgs(oldValue, value));
            }
        }
        /// <summary>
        /// 当前剩余的秒数
        /// </summary>
        public int RemainSeconds
        {
            get { return remainSeconds; }
            protected set
            {
                int oldValue = remainSeconds;
                remainSeconds = value;
                if (RemainSecondsChanged != null)
                    RemainSecondsChanged(this, new RemainSecondsChangedEventArgs(oldValue, value));
            }
        }
        /// <summary>
        /// 番茄时间是否在工作
        /// </summary>
        public bool Enable
        {
            get { return timer.Enabled; }
        }
        /// <summary>
        /// 工作时间（番茄时间）
        /// </summary>
        public int TomatoTime
        {
            get
            {
                return tomatoTime;
            }

            set
            {
                tomatoTime = value;
            }
        }
        /// <summary>
        /// 短休息时间
        /// </summary>
        public int BreakTime
        {
            get
            {
                return breakTime;
            }

            set
            {
                breakTime = value;
            }
        }
        /// <summary>
        /// 长休息时间
        /// </summary>
        public int LongBreakTime
        {
            get
            {
                return longBreakTime;
            }

            set
            {
                longBreakTime = value;
            }
        }
        /// <summary>
        /// 达到长休息所积攒的番茄数目
        /// </summary>
        public int ClockCountToLongBreak
        {
            get
            {
                return clockCountToLongBreak;
            }

            set
            {
                clockCountToLongBreak = value;
            }
        }

        /// <summary>
        /// 判断是否在工作时间（番茄时间）中
        /// </summary>
        public bool IsInTomatoTime
        {
            get
            {
                return isInTomatoTime;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tomatoTime">工作时间</param>
        /// <param name="breakTime">短休息时间</param>
        /// <param name="longBreakTime">长休息时间</param>
        /// <param name="clockCountToLongBreak">达到长休息时间所积攒的番茄数目</param>
        public TomatoClock(int tomatoTime, int breakTime, int longBreakTime, int clockCountToLongBreak)
        {
            this.tomatoTime = tomatoTime;
            this.breakTime = breakTime;
            this.longBreakTime = longBreakTime;
            this.clockCountToLongBreak = clockCountToLongBreak;

            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
        }

        protected void resetTimer()
        {
            if (isInTomatoTime)
            {
                if (clockCount >= clockCountToLongBreak)
                {
                    remainSeconds = longBreakTime * 60;
                    ClockCount = 0;
                }
                else
                    remainSeconds = breakTime * 60;
            }
            else
            {
                remainSeconds = tomatoTime * 60;
            }
            isInTomatoTime = !isInTomatoTime;
            if (ResetTimer != null)
                ResetTimer(this, new EventArgs());
        }

        /// <summary>
        /// 开始
        /// </summary>
        public void start()
        {
            isInTomatoTime = false;
            ClockCount = 0;
            resetTimer();
            timer.Start();
        }

        protected void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (RemainSeconds > 0)
            {
                // set the font color red when it remains 2 minutes
                RemainSeconds -= 1;
            }
            else
            {
                // time is up
                bool oldIsInTomatoTime = isInTomatoTime;
                if (isInTomatoTime)
                    ClockCount += 1;
                resetTimer();
                if (TimeIsUp != null)
                    TimeIsUp(this, new TimeIsUpEventArgs(oldIsInTomatoTime));
            }
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void pause()
        {
            timer.Stop();
        }
        /// <summary>
        /// 恢复
        /// </summary>
        public void resume()
        {
            timer.Start();
        }
    }
}
