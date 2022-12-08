using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample
{
    public class VideoEncoder
    {

        public delegate void VideoEcodedEventHandler(Object source, EventArgs eventArgs);
        public event VideoEcodedEventHandler ?VideoEcoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Video Encoding...");
            Thread.Sleep(3000);
            OnVideoEncode();
        }
        protected virtual void OnVideoEncode()
        {
            if (VideoEcoded != null)
                VideoEcoded(this,EventArgs.Empty);
        }
    }
}
