using System.Windows;
using BankStaffApp.Models;
using BankStaffApp.ViewModels;

namespace BankStaffApp
{
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel => (MainViewModel)DataContext;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddEmployee(viewModel.NewEmployee);
            viewModel.NewEmployee = new Employee();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SelectedEmployee != null)
                viewModel.UpdateEmployee(viewModel.SelectedEmployee);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SelectedEmployee != null)
                viewModel.DeleteEmployee(viewModel.SelectedEmployee);
        }

        private void AddBranch_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddBranch();
        }

        private void AddPosition_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddPosition();
        }
    }
}
