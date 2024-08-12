using System.ComponentModel.DataAnnotations;

namespace HotChocolateSandbox.Data.Model;

public sealed class Author
{
    [Key]
    public Guid Id { get; init; }
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; }
    
    private Author()
    {
    }
    
    private Author(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
    
    public static Author Create(string name)
    {
        return new Author(name);
    }
}