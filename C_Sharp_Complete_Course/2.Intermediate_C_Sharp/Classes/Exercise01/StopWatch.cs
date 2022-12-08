using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    public class StopWatch
    {
        public static DateTime startTime { get; set; }
        public static DateTime stopTime { get; set; }

        public void start()
        {
            startTime = DateTime.Now;
        }
        public void stop()
        {
            stopTime = DateTime.Now;
        }
        public void durationCalculation()
        {
            Console.WriteLine();
            Console.WriteLine("Durations is : " + (stopTime - startTime));
        }
    }

}
