using GraphQL;
using GraphQL.Types;
using GraphQlProject.Interfaces;
using GraphQlProject.Models;
using GraphQlProject.Type;

namespace GraphQlProject.Mutations;

public class UserMutation : ObjectGraphType
{
    public UserMutation(IUser userService)
    {
        Field<UserType>("createUser",
            arguments: new QueryArguments(
                new QueryArgument<UserInputType> { Name = "user" }
            ),
            resolve: _ => userService.AddUser(_.GetArgument<User>("user"))
        );
    }
}