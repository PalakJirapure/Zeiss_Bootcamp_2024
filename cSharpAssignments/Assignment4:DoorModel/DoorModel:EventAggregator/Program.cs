using System;
using System.Threading;

namespace EventAggrigator
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main()
        {
            TimerConfiguration timerConfig = new TimerConfiguration { Interval = 2000 };
            SmartDoor smartDoor = new SmartDoor(timerConfig);
            smartDoor.Open();
            smartDoor.ConfigureSmartFeatures(
                buzzer => { /* Configure Buzzer as needed */ },
                pager => { /* Configure Pager as needed */ }
            );

            // Simulate waiting for user input or other actions
            Thread.Sleep(3000);

            smartDoor.Close();
        }
    }


}
