using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.workflows
{
    public class VideoStatus : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Video Recording status : Processing");
        }
    }
}
