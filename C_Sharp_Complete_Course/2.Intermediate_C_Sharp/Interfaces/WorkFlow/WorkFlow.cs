using Interfaces.workflows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class WorkFlow 
    {
        public List<IActivity> list;
        public WorkFlow(IActivity activity)
        {
            list = new List<IActivity>();
        }
        public void addActivity(IActivity activity)
        {
            list.Add(activity);
        }
        public void removeActivity(IActivity activity)
        {
            list.Remove(activity);
        }
    }
}
