using QzemApp.Constants;
using QzemApp.Services.Authentication;

namespace QzemApp.Services.Navigation;

public class NavigationService : INavigationService
{
    private readonly IAuthenticationService _authenticationService;

    public NavigationService(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public Task InitializeAsync()
    {
        if (!_authenticationService.IsUserAuthenticated())
            return NavigateToAsync("login");
        else
            return NavigateToAsync("overview");
    }

    public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
    {
        var shellNavigation = new ShellNavigationState(route);

        return routeParameters != null
            ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
            : Shell.Current.GoToAsync(shellNavigation);
    }

    public Task PopAsync()
    {
        return Shell.Current.GoToAsync("..");
    }
}

