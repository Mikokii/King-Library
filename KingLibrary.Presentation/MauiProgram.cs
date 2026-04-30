using KingLibrary.Application.Interfaces;
using KingLibrary.Application.UseCases;
using KingLibrary.Infrastructure.Repositories;
using KingLibrary.Presentation.Services;
using KingLibrary.Presentation.ViewModels;
using KingLibrary.Presentation.Views;

namespace KingLibrary.Presentation;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>();

        builder.Services.AddSingleton<IBookRepository, BookRepository>();
        builder.Services.AddSingleton<GetBooksUseCase>();
        builder.Services.AddSingleton<GetBookDetailsUseCase>();
        builder.Services.AddSingleton<AddBookUseCase>();
		builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<BookDetailsViewModel>();
        builder.Services.AddSingleton<BookDetailsPage>();
        builder.Services.AddTransient<AddBookViewModel>();
        builder.Services.AddTransient<AddBookPage>();

        return builder.Build();
    }
}