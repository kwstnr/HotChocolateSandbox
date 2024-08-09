using System.ComponentModel.DataAnnotations;

namespace HotChocolateSandbox.Data.Model;

public class Book
{
    [Key]
    public Guid Id { get; init; }
    public string Title { get; set; }
    public Author Author { get; set; }
    public Guid AuthorId { get; private set; }

    private Book()
    {
    }

    private Book(string title, Author author)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
    }

    public static Book Create(string title, Author author)
    {
        return new Book(title, author);
    }
}