using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Threading;


namespace EventAggrigator
{
    public class SmartDoor : Door
    {
        private readonly Timer _timer;
        private readonly TimerConfiguration _timerConfig;

        public SmartDoor(TimerConfiguration timerConfig)
        {
            _timerConfig = timerConfig;
            _state = new ClosedState();
            _timer = new Timer(CloseDoorCallback, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void ConfigureSmartFeatures(Action<Buzzer> configureBuzzer, Action<Pager> configurePager)
        {
            var buzzer = new Buzzer();
            configureBuzzer?.Invoke(buzzer);

            var pager = new Pager();
            configurePager?.Invoke(pager);

            EventAggregator.Instance.Subscribe<DoorClosedEvent>(ev => buzzer.Update());
            EventAggregator.Instance.Subscribe<DoorClosedEvent>(ev => pager.Update());
        }

        public override void Open()
        {
            _state = new OpenState();
            Console.WriteLine("Door is open.");

            // Reset the timer when the door is opened
            _timer.Change(_timerConfig.Interval, Timeout.Infinite);
        }

        public override void Close()
        {
            _state = new ClosedState();
            Console.WriteLine("Door is closed.");
            EventAggregator.Instance.Publish(new DoorClosedEvent());
        }

        private void CloseDoorCallback(object state)
        {
            Close();
        }
    }

}
