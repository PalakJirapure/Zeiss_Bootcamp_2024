using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoorAssignment
{
    
    public class DoorObserver : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"Door status: {message}");
        }
    }
}



