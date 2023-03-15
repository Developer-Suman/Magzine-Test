using Megazine.Infrastructure.IRepository;
using Megazine.Models;
using Microsoft.AspNetCore.Mvc;

namespace Megazine.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementService _IAdvertisementService;

        public AdvertisementController( IAdvertisementService IAdService)
        {
            _IAdvertisementService = IAdService;

        }

        public IActionResult Index()
        {
            List<Advertisement> demoResult = _IAdvertisementService.GetAll();
            return View(demoResult);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Advertisement advertisement, IFormFile advertiseImageFile)
        {
            advertisement.advertiseImageFile = advertiseImageFile;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(Guid.NewGuid().ToString()+"_"+advertisement.advertiseImageFile.FileName);
            string fileName = Guid.NewGuid().ToString() + "_" + advertisement.advertiseImageFile.FileName;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                advertiseImageFile.CopyTo(stream);
            }

            advertisement.advertiseImage = fileName;


            View(_IAdvertisementService.Save(advertisement));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var Ad = _IAdvertisementService.GetById(Id);
            return View(Ad);
        }

        [HttpPost]
        public IActionResult Update(Advertisement demoAdvertisement)
        {

            if(demoAdvertisement.advertiseImageFile != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                FileInfo fileInfo = new FileInfo(Guid.NewGuid().ToString() + "_" + demoAdvertisement.advertiseImageFile.FileName);
                string fileName = Guid.NewGuid().ToString() + "_" + demoAdvertisement.advertiseImageFile.FileName;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    demoAdvertisement.advertiseImageFile.CopyTo(stream);
                }
                //demoNews.ImageUrl.IsSuccess = true;
                //model.Message = "File upload successfully";


                demoAdvertisement.advertiseImage = fileName;
            }
            
            _IAdvertisementService.Update(demoAdvertisement);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var D = _IAdvertisementService.GetById(Id);
            return View(D);
        }

        public IActionResult Delete(Advertisement demoAdvertisement)
        {
            _IAdvertisementService.Delete(demoAdvertisement);
            return RedirectToAction("Index");
        }

       
    }
}
