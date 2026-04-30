using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KingLibrary.Application.UseCases;
using KingLibrary.Domain.Entities;

namespace KingLibrary.Presentation.ViewModels;

[QueryProperty(nameof(Letter), "letter")]
public partial class AddBookViewModel : ObservableValidator
{
    private readonly AddBookUseCase _useCase;

    public AddBookViewModel(AddBookUseCase useCase)
    {
        _useCase = useCase;
        ImageUrl = "https://picsum.photos/200/300";
        Year = DateTime.Now.Year;
    }

    [ObservableProperty]
    private string letter;

    [ObservableProperty]
    [Required(ErrorMessage = "Title is required")]
    private string title;

    [ObservableProperty]
    [Required(ErrorMessage = "Publisher is required")]
    private string publisher;

    [ObservableProperty]
    [Range(1900, 2100, ErrorMessage = "Year must be valid")]
    private int year;

    [ObservableProperty]
    private string imageUrl;

    public string? TitleError =>
        GetErrors(nameof(Title))?.FirstOrDefault()?.ErrorMessage;

    public string? PublisherError =>
        GetErrors(nameof(Publisher))?.FirstOrDefault()?.ErrorMessage;

    public string? YearError =>
        GetErrors(nameof(Year))?.FirstOrDefault()?.ErrorMessage;

    partial void OnTitleChanged(string value)
    {
        ValidateProperty(value, nameof(Title));
        OnPropertyChanged(nameof(TitleError));
    }

    partial void OnPublisherChanged(string value)
    {
        ValidateProperty(value, nameof(Publisher));
        OnPropertyChanged(nameof(PublisherError));
    }

    partial void OnYearChanged(int value)
    {
        ValidateProperty(value, nameof(Year));
        OnPropertyChanged(nameof(YearError));
    }

    [RelayCommand]
    public async Task Save()
    {
        ValidateAllProperties();

        OnPropertyChanged(nameof(TitleError));
        OnPropertyChanged(nameof(PublisherError));
        OnPropertyChanged(nameof(YearError));

        if (HasErrors)
            return;

        await _useCase.Execute(new Book
        {
            Title = Title,
            Publisher = Publisher,
            Year = Year,
            ImageUrl = ImageUrl,
            Description = ""
        });

        await Shell.Current.GoToAsync("..");
    }
}