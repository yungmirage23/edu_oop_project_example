using System.Collections.ObjectModel;
using BankStaffApp.Data;
using BankStaffApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankStaffApp.ViewModels;
public class MainViewModel : BaseViewModel
{
    public ObservableCollection<Employee> Employees { get; set; } = new();
    public ObservableCollection<Branch> Branches { get; set; } = new();
    public ObservableCollection<Position> Positions { get; set; } = new();

    private Employee selectedEmployee;
    public Employee SelectedEmployee
    {
        get => selectedEmployee;
        set => Set(ref selectedEmployee, value);
    }

    private Employee newEmployee = new();
    public Employee NewEmployee
    {
        get => newEmployee;
        set => Set(ref newEmployee, value);
    }

    private Branch newBranch = new();
    public Branch NewBranch
    {
        get => newBranch;
        set => Set(ref newBranch, value);
    }

    private Position newPosition = new();
    public Position NewPosition
    {
        get => newPosition;
        set => Set(ref newPosition, value);
    }

    public MainViewModel()
    {
        LoadData();
    }

    public void LoadData()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated();

        Employees.Clear();
        foreach (var emp in db.Employees.Include(e => e.Branch).Include(e => e.Position))
            Employees.Add(emp);

        Branches.Clear();
        foreach (var b in db.Branches)
            Branches.Add(b);

        Positions.Clear();
        foreach (var p in db.Positions)
            Positions.Add(p);

        NewEmployee = new Employee();
    }

    public void AddEmployee(Employee emp)
    {
        using var db = new AppDbContext();
        db.Employees.Add(emp);
        db.SaveChanges();
        LoadData();
    }

    public void UpdateEmployee(Employee emp)
    {
        using var db = new AppDbContext();
        db.Employees.Update(emp);
        db.SaveChanges();
        LoadData();
    }

    public void DeleteEmployee(Employee emp)
    {
        using var db = new AppDbContext();
        db.Employees.Remove(emp);
        db.SaveChanges();
        LoadData();
    }

    public void AddBranch()
    {
        using var db = new AppDbContext();
        db.Branches.Add(NewBranch);
        db.SaveChanges();
        NewBranch = new Branch();
        LoadData();
    }

    public void AddPosition()
    {
        using var db = new AppDbContext();
        db.Positions.Add(NewPosition);
        db.SaveChanges();
        NewPosition = new Position();
        LoadData();
    }
}
