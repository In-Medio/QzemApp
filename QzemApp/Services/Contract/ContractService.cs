using System.Collections.ObjectModel;
using QzemApp.Constants;
using QzemApp.Models;
using QzemApp.Repository;
using QzemApp.Services.Contract;

namespace QzemApp.Services.Contract;

public class ContractService : IContractService
{
    private readonly IGenericRepository _genericRepository;

    public ContractService(IGenericRepository genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<IEnumerable<ContractDimonaResponse>> GetContractsByDate(string date)
    {
        UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        {
            Path = ApiConstants.ContractsByDateEndpoint + date
        };

        return await _genericRepository.GetAsync<ObservableCollection<ContractDimonaResponse>>(builder.ToString());
    }

    public async Task<int> SaveContract(ContractDimonaRequest contract, bool isNewItem = false)
    {
        UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        {
            Path = ApiConstants.SaveContractEndpoint
        };

        if (isNewItem)
            return await _genericRepository.PostAsync<ContractDimonaRequest, int>(builder.ToString(), contract);
        else
            return await _genericRepository.PutAsync<ContractDimonaRequest, int>(builder.ToString(), contract);
    }
}

