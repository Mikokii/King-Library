using System;
using KingLibrary.Application.Helpers;
using KingLibrary.Application.Interfaces;
using KingLibrary.Domain.Entities;

namespace KingLibrary.Application.UseCases;

public class GetBooksUseCase
{
    private readonly IBookRepository _repo;

    public GetBooksUseCase(IBookRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<IGrouping<string, Book>>> ExecuteGrouped()
    {
        var data = await _repo.GetAllAsync();

        return data
            .OrderBy(b => TitleNormalizer.Normalize(b.Title))
            .GroupBy(b => TitleNormalizer.GetGroupKey(b.Title))
            .OrderBy(g => g.Key == "#" ? 1 : 0)
            .ThenBy(g => g.Key)
            .ToList();
    }
}
