namespace QzemApp.Services.Settings;

public interface ISettingsService
{
    string UserId { get; set; }
    string UserName { get; set; }
    string Password { get; set; }
    string AuthToken { get; set; }
}

