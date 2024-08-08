using System.ComponentModel.DataAnnotations;

namespace HotChocolateSandbox.api.Model;

public class Book
{
    [Key]
    public Guid Id { get; init; }
    public string Title { get; private set; }
    public Author Author { get; private set; }
    public Guid AuthorId { get; private set; }

    private Book()
    {
    }

    private Book(string title, Author author)
    {
        Title = title;
        Author = author;
    }

    public static Book Create(string title, Author author)
    {
        return new Book(title, author);
    }
}