using KingLibrary.Presentation.Views;

namespace KingLibrary.Presentation;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("bookdetails", typeof(BookDetailsPage));
		Routing.RegisterRoute("addbook", typeof(AddBookPage));
	}
}
