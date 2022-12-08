using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public  class WorkFlowEngine
    {
        public void run(WorkFlow wl )
        {
            foreach(var i in wl.list)
            {
                i.Execute();
            }
        }
    }
}
