using Megazine.Data;
using Megazine.Infrastructure.IRepository;
using Megazine.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Megazine.Infrastructure.Repository
{
    public class NewsService : INewsService
    {
        public AppDbContext _context { get; set; }
        public NewsService(AppDbContext demoNews)
        {
            _context = demoNews;
        }

        public List<News> GetAll()
        {
            return _context.Newss.ToList();
        }

        public List<News> GetByName(string Newsname)
        {
            var linq = from news in _context.Newss select news;
            return linq.ToList();

        }

        public News GetById(int Id)
        {
            var News = _context.Newss.Find(Id);
            return News;
        }

        public News Save(News demonews)
        {
            _context.Newss.Add(demonews);
            _context.SaveChanges();
            return demonews;

        }

        public News Update(News demoNews)
        {
            News NewsFromDb = _context.Newss.First(x => x.Id == demoNews.Id);
            NewsFromDb.Title = demoNews.Title;
            NewsFromDb.Description = demoNews.Description;
            NewsFromDb.CreatedDate = demoNews.CreatedDate;
            NewsFromDb.Category = demoNews.Category;

            if (demoNews.ImageUrl != null)
            {
                NewsFromDb.ImageUrl = demoNews.ImageUrl;
                NewsFromDb.ImageName = demoNews.ImageName;
            }
            _context.Entry(NewsFromDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;




            //_context.Entry(NewsFromDb).CurrentValues.SetValues(demonews);
            _context.SaveChanges();
            return demoNews;

        }

        public void Delete(News demonews)
        {
            _context.Entry(demonews).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
