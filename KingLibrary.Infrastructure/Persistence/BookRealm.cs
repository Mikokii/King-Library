using System;
using Realms;

namespace KingLibrary.Infrastructure.Persistence;

public class BookRealm : RealmObject
{
    [PrimaryKey]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = string.Empty;

    public int Year { get; set; }

    public string Publisher { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public string? Description { get; set; }
}
