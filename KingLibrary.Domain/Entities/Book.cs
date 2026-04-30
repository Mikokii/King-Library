using System;

namespace KingLibrary.Domain.Entities;

public class Book
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = string.Empty;

    public int Year { get; set; }

    public string Publisher { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

}
