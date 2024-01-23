using System;

namespace EventDrivenProgramming
{
    internal class EmailNotifyManager
    {
        public void Update(int OrderID, OrderState state)
        {
            Console.WriteLine($"Email Notification - Order ID:{OrderID}, New State: {state}");
        }
    }
}
