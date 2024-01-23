using System;

namespace EventDrivenProgramming
{
    internal class SmsNotifyManager
    {
        public void Update(int ID, OrderState state)
        {
            Console.WriteLine($"SMS Notification - Order ID:{ID}, New State: {state}");
        }
    }
}
