using KingLibrary.Application.Interfaces;
using KingLibrary.Domain.Entities;

namespace KingLibrary.Application.UseCases;

public class GetBookDetailsUseCase
{
    private readonly IBookRepository _repo;

    public GetBookDetailsUseCase(IBookRepository repo)
    {
        _repo = repo;
    }

    public async Task<Book?> Execute(string id)
    {
        return await _repo.GetByIdAsync(id);
    }
}