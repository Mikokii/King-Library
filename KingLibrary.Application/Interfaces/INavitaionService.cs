namespace KingLibrary.Application.Interfaces;

public interface INavigationService
{
    Task GoToBookDetails(string id);
    Task GoToAddBook(string letter);
}