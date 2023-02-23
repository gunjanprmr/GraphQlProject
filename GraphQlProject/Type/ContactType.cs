using GraphQL.Types;
using GraphQlProject.Models;

namespace GraphQlProject.Type;

public class ContactType : ObjectGraphType<Contact>
{
    public ContactType()
    {
        Field(x => x.firstName);
        Field(x => x.lastName);
        Field(x => x.email);
        Field(x => x.phoneNumber);
    }
}