using System;
using System.Timers;

namespace LoadBalancer.Heartbeat
{
    public interface IScheduler
    {
        event EventHandler<ElapsedEventArgs> Elapsed;
        void Start();
    }

    public class Scheduler : IScheduler
    {
        public event EventHandler<ElapsedEventArgs> Elapsed;
        private Timer timer;
        private readonly double interval;

        public Scheduler(double interval)
        {
            this.interval = interval;
        }

        public void Start()
        {
            timer = new Timer();
            timer.Interval = interval;
            timer.Elapsed += new ElapsedEventHandler(Elapsed);
            timer.Start();
        }
    }
}