using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using QzemApp.Constants;
using QzemApp.Services.Contract;
using QzemApp.Services.Dialog;
using QzemApp.Services.Navigation;
using QzemApp.Services.Settings;
using QzemApp.Models;
using QzemApp.ViewModels.Base;

namespace QzemApp.ViewModels;

[QueryProperty(nameof(SelectedContract), "selectedContract")]
public class DimonaDetailViewModel : ViewModelBase
{
    private readonly IContractService _contractService;
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;
    private readonly ISettingsService _settingsService;

    private ContractDimonaResponse _selectedContract;
    private string _workerName;
    private string _profession;
    private string _date;
    private TimeSpan _startHour;
    private TimeSpan _endHour;

    public ICommand OnSaveHoursCommand { get; }

    public DimonaDetailViewModel(IContractService contractService,
        IDialogService dialogService,
        INavigationService navigationService,
        ISettingsService settingsService)
    {
        _contractService = contractService;
        _dialogService = dialogService;
        _navigationService = navigationService;
        _settingsService = settingsService;

        OnSaveHoursCommand = new AsyncRelayCommand(OnSaveHoursAsync);
    }

    public ContractDimonaResponse SelectedContract
    {
        get => _selectedContract;
        set
        {
            SetProperty(ref _selectedContract, value);
            WorkerName = SelectedContract.WorkerFirstName + " " + SelectedContract.WorkerName;
            Profession = SelectedContract.Profession;
            Date = SelectedContract.StartDate;
            StartHour = Convert.ToDateTime(SelectedContract.StartHour).TimeOfDay;
            EndHour = Convert.ToDateTime(SelectedContract.EndHour).TimeOfDay;
        }
    }

    public string WorkerName
    {
        get => _workerName;
        set => SetProperty(ref _workerName, value);
    }

    public string Profession
    {
        get => _profession;
        set => SetProperty(ref _profession, value);
    }

    public string Date
    {
        get => _date;
        set => SetProperty(ref _date, value);
    }

    public TimeSpan StartHour
    {
        get => _startHour;
        set => SetProperty(ref _startHour, value);
    }

    public TimeSpan EndHour
    {
        get => _endHour;
        set => SetProperty(ref _endHour, value);
    }

    public async Task OnSaveHoursAsync()
    {
        await IsBusyFor(
            async () =>
            {
                try
                {
                    var currentDay = DateTime.Now.Date;
                    var date = Convert.ToDateTime(_date).Date;
                    if (date < currentDay.AddDays(-2))
                    {
                        await _dialogService.ShowAlertAsync("Werkuren", "Dimona kan niet meer gewijzigd worden!", "OK");
                    }
                    else
                    {
                        var contract = new ContractDimonaRequest();
                        MapContractResponseToContractRequest(contract);

                        await _contractService.SaveContract(contract, false);
                        await _dialogService.ShowAlertAsync("Werkuren", "Tijd opgeslagen.", "OK");
                        await _navigationService.PopAsync();
                    }
                }
                catch(HttpRequestException ex)
                {
                    await _dialogService.ShowAlertAsync("Werkuren", "Er ging iets mis, probeer opnieuw!", "OK");
                    Console.WriteLine(ex.Message);
                }
            });
    }

    private ContractDimonaRequest MapContractResponseToContractRequest(ContractDimonaRequest contract)
    {
        contract.Id = SelectedContract.Id;
        contract.UsingEmployerId = SelectedContract.UsingEmployerId;
        contract.UsingEmployerName = SelectedContract.UsingEmployerName;
        contract.EmployerId = SelectedContract.EmployerId;
        contract.EmployerName = SelectedContract.EmployerName;
        contract.PersonId = SelectedContract.PersonId;
        contract.WorkerCode = SelectedContract.WorkerCode;
        contract.JointCommissionCode = SelectedContract.JointCommissionCode;
        contract.ContractGuid = SelectedContract.ContractGuid;
        contract.ContractTypeCode = SelectedContract.ContractTypeCode;
        contract.StartDate = SelectedContract.StartDate.ToString();
        contract.StartHour = StartHour;
        contract.EndDate = SelectedContract.EndDate.ToString();
        contract.EndHour = EndHour;
        contract.PlannedHours = SelectedContract.PlannedHours;
        contract.Profession = SelectedContract.Profession;
        contract.CostCenter = SelectedContract.CostCenter;
        contract.Location = SelectedContract.Location;
        contract.Salary = SelectedContract.Salary;
        contract.TravelContributionCode = SelectedContract.TravelContributionCode;
        contract.Q = SelectedContract.Q;
        contract.ExternalRefId = SelectedContract.ExternalRefId;
        contract.Inss = SelectedContract.Inss;
        contract.WorkerFirstName = SelectedContract.WorkerFirstName;
        contract.WorkerName = SelectedContract.WorkerName;

        return contract;
    }
}