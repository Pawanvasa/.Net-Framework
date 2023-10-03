namespace Hangfire.Services
{
    public class HangFire : IHangFire
    {
        public void OrderPlacedEmail()
        {
            throw new Exception("Order Did not placed..");
            //Console.WriteLine("Order Placed Email has sent..");
        }
        public void OderConfirmationEmail()
        {
            Console.WriteLine("Order Confirmation Email has sent..");
        }
        public void OrderTracking()
        {
            Console.WriteLine("Order Tracking Email has sent..");
        }
    }
}
