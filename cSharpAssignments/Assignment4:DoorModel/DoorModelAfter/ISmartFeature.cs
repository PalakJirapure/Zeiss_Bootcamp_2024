using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdatedDoorAssignment
{
    public interface ISmartFeatures
    {
        event Action BuzzerAlert;
        event Action PagerNotify;
    }

}
