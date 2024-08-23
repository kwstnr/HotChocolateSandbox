using HotChocolate.v14Test.Data;
using HotChocolate.v14Test.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotChocolateSandboxDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services
    .AddScoped<AuthorService>();

builder.Services
    .AddGraphQLServer()
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);