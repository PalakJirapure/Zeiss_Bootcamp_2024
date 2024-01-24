using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace UpdatedDoorAssignment
{
    public class SmartDoor : SimpleDoor, ISmartFeatures
    {
        private readonly System.Timers.Timer _timer;
        public event Action BuzzerAlert;
        public event Action PagerNotify;

        public SmartDoor()
        {
            _timer = new System.Timers.Timer(20000);
            _timer.Elapsed += OnTimerElapsed;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Timer elapsed. Alerting by buzzer, notifying by pager, and automatically closing the door.");
            BuzzerAlert?.Invoke();
            PagerNotify?.Invoke();
            Close();
            _timer.Stop();
        }

        public void OpenWithTimer()
        {
            Open();
            _timer.Start();
        }
    }


}
