using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EventAggrigator
{
    public class ClosedState : IState
    {
        public void HandleState()
        {
            Console.WriteLine("Door is closed.");
        }
    }

}
