using Microsoft.Extensions.Hosting;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MVC_Apps
{
    public class MoveImageBackgroundService : BackgroundService
    {
        IWebHostEnvironment hostEnvironment;
        public MoveImageBackgroundService(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\DotNet\NetEltp\MVC_Apps\wwwroot\Images\");
            var files = di.GetFiles("*.*");
            foreach (var file in files)
            {
                if (file.Extension == ".jpg")
                {
                    string dirPath = Path.Combine(hostEnvironment.WebRootPath, "Images\\JPG");
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    file.MoveTo(dirPath + "\\" + file.Name);
                }
                if (file.Extension == ".png")
                {
                    string dirPath = Path.Combine(hostEnvironment.WebRootPath, "Images\\PNG");
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    file.MoveTo(dirPath + "\\" + file.Name);
                }
                if (file.Extension == ".jpeg")
                {
                    string dirPath = Path.Combine(hostEnvironment.WebRootPath, "Images\\JPEG");
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    file.MoveTo(dirPath + "\\" + file.Name);
                }
            }

            return Task.CompletedTask;
        }
    }
}
