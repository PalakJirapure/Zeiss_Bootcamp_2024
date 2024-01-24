using System;
using System.Collections.Generic;

namespace EventDrivenProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            EmailNotifyManager emailNotifyManager = new EmailNotifyManager();
            SmsNotifyManager smsNotifyManager = new SmsNotifyManager();

            Action<int, OrderState> emailObserver = new Action<int, OrderState>(emailNotifyManager.Update);
            Action<int, OrderState> smsObserver = new Action<int, OrderState>(smsNotifyManager.Update);

            order.changed+=emailObserver;
            order.changed+=smsObserver;

            Dictionary<int, OrderState> stateMapping = new Dictionary<int, OrderState>
            {
                { 0, OrderState.Accepted },
                { 1, OrderState.Verified },
                { 2, OrderState.Confirm },
                { 3, OrderState.Processing },
                { 4, OrderState.Completed },
                { 5, OrderState.Rejected }
            };

            while (true)
            {
                int randomNumber = new Random().Next(0, 9); 

                OrderState newState = stateMapping[randomNumber];

                order.ChangeState(newState);

                Console.WriteLine($"Order ID: {order.OrderId}, Current State: {order.State}");
            }
        }
    }
}
