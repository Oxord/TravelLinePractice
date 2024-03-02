using Microsoft.EntityFrameworkCore;
using Web.Domain.Entity;
using Web.Domain.Repositories;

namespace Web.Infastructure;
internal class ArticleRepository : IArticleRepository
{
    private readonly ApplicationContext _context;

    public ArticleRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void AddArticle(Article article)
    {
        _context.Articles.Add(article);
    }

    public List<Article> GetAllArticles()
    {
        return _context.Articles.ToList();
    }
}