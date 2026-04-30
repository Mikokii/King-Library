using System;
using KingLibrary.Application.Interfaces;
using KingLibrary.Domain.Entities;
using KingLibrary.Infrastructure.Api;
using KingLibrary.Infrastructure.Mappers;
using KingLibrary.Infrastructure.Persistence;
using Realms;
using Refit;

namespace KingLibrary.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly Realm _realm;
    private readonly IBookApi _api;

    public BookRepository()
    {
        _realm = Realm.GetInstance();
        _api = RestService.For<IBookApi>("https://stephen-king-api.onrender.com");
    }

    public async Task<List<Book>> GetAllAsync()
    {
        var realmBooks = _realm.All<BookRealm>().ToList();

        if (realmBooks.Count == 0)
        {
            var response = await _api.GetBooksAsync();
            var apiBooks = response.Data;

            _realm.Write(() =>
            {
                foreach (var b in apiBooks)
                {
                    _realm.Add(b.ToRealm());
                }
            });
        }

        realmBooks = _realm.All<BookRealm>().ToList();

        return realmBooks
            .Select(b => b.ToDomain())
            .ToList();
    }

    public async Task AddAsync(Book book)
    {
        _realm.Write(() =>
        {
            _realm.Add(book.ToRealm());
        });

        await Task.CompletedTask;
    }
    public async Task<Book?> GetByIdAsync(string id)
    {
        var realmBook = _realm.All<BookRealm>()
            .FirstOrDefault(b => b.Id == id);

        return realmBook?.ToDomain();
    }
}
