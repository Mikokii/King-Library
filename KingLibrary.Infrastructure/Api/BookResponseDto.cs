using System;
using System.Text.Json.Serialization;

namespace KingLibrary.Infrastructure.Api;

public class BooksResponseDto
{
    [JsonPropertyName("data")]
    public List<BookDto> Data { get; set; } = new();
}