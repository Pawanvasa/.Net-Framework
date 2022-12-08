using Microsoft.AspNetCore.Mvc;

namespace MVC_Apps.Controllers
{
    public class FileUploadController : Controller
    {
        IWebHostEnvironment hostEnvironment;

        public FileUploadController(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// IFromFile: Represents the File REceived from HttpRequest
        /// THis helps to read the file and Process it 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            try
            {
                // Check the File is received

                if (file == null)
                    throw new Exception("File is Not Received...");

                // Create the Directory if it is not exist
                string dirPath = Path.Combine(hostEnvironment.WebRootPath, "Images");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                // MAke sure that only Excel file is used 
                string dataFileName = Path.GetFileName(file.FileName);
               
                long fileSize = file.Length;

                string extension = Path.GetExtension(dataFileName);

                string[] allowedExtsnions = new string[] { ".png", ".jpeg",".bmp",".jpg" };

                if (!allowedExtsnions.Contains(extension) || (fileSize<1 || fileSize> 1000000))         
                {
                    ModelState.AddModelError("", "File or Invalid Please upload");
                    throw new Exception("Sorry! This file is not allowed.");
                }
                // Make a Copy of the Posted File from the Received HTTP Request
                string saveToPath = Path.Combine(dirPath, dataFileName);

                using (FileStream stream = new FileStream(saveToPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult FileCatelog()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\DotNet\NetEltp\MVC_Apps\wwwroot\Images\");
            //FileInfo[] files = di.GetFiles("*.*");
            List<string> imgPaths = new List<string>();
            DirectoryInfo[] dirs = di.GetDirectories();

            foreach (DirectoryInfo dirInfo in dirs)
            {
                Console.WriteLine(dirInfo.FullName);
                FileInfo[] fi = dirInfo.GetFiles("*.*");
                foreach (FileInfo fi2 in fi)
                {
                    string[] path = fi2.FullName.Split("\\wwwroot");
                    imgPaths.Add(path[1]);
                }
            }

            ViewBag.imgPaths = imgPaths;
            return View();
        }
    }
}
