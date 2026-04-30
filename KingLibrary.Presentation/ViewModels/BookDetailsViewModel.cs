using CommunityToolkit.Mvvm.ComponentModel;
using KingLibrary.Application.UseCases;
using KingLibrary.Domain.Entities;

namespace KingLibrary.Presentation.ViewModels;

[QueryProperty(nameof(Id), "id")]
public partial class BookDetailsViewModel : ObservableObject
{
    private readonly GetBookDetailsUseCase _useCase;

    public BookDetailsViewModel(GetBookDetailsUseCase useCase)
    {
        _useCase = useCase;
    }

    private string id;

    public string Id
    {
        get => id;
        set
        {
            id = value;
            _ = Load(value);
        }
    }

    public string Description =>
        string.IsNullOrWhiteSpace(Book?.Description)
            ? "No description available"
            : Book.Description;

    private Book? book;
    public Book? Book
    {
        get => book;
        set {
            if (SetProperty(ref book, value))
            {
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    private async Task Load(string id)
    {
        Book = await _useCase.Execute(id) ?? new ();
    }
}