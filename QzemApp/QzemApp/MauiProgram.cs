using QzemApp.Repository;
using QzemApp.Services.Authentication;
using QzemApp.Services.Contract;
using QzemApp.Services.Dialog;
using QzemApp.Services.Navigation;
using QzemApp.Services.Settings;
using QzemApp.Views;
using QzemApp.ViewModels;

namespace QzemApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
        .RegisterAppServices()
        .RegisterViewModels()
        .RegisterViews();

        return builder.Build();
    }

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
        mauiAppBuilder.Services.AddSingleton<IContractService, ContractService>();
        mauiAppBuilder.Services.AddSingleton<IDialogService, DialogService>();
        mauiAppBuilder.Services.AddSingleton<IGenericRepository, GenericRepository>();
        mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
        mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<LoginViewModel>();

        mauiAppBuilder.Services.AddTransient<DimonaOverviewViewModel>();
        mauiAppBuilder.Services.AddTransient<DimonaDetailViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<LoginPage>();
        mauiAppBuilder.Services.AddTransient<DimonaOverviewPage>();
        mauiAppBuilder.Services.AddTransient<DimonaDetailPage>();

        return mauiAppBuilder;
    }
}