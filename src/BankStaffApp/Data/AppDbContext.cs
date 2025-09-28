using BankStaffApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankStaffApp.Data;
public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;database=BankDb;user=root;password=root",
            new MySqlServerVersion(new Version(8, 0, 36)));
    }
}
