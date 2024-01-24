using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggrigator
{
    public abstract class Door
    {
        protected IState _state;

        public abstract void Open();

        public abstract void Close();
    }

}
