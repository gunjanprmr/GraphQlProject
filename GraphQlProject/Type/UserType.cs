using GraphQL.Types;
using GraphQlProject.Models;

namespace GraphQlProject.Type;

public class UserType : ObjectGraphType<User>
{
    public UserType()
    {
        Field(x => x.id);
        Field(x => x.isActive);
    }
}