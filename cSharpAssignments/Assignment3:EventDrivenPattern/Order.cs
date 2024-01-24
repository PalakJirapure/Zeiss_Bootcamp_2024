using System;

namespace EventDrivenProgramming
{
    public enum OrderState
    {
        Accepted,
        Verified,
        Confirm,
        Processing,
        Completed,
        Rejected
    }

    public class Order
    {
        private Action<int, OrderState> Changed;
        private int orderId;
        private OrderState state;

        public Order()
        {
            orderId = new Random().Next(1000, 9999); // Generate a random order ID
            state = OrderState.Accepted; // Initial state
        }

        public event Action<int, OrderState> changed;

        /*public void AddChanged(Action<int, OrderState> observer)
        {
            Changed += observer;
        }

        public void RemoveChanged(Action<int, OrderState> observer)
        {
            Changed -= observer;
        }*/

        public int OrderId
        {
            get { return orderId; }
        }

        public OrderState State
        {
            get { return state; }
        }

        public void ChangeState(OrderState newState)
        {
            state = newState;

            changed?.Invoke(orderId, state);
        }
    }
}
