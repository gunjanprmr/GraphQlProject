using GraphQlProject.Interfaces;
using GraphQlProject.Models;
using Microsoft.Azure.Cosmos;
using User = GraphQlProject.Models.User;

namespace GraphQlProject.Services;

public class UserService : IUser
{
    public CosmosClient _client;

    public UserService(CosmosClient client)
    {
        _client = client;
    }
    public async Task<User> GetUserById(string id)
    {
        try
        {
            var dbname = "c4p";
            var containername = "users";
            Database database = await _client.CreateDatabaseIfNotExistsAsync(dbname);
            var container = database.GetContainer(containername);
            var test = $"SELECT c.id FROM c WHERE c.id = \"{id}\"";
            var query = container.GetItemQueryIterator<User>(test);
            // string ss = string.Empty;
        
            while (query.HasMoreResults)
            {
                var result = await query.ReadNextAsync();
                foreach (var item in result) {
                    // ss += item.id;
                }
            }
            return new User
            {
                id = "123",
                isActive = true,
                contact = new Contact
                {
                    firstName = "john",
                    lastName = "doe",
                    email = "test@test.com",
                    phoneNumber = "1234567890"
                }
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}