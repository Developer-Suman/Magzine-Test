using Megazine.Infrastructure.IRepository;
using Megazine.Models;
using Microsoft.AspNetCore.Mvc;

namespace Megazine.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _IArticleService;
        public ArticleController(IArticleService demoarticleService) {
            _IArticleService = demoarticleService;
        }
        public IActionResult Index()
        {
            List<ArticleSecond> demoResult = _IArticleService.GetAll();
            return View(demoResult);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ArticleSecond demoArticle)
        {
            View(_IArticleService.Save(demoArticle));
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var A = _IArticleService.GetById(Id);
            return View(A);
        }

        [HttpPost]
        public IActionResult Update(ArticleSecond demoArticle)
        {
             View(_IArticleService.Update(demoArticle));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var A = _IArticleService.GetById(Id);
            return View(A);
        }

        public IActionResult Delete(ArticleSecond demoArticle)
        {
            _IArticleService.Delete(demoArticle);
            return RedirectToAction("Index");
        }
    }
}
