using System;
using System.Collections.Generic;

namespace DoorAssignment
{
    // Observer pattern: ConcreteSubject class
    public class SmartDoor : SmartDoorDecorator, ISubject
    {
        private List<IObserver> observers;
        public event PagerNotificationDelegate PagerNotificationEvent; // Event for pager notification

        public SmartDoor(IDoor door) : base(door)
        {
            observers = new List<IObserver>();
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }

        // Additional feature: Pager notification using delegate and event
        public void SetPagerNotification(Action<string> pagerAction)
        {
            PagerNotificationEvent += new PagerNotificationDelegate(pagerAction);
        }

        private void NotifyPager(string message)
        {
            PagerNotificationEvent?.Invoke(message);
        }

        public new void AutoClose(int seconds)
        {
            Console.WriteLine($"Auto closing door in {seconds} seconds.");
            SetTimerLogic(() => AutoCloseCallback(), seconds * 1000);
            AutoCloseCallback(); 
        }

        private new void Open()
        {
            base.Open();
            NotifyObservers("Door is now open.");
            NotifyPager("Door is now open. Pager notification sent.");
        }

        private new void Close()
        {
            base.Close();
            NotifyObservers("Door is now closed.");
            NotifyPager("Door is now closed. Pager notification sent.");
        }
    }
}
