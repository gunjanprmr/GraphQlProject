using GraphQL.Types;
using GraphQlProject.Models;

namespace GraphQlProject.Type;

public class UserType : ObjectGraphType<User>
{
    public UserType()
    {
        Field(x => x.id);
        Field(x => x.userId);
        Field(x => x.isActive);
        Field(
            name: "contact",
            type: typeof(ContactType),
            resolve: context => context.Source.contact
        );
    }
}