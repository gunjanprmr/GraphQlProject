using GraphQlProject.Interfaces;
using GraphQlProject.Models;

namespace GraphQlProject.Services;

public class UserService : IUser
{
    public User GetUserById(string id)
    {
        return new User
        {
            id = "123",
            isActive = true
        };
    }
}