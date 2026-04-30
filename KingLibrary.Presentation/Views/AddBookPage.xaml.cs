using KingLibrary.Presentation.ViewModels;

namespace KingLibrary.Presentation.Views;

public partial class AddBookPage : ContentPage
{
	public AddBookPage(AddBookViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}