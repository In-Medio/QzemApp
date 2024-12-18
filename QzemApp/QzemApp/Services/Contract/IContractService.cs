using System.Collections.ObjectModel;
using QzemApp.Models;

namespace QzemApp.Services.Contract;

public interface IContractService
{
    Task<IEnumerable<ContractDimonaResponse>> GetContractsByDate(string date);
    Task<int> SaveContract(ContractDimonaRequest contract, bool isNewItem);
}