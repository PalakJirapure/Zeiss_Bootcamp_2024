using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Threading;

namespace DoorAssignment
{
    
    public class SmartDoorDecorator : IDoor
    {
        private IDoor decoratedDoor;
        private Timer autoCloseTimer;

        public SmartDoorDecorator(IDoor door)
        {
            decoratedDoor = door;
        }

        public void Open()
        {
            decoratedDoor.Open();
        }

        public void Close()
        {
            decoratedDoor.Close();
            ResetAutoCloseTimer();
        }

        
        public void SetTimer(int seconds)
        {
            Console.WriteLine($"Timer set for {seconds} seconds.");
            SetTimerLogic(() => AutoCloseCallback(), seconds * 1000);
            AutoCloseCallback(); 
        }

        public void SetAlert(string alertType)
        {
            Console.WriteLine($"Alert set for {alertType}.");
            SetAlertLogic(() => Console.WriteLine("Alert triggered."));
        }

        private void AutoCloseCallback()
        {
            Console.WriteLine("Auto closing door due to timer expiration.");
            Close();
        }

        private void ResetAutoCloseTimer()
        {
            autoCloseTimer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

      
        private void SetTimerLogic(Action callback, int milliseconds)
        {
            autoCloseTimer = new Timer(_ => callback(), null, milliseconds, Timeout.Infinite);
        }

        private void SetAlertLogic(Action alertAction)
        {
            alertAction.Invoke();
        }
    }
}

