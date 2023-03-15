using Megazine.Infrastructure.IRepository;
using Megazine.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Megazine.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _INewsService;
        private readonly IWebHostEnvironment _environment;

        public NewsController(INewsService iNewsService, IWebHostEnvironment IwebHostEnvironment)
        {
            _INewsService = iNewsService;
            _environment = IwebHostEnvironment;
        }

        public IActionResult Edit()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<News> demoResult = _INewsService.GetAll();
            return View(demoResult);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(News demoNews, IFormFile ImageUrl)
        {

            demoNews.ImageUrl = ImageUrl;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(Guid.NewGuid().ToString() + demoNews.ImageUrl.FileName);
            string fileName = Guid.NewGuid().ToString() + demoNews.ImageUrl.FileName;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                ImageUrl.CopyTo(stream);
            }
            //demoNews.ImageUrl.IsSuccess = true;
            //model.Message = "File upload successfully";


            demoNews.ImageName = fileName;

            View(_INewsService.Save(demoNews));
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var N = _INewsService.GetById(Id);
            return View(N);
        }

        [HttpPost]
        public IActionResult Update(News demoNews)
        {
            //demoNews.ImageUrl = ImageUrl;

            if(demoNews.ImageUrl != null)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                FileInfo fileInfo = new FileInfo(Guid.NewGuid().ToString() + demoNews.ImageUrl.FileName);
                string fileName = Guid.NewGuid().ToString() + demoNews.ImageUrl.FileName;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    demoNews.ImageUrl.CopyTo(stream);
                }
                //demoNews.ImageUrl.IsSuccess = true;
                //model.Message = "File upload successfully";


                demoNews.ImageName = fileName;
            }
            _INewsService.Update(demoNews);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var A = _INewsService.GetById(Id);
            return View(A);
        }

        [HttpPost]
        public IActionResult Delete(News demoNews)
        {
            _INewsService.Delete(demoNews);
            return RedirectToAction("Index");
        }

        
    }
}
