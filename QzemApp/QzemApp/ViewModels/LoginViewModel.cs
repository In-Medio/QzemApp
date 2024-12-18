using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using QzemApp.Exceptions;
using QzemApp.Services.Authentication;
using QzemApp.Services.Dialog;
using QzemApp.Services.Navigation;
using QzemApp.Services.Settings;
using QzemApp.ViewModels.Base;

namespace QzemApp.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;
    private readonly ISettingsService _settingsService;

    private string _userName;

    private string _password;

    public ICommand OnLoginCommand { get; }

    public LoginViewModel(IAuthenticationService authenticationService,
        IDialogService dialogService,
        INavigationService navigationService,
        ISettingsService settingsService)
    {
        _authenticationService = authenticationService;
        _dialogService = dialogService;
        _navigationService = navigationService;
        _settingsService = settingsService;

        OnLoginCommand = new AsyncRelayCommand(OnLoginAsync);
    }

    public string UserName
    {
        get => _userName;
        set => SetProperty(ref _userName, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public async Task OnLoginAsync()
    {
        await IsBusyFor(
            async () =>
            {
                try
                {
                    _settingsService.UserName = UserName;
                    _settingsService.Password = Password;

                    var authToken = await _authenticationService.Authenticate(UserName, Password);
                    // we store the authtoken to know if the user is already logged in to the application
                    _settingsService.AuthToken = authToken;

                    if (_authenticationService.IsUserAuthenticated())
                    {
                        await _navigationService.NavigateToAsync("overview");
                        UserName = string.Empty;
                        Password = string.Empty;
                    }
                }
                catch (ServiceAuthenticationException ex)
                {
                    await _dialogService.ShowAlertAsync(
                    "Username or password is not valid!",
                    "Error logging you in",
                    "OK");
                    Console.WriteLine(ex.Message);
                }
            }
        );
    }
}

