using GraphQlProject.Models;

namespace GraphQlProject.Interfaces;

public interface IUser
{
    User GetUserById(string id);
}