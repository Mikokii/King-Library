using System;
using Refit;

namespace KingLibrary.Infrastructure.Api;

public interface IBookApi
{
    [Get("/api/books")]
    Task<BooksResponseDto> GetBooksAsync();
}
