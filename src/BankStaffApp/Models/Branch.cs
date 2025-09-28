namespace BankStaffApp.Models;
public class Branch
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }

    public ICollection<Employee> Employees { get; set; }
}
