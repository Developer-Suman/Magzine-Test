using Megazine.Data;
using Megazine.Infrastructure.IRepository;
using Megazine.Models;

namespace Megazine.Infrastructure.Repository
{
    public class ArticleService : IArticleService
    {
        public AppDbContext _context { get; set; }
        public ArticleService(AppDbContext demoArticle)
        {
            _context = demoArticle;

        }
        public List<ArticleSecond> GetAll()
        {
            return _context.Articles.ToList();
        }

        public List<ArticleSecond> GetByName(string demoname)
        {
            var linq = from articles in _context.Articles select articles;
            return linq.ToList();

        }
        public ArticleSecond GetById(int id)
        {
            var Article = _context.Articles.Find(id);
            return Article;
        }

        public ArticleSecond Save(ArticleSecond demoarticle)
        {
            _context.Articles.Add(demoarticle);
            _context.SaveChanges();
            return demoarticle;

        }

        public ArticleSecond Update(ArticleSecond demoarticle)
        {
            ArticleSecond ArticleFromDb = _context.Articles.First(x => x.Id == demoarticle.Id);
            _context.Entry(ArticleFromDb).CurrentValues.SetValues(demoarticle);
            _context.SaveChanges();
            return demoarticle;
        }

        public void Delete(ArticleSecond demoarticle)
        {
            _context.Entry(demoarticle).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }



    }
}
