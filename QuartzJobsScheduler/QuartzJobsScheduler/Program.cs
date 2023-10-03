using Quartz;
using Quartz.Impl;
using QuartzJobsScheduler.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Create a new scheduler instance
ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
IScheduler scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

// Define the job and tie it to our HelloJob class
IJobDetail job = JobBuilder.Create<HealthCheckJob>()
    .WithIdentity("job1", "group1")
    .Build();

// Trigger the job to run every 10 seconds
ITrigger trigger = TriggerBuilder.Create()
    .WithIdentity("trigger1", "group1")
    .StartNow()
    .WithSimpleSchedule(x => x
        .WithIntervalInSeconds(10)
        .RepeatForever())
    .Build();

// Schedule the job with the trigger
scheduler.ScheduleJob(job, trigger).GetAwaiter().GetResult();

// Start the scheduler
scheduler.Start().GetAwaiter().GetResult();

// Shut down the scheduler
//scheduler.Shutdown().GetAwaiter().GetResult();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
