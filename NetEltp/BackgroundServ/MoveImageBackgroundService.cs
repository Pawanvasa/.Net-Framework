using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Xml.Serialization;

namespace BackgroundServ
{
    public class MoveImageBackgroundService : BackgroundService
    {
        /*IWebHostEnvironment hostEnvironment;
        public MoveImageBackgroundService(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }*/
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DirectoryInfo di = new DirectoryInfo(@"C:\DotNet\NetEltp\MVC_Apps\wwwroot\Images\");
                var files = di.GetFiles("*.*");
                foreach (var file in files)
                {
                    if (file.Extension == ".jpg")
                    {
                        string dirPath = Path.Combine("C:\\DotNet\\NetEltp\\MVC_Apps\\wwwroot\\","Images\\JPG");
                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }

                        file.MoveTo(dirPath + "\\" + file.Name);
                    }
                    if (file.Extension == ".png")
                    {
                        string dirPath = Path.Combine("C:\\DotNet\\NetEltp\\MVC_Apps\\wwwroot\\", "Images\\PNG");
                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }

                        file.MoveTo(dirPath + "\\" + file.Name);
                    }
                    if (file.Extension == ".jpeg")
                    {
                        string dirPath = Path.Combine("C:\\DotNet\\NetEltp\\MVC_Apps\\wwwroot\\", "Images\\JPEG");
                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }

                        file.MoveTo(dirPath + "\\" + file.Name);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}

