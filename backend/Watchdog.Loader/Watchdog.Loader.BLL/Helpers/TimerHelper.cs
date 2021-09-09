using System;
using System.Timers;

namespace Watchdog.Loader.BLL.Helpers
{
    public sealed class TimerHelper : IDisposable
    {
        private readonly Timer _timer;
        private readonly int _times;
        private int _counter;

        public bool Finished { get; private set; }

        public event ElapsedEventHandler Elapsed;

        public TimerHelper(double delay, TimeSpan duration)
        {
            _timer = new Timer(delay);
            _timer.Elapsed += TimerElapsed;
            _times = (int) Math.Round(duration.TotalMilliseconds / delay);
            _counter = 0;
        }

        public void Start() => _timer.Start();

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_times > _counter++)
            {
                Elapsed?.Invoke(this, e);
            }
            else
            {
                _timer.Stop();
                _timer.Dispose();
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
