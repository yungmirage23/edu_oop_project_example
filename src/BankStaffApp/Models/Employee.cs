using System.ComponentModel.DataAnnotations;

namespace BankStaffApp.Models;
public class Employee
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public DateTime HireDate { get; set; }

    public int BranchId { get; set; }
    public Branch Branch { get; set; }

    public int PositionId { get; set; }
    public Position Position { get; set; }
}
