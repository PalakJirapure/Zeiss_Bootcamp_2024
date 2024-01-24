using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdatedDoorAssignment
{
    public class SmartFeatures
    {
        public void ConfigureFeatures(SmartDoor smartDoor)
        {
            smartDoor.BuzzerAlert += () => Console.WriteLine("Buzzer alerted.");
            smartDoor.PagerNotify += () => Console.WriteLine("Pager notified.");
        }
    }


}
