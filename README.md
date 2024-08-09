# Overview
This project is a sandbox for testing out different ways to provide EFCore DbContexts when implementing a GraphQL API.

The solution contains a central `HotChocolateSandbox.Data` class library which includes the EFCore model and the DbContext.
Different Web-API's use this classlibrary to setup a GraphQL Server and provide the DbContext in different ways.

References from the [ChilliCream Documentation](https://chillicream.com/docs/hotchocolate/v13/integrations/entity-framework) in regards to EntityFramework are used.

# HotChocolate
Hotchocolate v14 is used.
## IRequestExecutorBuilder.RegisterDbContext
The extension method `RegisterDbContext<TDbContext>` on the `IRequestExecutorBuilder` from the `HotChocolate.Data.EntityFramework` package simplifies a way to define the `ServiceKind` with which services are injected into the resolvers in a global way.

Alternatively it can be defined per resolver using `[Service(ServiceKind.Synchronized)] ApplicationDbContext dbContext`

[ChilliCream Documentation](https://chillicream.com/docs/hotchocolate/v13/integrations/entity-framework#resolver-injection-of-a-dbcontext) for reference
# Ways to register a DbContext
## AddDbContextPool
`builder.Services.AddDbContextPool<HotChocolateSandboxDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));`

this creates a pool of DbContexts that are reused. When different GraphQL Resolvers inject a DbContext at the same time, different Instances of DbContexts are injected and execute operations.