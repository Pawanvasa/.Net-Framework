using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.workflows
{
    public class VideoCloudStorage : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Uploading Video....");
        }
    }
}
