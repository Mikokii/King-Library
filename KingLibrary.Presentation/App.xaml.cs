namespace KingLibrary.Presentation;

public partial class App : Microsoft.Maui.Controls.Application
{
    private readonly IServiceProvider _serviceProvider;

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        System.Diagnostics.Trace.WriteLine("Creating main window");
        var shell = _serviceProvider.GetRequiredService<AppShell>();

        return new Window(shell);
    }
}