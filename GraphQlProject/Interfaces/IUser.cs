using GraphQlProject.Models;

namespace GraphQlProject.Interfaces;

public interface IUser
{
    Task<User> GetUserById(string id, string userId);
}