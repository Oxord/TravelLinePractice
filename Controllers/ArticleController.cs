using Microsoft.AspNetCore.Mvc;
using Web.DTO;
using Web.Domain.Entity;
using Web.Domain.Repositories;
using Web.Domain;

namespace Web.Controllers;

[ApiController]
[Route("article/")]
public class ArticleController : ControllerBase
{
    private readonly IArticleRepository _articleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ArticleController(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
    {
        _articleRepository = articleRepository;
        _unitOfWork = unitOfWork;
    }


    [HttpGet(Name = "GetArticle")]
    public IEnumerable<Article> Get()
    {
        return _articleRepository.GetAllArticles();
    }

    [HttpPost(Name = "SaveArticle")]
    public IActionResult SaveArticle(ArticleDto article)
    {

        Article domainArticle = new Article();
        domainArticle.Title = article.Title;
        domainArticle.Text = article.Text;
        _articleRepository.AddArticle(domainArticle);
        _unitOfWork.Commit();

        return new OkResult();
    }
}