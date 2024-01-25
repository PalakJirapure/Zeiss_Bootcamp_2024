using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggrigator
{
    public class DoorClosedEvent : Event
    {
        public DoorClosedEvent() : base("DoorClosedEvent")
        {
        }
    }

}
