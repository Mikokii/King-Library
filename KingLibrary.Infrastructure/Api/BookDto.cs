using System;
using System.Text.Json.Serialization;

namespace KingLibrary.Infrastructure.Api;

public class BookDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("Title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("Year")]
    public int Year { get; set; }

    [JsonPropertyName("Publisher")]
    public string Publisher { get; set; } = string.Empty;

    [JsonPropertyName("Notes")]
    public List<string>? Notes { get; set; }
}
