using System.ComponentModel.DataAnnotations;

namespace QzemApp.Models;

public class ContractDimonaRequest
{
    public int Id { get; set; }
    public int UsingEmployerId { get; set; }
    public string UsingEmployerName { get; set; }
    public int EmployerId { get; set; }
    public string EmployerName { get; set; }
    public int PersonId { get; set; }
    public int WorkerCode { get; set; }
    public int JointCommissionCode { get; set; }
    public int ContractGuid { get; set; }
    public int ContractTypeCode { get; set; }
    public string StartDate { get; set; }
    public TimeSpan StartHour { get; set; }
    public string EndDate { get; set; }
    public TimeSpan EndHour { get; set; }
    public int PlannedHours { get; set; }
    public string Profession { get; set; }
    public string CostCenter { get; set; }
    public string Location { get; set; }
    public decimal Salary { get; set; }
    public int TravelContributionCode { get; set; }
    public decimal Q { get; set; }
    public string ExternalRefId { get; set; }
    public string Inss { get; set; }
    public string WorkerFirstName { get; set; }
    public string WorkerName { get; set; }
}