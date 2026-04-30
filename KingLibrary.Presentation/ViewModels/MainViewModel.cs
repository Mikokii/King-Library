using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KingLibrary.Application.Helpers;
using KingLibrary.Application.Interfaces;
using KingLibrary.Application.UseCases;
using KingLibrary.Domain.Entities;
using KingLibrary.Presentation.Models;

namespace KingLibrary.Presentation.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly GetBooksUseCase _getBooks;
    private readonly INavigationService _navigationService;
    public ObservableCollection<BookGroup> Groups { get; } = new();

    public MainViewModel(GetBooksUseCase getBooks, INavigationService navigationService)
    {
        _getBooks = getBooks;
        _navigationService = navigationService;
    }

    [RelayCommand]
    public async Task Load()
    {
        Groups.Clear();

        var grouped = await _getBooks.ExecuteGrouped();

        foreach (var group in grouped)
        {
            Groups.Add(new BookGroup
            {
                Letter = group.Key,
                Books = group.ToList()
            });
        }

        Console.WriteLine($"Loaded {grouped.Sum(g => g.Count())} books in {Groups.Count} groups");
    }

    [RelayCommand]
    public async Task OpenBook(Book book)
    {
        await _navigationService.GoToBookDetails(book.Id);
    }

    [RelayCommand]
    public async Task AddBook(string letter)
    {
        await _navigationService.GoToAddBook(letter);
    }
}
