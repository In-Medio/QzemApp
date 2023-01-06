using QzemApp.Models;

namespace QzemApp.Services.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> Register(string firstName, string lastName, string email, string userName,
        string password);

    Task<string> Authenticate(string userName, string password);

    bool IsUserAuthenticated();
}