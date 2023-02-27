using User = GraphQlProject.Models.User;

namespace GraphQlProject.Interfaces;

public interface IUser
{
    Task<User> GetUserById(string id, string userId);
    Task<User> AddUser(User user);
}