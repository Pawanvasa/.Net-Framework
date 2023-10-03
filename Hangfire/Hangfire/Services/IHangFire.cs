namespace Hangfire.Services
{
    public interface IHangFire
    {
        void OrderPlacedEmail();
        void OderConfirmationEmail();
        void OrderTracking();
    }
}
