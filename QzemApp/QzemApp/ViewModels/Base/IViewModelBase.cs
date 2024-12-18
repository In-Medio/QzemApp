using QzemApp.Services.Dialog;
using QzemApp.Services.Navigation;
using QzemApp.Services.Settings;

namespace QzemApp.ViewModels.Base;

public interface IViewModelBase : IQueryAttributable
{
    public bool IsBusy { get; }

    public bool IsInitialized { get; set; }

    Task InitializeAsync();
}