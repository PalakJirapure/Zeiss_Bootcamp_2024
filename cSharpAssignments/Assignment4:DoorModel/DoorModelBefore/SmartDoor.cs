using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoorAssignment
{
   
    public class SmartDoor : SmartDoorDecorator, ISubject
    {
        private List<IObserver> observers;
        private readonly ILogger logger;

        public SmartDoor(IDoor door, ILogger logger) : base(door, logger)
        {
            this.logger = logger;
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

       
        public event PagerNotificationDelegate PagerNotificationEvent;

        public void SetPagerNotification(Action<string> pagerAction)
        {
            PagerNotificationEvent += new PagerNotificationDelegate(pagerAction);
        }

        private void NotifyPager(string message)
        {
            PagerNotificationEvent?.Invoke(message);
        }

        public new void SetTimer(int seconds)
        {
            logger.Log($"Setting timer for {seconds} seconds.");
            base.SetTimerLogic(() => AutoCloseCallback(), seconds * 1000);
        }

        public new void AutoClose(int seconds)
        {
            logger.Log($"Auto closing door in {seconds} seconds.");
            SetTimer(seconds); 
        }

        private void AutoCloseCallback()
        {
            logger.Log("Auto closing door due to timer expiration.");
            base.Close();
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
