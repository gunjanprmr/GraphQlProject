using User = GraphQlProject.Models.User;

namespace GraphQlProject.Interfaces;

public interface IUser
{
    Task<List<User>> GetUsers();
    Task<User> GetUserById(string id, string userId);
    Task<User> AddUser(User user);
    Task<User> UpdateUser(string userId, User user);
    Task DeleteUser(string id, string userId);
}