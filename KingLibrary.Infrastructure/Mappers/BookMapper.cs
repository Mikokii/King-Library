using KingLibrary.Domain.Entities;
using KingLibrary.Infrastructure.Persistence;
using Realms;

namespace KingLibrary.Infrastructure.Mappers;

public static class BookMapper
{
    public static Book ToDomain(this BookRealm realm)
    {
        return new Book
        {
            Id = realm.Id,
            Title = realm.Title,
            Year = realm.Year,            
            Publisher = realm.Publisher,
            ImageUrl = realm.ImageUrl,
            Description = realm.Description ?? String.Empty
        };
    }

    public static BookRealm ToRealm(this Book book)
    {
        return new BookRealm
        {
            Id = book.Id,
            Title = book.Title,
            Year = book.Year,
            Publisher = book.Publisher,
            ImageUrl = book.ImageUrl,
            Description = book.Description ?? String.Empty
        };
    }
}