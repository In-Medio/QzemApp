using System.Windows.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using QzemApp.Constants;
using QzemApp.Extensions;
using QzemApp.Models;
using QzemApp.Services.Contract;
using QzemApp.Services.Dialog;
using QzemApp.Services.Navigation;
using QzemApp.Services.Settings;
using QzemApp.ViewModels.Base;

namespace QzemApp.ViewModels;

public class DimonaOverviewViewModel : ViewModelBase
{
    private readonly IContractService _contractService;
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;
    private readonly ISettingsService _settingsService;

    private int _id;
    private string _workerFirstName;
    private string _workerName;
    private ObservableCollection<ContractDimonaResponse> _contractsByDate;
    private DateTime _selectedDate;

    public ICommand OnDateSelectedCommand { get; }
    public ICommand GetContractDetailsCommand { get; }
    public ICommand OnLogOutCommand { get; }

    public DimonaOverviewViewModel(IContractService contractService,
        INavigationService navigationService,
        IDialogService dialogService,
        ISettingsService settingsService)
    {
        _contractService = contractService;
        _dialogService = dialogService;
        _navigationService = navigationService;
        _settingsService = settingsService;

        OnDateSelectedCommand = new AsyncRelayCommand(OnDateSelectedAsync);

        GetContractDetailsCommand = new AsyncRelayCommand<ContractDimonaResponse>(GetContractDetailsAsync);

        OnLogOutCommand = new AsyncRelayCommand(OnLogOutAsync);

        ContractsByDate = new ObservableCollection<ContractDimonaResponse>();

        if (DateTime.Now.Hour < 12)
        {
            SelectedDate = DateTime.Now.AddDays(-1).Date;
        }
        else
        {
            SelectedDate = DateTime.Now.Date;
        }

        InitializeAsync().GetAwaiter();
    }

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);

    }

    public string WorkerFirstName
    {
        get => _workerFirstName;
        set => SetProperty(ref _workerFirstName, value);
    }

    public string WorkerName
    {
        get => _workerName;
        set => SetProperty(ref _workerName, value);
    }

    public ObservableCollection<ContractDimonaResponse> ContractsByDate
    {
        get => _contractsByDate;
        set => SetProperty(ref _contractsByDate, value);

    }

    public DateTime SelectedDate
    {
        get => _selectedDate;
        set => SetProperty(ref _selectedDate, value);
    }

    public override async Task InitializeAsync()
    {
        await OnDateSelectedAsync();
    }

    private async Task OnDateSelectedAsync()
    {
        await IsBusyFor(
            async () =>
            {
                try
                {
                    var date = SelectedDate.Year.ToString() + "-" + SelectedDate.Month.ToString("D2") + "-" + SelectedDate.Day.ToString("D2");
                    var contracts = await _contractService.GetContractsByDate(date);
                    ContractsByDate = (contracts.Where(contract => WorkerConstants.WorkerCodesAccepted
                        .Contains(contract.WorkerCode.ToString()) &&
                        contract.EndDate != null).OrderBy(x => x.WorkerName)).ToObservableCollection();
                }
                catch(HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
    }

    private async Task GetContractDetailsAsync(ContractDimonaResponse selectedContract)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            {"selectedContract", selectedContract}
        };

        await _navigationService.NavigateToAsync("details", navigationParameter);
    }

    private async Task OnLogOutAsync()
    {
        _settingsService.AuthToken = string.Empty;
        await _navigationService.PopAsync();
    }
}