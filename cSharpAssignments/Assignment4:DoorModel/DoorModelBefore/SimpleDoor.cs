using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace DoorAssignment
{
    public class SimpleDoor : IDoor
    {
        private DoorState state;

        public SimpleDoor()
        {
            state = DoorState.Closed;
        }

        public void Open()
        {
            Console.WriteLine("Simple door is now open.");
            state = DoorState.Open;
        }

        public void Close()
        {
            Console.WriteLine("Simple door is now closed.");
            state = DoorState.Closed;
        }
    }
}


