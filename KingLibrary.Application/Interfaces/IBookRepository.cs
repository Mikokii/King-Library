using System;
using KingLibrary.Domain.Entities;

namespace KingLibrary.Application.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task AddAsync(Book book);
    Task<Book?> GetByIdAsync(string id);
}
