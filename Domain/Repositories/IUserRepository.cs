using Web.Domain.Entity;

namespace Web.Domain.Repositories;
public interface IUserRepository
{
    void AddUser(User user);
    User? GetUser(int userId);
    List<User> GetAllUsers();
}