using HotChocolateSandbox.api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<HotChocolateSandboxDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services
    .AddGraphQLServer()
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);