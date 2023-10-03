using Quartz;

namespace QuartzJobsScheduler.Jobs
{
    public class HealthCheckJob : IJob
    {
        private readonly HttpClient _httpClient;
        readonly IConfiguration _configuration;
        readonly string baseUrl;

        public HealthCheckJob(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            baseUrl = _configuration.GetValue<string>("BaseUrl");
        }


        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"This job executed at {DateTime.Now}");
            //var response = await _httpClient.GetAsync($"{baseUrl}HealthCheck");
            //Console.WriteLine(response.StatusCode);
            return default!;
        }
    }
}
