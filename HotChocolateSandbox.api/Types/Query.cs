using HotChocolateSandbox.api.Model;

namespace HotChocolateSandbox.api.Types;

[QueryType]
public static class Query
{
    public static Book GetBook()
        => Book.Create("C# in depth.", Author.Create("Jon Skeet"));
}