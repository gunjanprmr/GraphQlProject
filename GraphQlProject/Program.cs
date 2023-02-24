using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQlProject.Interfaces;
using GraphQlProject.Mutations;
using GraphQlProject.Query;
using GraphQlProject.Schema;
using GraphQlProject.Services;
using GraphQlProject.Type;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Cosmos
builder.Services.AddSingleton(_ => new CosmosClient(builder.Configuration["Cosmos:ConnectionString"]));


// builder.Services.AddTransient<IProduct, ProductService>();
builder.Services.AddTransient<IUser, UserService>();

// Register GraphQL type, query and schema
// builder.Services.AddSingleton<ProductType>();
builder.Services.AddSingleton<UserType>();
builder.Services.AddSingleton<ContactType>();

// builder.Services.AddSingleton<ProductQuery>();
builder.Services.AddSingleton<UserQuery>();

// builder.Services.AddSingleton<ProductMutation>();

// builder.Services.AddSingleton<ISchema, ProductSchema>();
builder.Services.AddSingleton<ISchema, UserSchema>();
builder.Services.AddGraphQL(x => x.EnableMetrics = false).AddSystemTextJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();


app.Run();