using QzemApp.Constants;
using QzemApp.Models;
using QzemApp.Repository;
using QzemApp.Services;
using QzemApp.Services.Settings;

namespace QzemApp.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IGenericRepository _genericRepository;
    private readonly ISettingsService _settingsService;

    public AuthenticationService(IGenericRepository genericRepository,
        ISettingsService settingsService)
    {
        _genericRepository = genericRepository;
        _settingsService = settingsService;
    }

    public Task<AuthenticationResponse> Register(string firstName, string lastName, string email, string userName, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<string> Authenticate(string userName, string password)
    {
        UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        {
            Path = ApiConstants.AuthenticateEndpoint
        };

        AuthenticationRequest authenticationRequest = new AuthenticationRequest()
        {
            UserName = userName,
            Password = password
        };

        return await _genericRepository.PostAsync<AuthenticationRequest, string>(builder.ToString(), authenticationRequest);
    }

    public bool IsUserAuthenticated()
    {
        return !string.IsNullOrEmpty(_settingsService.AuthToken);
    }
}