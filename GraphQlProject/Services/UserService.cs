using System.Text.Json;
using System.Text.Json.Serialization;
using GraphQlProject.Interfaces;
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

    public async Task<User> AddUser(User user)
    {
        try
        {
            var dbname = _config.GetValue<string>("Cosmos:DbName");
            var containerName = _config.GetValue<string>("Cosmos:UserContainer");
        
            using var stream = new MemoryStream();
            // Save to database
            await JsonSerializer.SerializeAsync(stream, user, options: new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
        
            var dbResponse = await _client.GetContainer(dbname, containerName)
                .CreateItemStreamAsync(stream, new PartitionKey(user.userId), new ItemRequestOptions
                {
                    EnableContentResponseOnWrite = true
                });
            
            var savedUser = dbResponse.IsSuccessStatusCode 
                ? await JsonSerializer.DeserializeAsync<User>(dbResponse.Content) 
                : default;

            return savedUser;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<User> UpdateUser(string userId, User user)
    {
        try
        {
            var dbname = _config.GetValue<string>("Cosmos:DbName");
            var containerName = _config.GetValue<string>("Cosmos:UserContainer");
        
            using var stream = new MemoryStream();
            // Save to database
            user.userId = userId;
            await JsonSerializer.SerializeAsync(stream, user, options: new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
        
            var dbResponse = await _client.GetContainer(dbname, containerName)
                .UpsertItemStreamAsync(stream, new PartitionKey(user.userId), new ItemRequestOptions
                {
                    EnableContentResponseOnWrite = true
                });
            
            var updatedUser = dbResponse.IsSuccessStatusCode 
                ? await JsonSerializer.DeserializeAsync<User>(dbResponse.Content) 
                : default;

            return updatedUser;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteUser(string id, string userId)
    {
        try
        {
            var dbname = _config.GetValue<string>("Cosmos:DbName");
            var containerName = _config.GetValue<string>("Cosmos:UserContainer");
        
            await _client.GetContainer(dbname, containerName)
                .DeleteItemStreamAsync(id, new PartitionKey(userId), new ItemRequestOptions
                {
                    EnableContentResponseOnWrite = true
                });
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}