using Microsoft.AspNetCore.Mvc;
using Web.DTO;
using Web.Domain.Entity;
using Web.Domain.Repositories;
using Web.Domain;
using System.Xml.Linq;

namespace Web.Controllers;

[ApiController]
[Route("user/")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IArticleRepository _articleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUserRepository userRepository, IUnitOfWork unitOfWork, IArticleRepository articleRepository)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _articleRepository = articleRepository;
    }

    [HttpGet(Name = "GetUser")]
    public IEnumerable<User> Get()
    {
      return _userRepository.GetAllUsers();
    }

    [HttpPost(Name = "SaveUser")]
    public IActionResult SaveUser(UserDto user)
    {
        User domainUser = new User();
        domainUser.Name = user.Name;
        domainUser.Surname = user.Surname;
        domainUser.Email = user.Email;
        domainUser.Password = user.Password;
        _userRepository.AddUser(domainUser);
        _unitOfWork.Commit();

        return new OkResult();
    }
}