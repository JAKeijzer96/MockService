namespace MockService.Models;

public class EmployeeContractExtension
{
    public Guid Id { get; set; }
    public EmployeeContract EmployeeContract { get; set; }
    public OrganizationalUnit OrganizationalUnit { get; set; }
    public string Function { get; set; }
    public int LaborMinutesPerWeekMin { get; set; }
    public int LaborMinutesPerWeekMax { get; set; }
    public DateOnly validFrom { get; set; }
    public DateOnly validTo { get; set; }
}