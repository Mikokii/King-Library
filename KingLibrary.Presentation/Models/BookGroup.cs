using System;
using KingLibrary.Domain.Entities;

namespace KingLibrary.Presentation.Models;

public class BookGroup
{
    public string Letter { get; set; } = "";
    public List<Book> Books { get; set; } = new();
}
