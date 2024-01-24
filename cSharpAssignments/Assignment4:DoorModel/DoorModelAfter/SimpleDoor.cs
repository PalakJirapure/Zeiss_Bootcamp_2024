using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdatedDoorAssignment
{
    public class SimpleDoor : IDoor
    {
        public event Action DoorClosed;

        public void Open()
        {
            Console.WriteLine("Simple door is open.");
        }

        public void Close()
        {
            Console.WriteLine("Simple door is closed.");
            OnDoorClosed();
        }

        protected virtual void OnDoorClosed()
        {
            DoorClosed?.Invoke();
        }
    }


}
