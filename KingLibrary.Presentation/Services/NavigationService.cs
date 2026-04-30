using KingLibrary.Application.Interfaces;

namespace KingLibrary.Presentation.Services;

public class NavigationService : INavigationService
{
    public Task GoToBookDetails(string id)
    {
        return Shell.Current.GoToAsync($"bookdetails?id={id}");
    }

    public Task GoToAddBook(string letter)
    {
        return Shell.Current.GoToAsync($"addbook?letter={letter}");
    }
}