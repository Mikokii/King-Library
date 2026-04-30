using KingLibrary.Infrastructure.Api;
using KingLibrary.Infrastructure.Persistence;

namespace KingLibrary.Infrastructure.Mappers;

public static class BookApiMapper
{
    public static BookRealm ToRealm(this BookDto dto)
    {
        return new BookRealm
        {
            Id = dto.Id.ToString(),
            Title = dto.Title,
            Year = dto.Year,
            Publisher = dto.Publisher,
            ImageUrl = $"https://picsum.photos/seed/{dto.Id}/200/300",
            Description = dto.Notes != null && dto.Notes.Count > 0
                ? string.Join("\n", dto.Notes)
                : String.Empty
        };
    }
}