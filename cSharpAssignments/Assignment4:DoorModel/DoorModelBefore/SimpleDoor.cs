using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorAssignment
{
    
    public class SimpleDoor : IDoor
    {
        private DoorState state;
        private readonly ILogger logger;

        public SimpleDoor(ILogger logger)
        {
            this.logger = logger;
            state = DoorState.Closed;
        }

        public void Open()
        {
            logger.Log("Simple door is now open.");
            state = DoorState.Open;
        }

        public void Close()
        {
            logger.Log("Simple door is now closed.");
            state = DoorState.Closed;
        }
    }
}

