using QzemApp.Services.Navigation;
using QzemApp.ViewModels;

namespace QzemApp;

public partial class App : Application
{
    private readonly INavigationService _navigationService;

    public App(INavigationService navigationService)
    {
        _navigationService = navigationService;

        InitializeComponent();

        MainPage = new AppShell(navigationService);
    }

    protected override void OnStart()
    {
        // Handle when your app starts
    }

    protected override void OnSleep()
    {
        // Handle when your app sleeps
    }

    protected override void OnResume()
    {
        // Handle when your app resumes
    }
}

