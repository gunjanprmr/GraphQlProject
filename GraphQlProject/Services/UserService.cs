using System.Text.Json;
using GraphQlProject.Interfaces;
using GraphQlProject.Models;
using Microsoft.Azure.Cosmos;
using User = GraphQlProject.Models.User;

namespace GraphQlProject.Services;

public class UserService : IUser
{
    private readonly CosmosClient _client;
    private readonly IConfiguration _config;
    public UserService(CosmosClient client, IConfiguration config)
    {
        _client = client;
        _config = config;
    }

    public async Task<User> GetUserById(string id, string userId)
    {
        try
        {
            var dbname = _config.GetValue<string>("Cosmos:DbName");
            var containerName = _config.GetValue<string>("Cosmos:UserContainer");

            var test = await _client.GetContainer(dbname, containerName)
                .ReadItemStreamAsync(id, new PartitionKey(userId));
            
            var user = test.IsSuccessStatusCode 
                ? await JsonSerializer.DeserializeAsync<User>(test.Content) 
                : default;

            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}