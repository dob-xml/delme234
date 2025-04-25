
using ConferencePlanner.GraphQL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services
    .AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test;ConnectRetryCount=0"))
    .AddGraphQLServer()
    .AddGraphQLTypes();

var app = builder.Build();

app.MapGraphQL();

await app.RunWithGraphQLCommandsAsync(args);