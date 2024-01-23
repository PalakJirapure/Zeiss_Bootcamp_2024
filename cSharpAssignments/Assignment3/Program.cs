using System;

namespace EventDrivenProgramming
{
    internal class Program
    {
        public class Order
        {
            // Enum declaration
            public enum OrderState
            {
                Accepted,
                Verified,
                Confirm,
                Processing,
                Completed,
                Rejected
            }

            // Properties
            public int OrderId { get; set; }
            public OrderState State { get; set; }

            // Method to update the order state
            public void ChangeState(OrderState newState)
            {
                State = newState;
            }
        }

        static void Main(string[] args)
        {
            
            Order myOrder = new Order
            {
                OrderId = 1,
                State = Order.OrderState.Accepted
            };

            
            Random random = new Random();

            
            while (true)
            {
                
                int randomNumber = random.Next(9); 

                
                switch (randomNumber)
                {
                    case 0:
                        myOrder.ChangeState(Order.OrderState.Accepted);
                        break;
                    case 1:
                        myOrder.ChangeState(Order.OrderState.Verified);
                        break;
                    case 2:
                        myOrder.ChangeState(Order.OrderState.Confirm);
                        break;
                    case 3:
                        myOrder.ChangeState(Order.OrderState.Processing);
                        break;
                    case 4:
                        myOrder.ChangeState(Order.OrderState.Completed);
                        break;
                    case 5:
                        myOrder.ChangeState(Order.OrderState.Rejected);
                        break;
                }

                
                Console.WriteLine($"Order ID: {myOrder.OrderId}, Current State: {myOrder.State}");

                
            }
        }
    }
}
