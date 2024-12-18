using QzemApp.Services;

namespace QzemApp.Services.Dialog;

public class DialogService : IDialogService
{
    public Task ShowAlertAsync(string message, string title, string buttonLabel)
    {
        return Application.Current.MainPage.DisplayAlert(message, title, buttonLabel);
    }
}