using Megazine.Infrastructure.IRepository;
using Megazine.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace Megazine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsService _newsService;
        private readonly IJournalService _journalService;
        private readonly IAdvertisementService _advertisementService;
        private readonly IArticleService _articleService;

        public HomeController(ILogger<HomeController> logger,INewsService newsService, IJournalService journalService, IArticleService articleService, IAdvertisementService advertisementService)
        {
            _logger = logger;
            _newsService = newsService;
            _journalService = journalService;
            _advertisementService = advertisementService;
            _articleService = articleService;
        }

        public IActionResult Index()
        
        {

            dynamic mymodel = new ExpandoObject();
            mymodel.Articles = _articleService.GetAll().Take(3).OrderByDescending(c => c.CreatedAt);
            mymodel.Newss = _newsService.GetAll().OrderByDescending(c => c.CreatedDate);
            mymodel.Advertisements = _advertisementService.GetAll().OrderByDescending(c => c.CreatedDate);
            mymodel.ExposeAdvertsementLimited = _advertisementService.GetAll().Take(1).OrderByDescending(c => c.CreatedDate);

            //if (_advertisementService.CreatedDate -= TimeSpan.FromHours(29))
            //{

            //}
            mymodel.Journals = _journalService.GetAll();
            mymodel.recentJournal = _journalService.GetAll().Take(1).OrderByDescending(c => c.CreatedDate);
            mymodel.recent_Journalhalf = _journalService.GetAll().Take(2);
            mymodel.NewssLimit = _newsService.GetAll().Take(4).OrderByDescending(c => c.CreatedDate);



            return View(mymodel);
        }

      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}