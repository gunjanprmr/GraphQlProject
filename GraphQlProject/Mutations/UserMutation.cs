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
        
        Field<UserType>("updateUser",
            arguments: new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "userId" },
                new QueryArgument<UserInputType> { Name = "user" }
            ),
            resolve: _ => userService.UpdateUser(
                    _.GetArgument<string>("userId"),
                    _.GetArgument<User>("user")
                    )
        );
        
        Field<StringGraphType>("deleteUser",
            arguments: new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "id" },
                new QueryArgument<StringGraphType> { Name = "userId" }
            ),
            resolve: _ =>
            {
                var id = _.GetArgument<string>("id");
                var userId = _.GetArgument<string>("userId");
                userService.DeleteUser(id, userId);
                return $"The user against the {userId} has been deleted";
            }
        );
    }
}