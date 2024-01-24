using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdatedDoorAssignment
{
    public interface IDoor
    {
        event Action DoorClosed;
        void Open();
        void Close();
    }

}
