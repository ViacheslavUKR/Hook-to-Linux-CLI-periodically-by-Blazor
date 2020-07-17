using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace SshHook1.Services
{
    public class TimerTick
    {
        private Timer _timer;

        public void SetTimer(double interval)
        {
            _timer = new Timer(interval);
            _timer.Elapsed += NotifyTimerElapsed;
            _timer.Enabled = true;
        }

        public event Action OnElapsed;

        private void NotifyTimerElapsed(Object source, ElapsedEventArgs e)
        {
            OnElapsed?.Invoke();
            _timer.Dispose();
        }

        //When the page is loaded, the IDisposable always invoke even the page is not closed
        public void StopTimer()
        {
            _timer?.Stop();
            _timer?.Dispose();
        }
    }
}
