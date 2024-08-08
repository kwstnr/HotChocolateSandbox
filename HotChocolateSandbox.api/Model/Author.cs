using System.ComponentModel.DataAnnotations;

namespace HotChocolateSandbox.api.Model;

public sealed class Author
{
    [Key]
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public ICollection<Book> Books { get; set; }
    
    private Author()
    {
    }
    
    private Author(string name)
    {
        Name = name;
    }
    
    public static Author Create(string name)
    {
        return new Author(name);
    }
}