using Hangfire.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.Controllers
{
    [ApiController]
    public class HangFireController : Controller
    {
        private readonly IHangFire _hangFire;
        public HangFireController(IHangFire hangFire)
        {
            _hangFire = hangFire;
        }

        [HttpGet("Orderplaced")]
        public IActionResult OrderPlaced()
        {
            var jobId = BackgroundJob.Enqueue(() => _hangFire.OrderPlacedEmail());
            return Ok($"JobId : {jobId} completed. order placed mail sent");
        }

        [HttpGet("OrderConfirmation")]
        [Obsolete]
        public IActionResult OrderConfirmation()
        {
            string cronExpression = "0 15 12 * * ?"; // 12:15 PM daily

            RecurringJob.AddOrUpdate(() => _hangFire.OrderPlacedEmail(), cronExpression);

            return Ok("Job scheduled. Order confirmation mail will be sent daily at 12:15 PM.");
        }

        [HttpGet("OrderTracking")]
        public IActionResult OrderTracking()
        {
            var jobId = BackgroundJob.Enqueue(() => _hangFire.OrderTracking());
            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine($"jobId {jobId},order Tracking mail is sent"));
            return Ok("Tracking mail Sent");
        }

    }
}
