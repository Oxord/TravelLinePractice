using Web.Domain.Entity;

namespace Web.Domain.Repositories;
public interface IArticleRepository
{
    void AddArticle(Article article);
    List<Article> GetAllArticles();
}