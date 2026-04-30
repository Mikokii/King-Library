using KingLibrary.Presentation.ViewModels;

namespace KingLibrary.Presentation.Views;

public partial class BookDetailsPage : ContentPage
{
    public BookDetailsPage(BookDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}