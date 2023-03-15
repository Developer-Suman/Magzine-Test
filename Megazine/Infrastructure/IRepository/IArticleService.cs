using Megazine.Models;

namespace Megazine.Infrastructure.IRepository
{
    public interface IArticleService
    {
        void Delete(ArticleSecond demoarticle);
        List<ArticleSecond> GetAll();
        ArticleSecond GetById(int id);
        List<ArticleSecond> GetByName(string demoname);
        ArticleSecond Save(ArticleSecond demoarticle);
        ArticleSecond Update(ArticleSecond demoarticle);
    }
}