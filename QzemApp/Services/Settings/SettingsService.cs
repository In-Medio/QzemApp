namespace QzemApp.Services.Settings;

public class SettingsService : ISettingsService
{
    #region Settings Constants
    private const string _userId = "user_id";
    private const string _userName = "username";
    private const string _password = "password";
    private const string _authToken = "auth_token";
    #endregion

    #region Settings Properties
    public string UserId
    {
        get => Preferences.Get(_userId, string.Empty);
        set => Preferences.Set(_userId, value);
    }

    public string UserName
    {
        get => Preferences.Get(_userName, string.Empty);
        set => Preferences.Set(_userName, value);
    }

    public string Password
    {
        get => Preferences.Get(_password, string.Empty);
        set => Preferences.Set(_password, value);
    }

    public string AuthToken
    {
        get => Preferences.Get(_authToken, string.Empty);
        set => Preferences.Set(_authToken, value);
    }
    #endregion
}

