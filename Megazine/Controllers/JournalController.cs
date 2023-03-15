using Megazine.Infrastructure.IRepository;
using Megazine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Megazine.Controllers
{
    public class JournalController : Controller
    {
        private readonly IJournalService _IjournalService;
        public JournalController(IJournalService demojournalServices)
        {
            _IjournalService = demojournalServices;

        }

        [HttpGet]
        public IActionResult Index()
        
        {
            List<Journal> demoResult = _IjournalService.GetAll();
            return View(demoResult);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Journal demoJournal, IFormFile JournalImageFile)
        {
            demoJournal.JournalImageFile = JournalImageFile;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(Guid.NewGuid().ToString() + demoJournal.JournalImageFile.FileName);
            string fileName = Guid.NewGuid().ToString() + demoJournal.JournalImageFile.FileName;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                JournalImageFile.CopyTo(stream);
            }
            //demoNews.ImageUrl.IsSuccess = true;
            //model.Message = "File upload successfully";


            demoJournal.JournalImage = fileName;
            View(_IjournalService.Save(demoJournal));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var journal = _IjournalService.GetById(Id);
            return View(journal);
        }

        [HttpPost]
        public IActionResult Update(Journal demoJournal)
        {

            if (demoJournal.JournalImageFile != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                FileInfo fileInfo = new FileInfo(Guid.NewGuid().ToString() + demoJournal.JournalImageFile.FileName);
                string fileName = Guid.NewGuid().ToString() + demoJournal.JournalImageFile.FileName;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    demoJournal.JournalImageFile.CopyTo(stream);
                }
                demoJournal.JournalImage = fileName;
            }


            _IjournalService.Update(demoJournal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var A = _IjournalService.GetById(Id);
            return View(A);
        }

        public IActionResult Delete(Journal demoJournal)
        {
            _IjournalService.Delete(demoJournal);
            return RedirectToAction("Index");
        }
    }
}
