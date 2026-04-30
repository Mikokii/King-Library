using System;
using KingLibrary.Application.Interfaces;
using KingLibrary.Domain.Entities;

namespace KingLibrary.Application.UseCases;

public class AddBookUseCase
{
    private readonly IBookRepository _repo;

    public AddBookUseCase(IBookRepository repo)
    {
        _repo = repo;
    }

    public async Task Execute(Book book)
    {
        var existingBook = await _repo.GetByIdAsync(book.Id);

        if (existingBook != null)
            return;

        await _repo.AddAsync(book);
    }
}
