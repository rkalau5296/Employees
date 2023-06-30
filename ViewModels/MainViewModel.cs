using Employees.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Employees.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            RefreshEmployeesCommand = new RelayCommand(RefreshEmployees, CanRefreshEmployees);
        }
        public ICommand RefreshEmployeesCommand { get; set; }

        private void RefreshEmployees(object obj)
        {
            MessageBox.Show("RefreshEmployees");
        }

        private bool CanRefreshEmployees(object obj)
        {
            return true;
        }

        
    }
}
