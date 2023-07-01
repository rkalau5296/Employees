using Employees.Commands;
using Employees.Models;
using Employees.Models.Repositories;
using Employees.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Employees.ViewModels
{   

    public class EditEmployeeViewModel : ViewModelBase
    {
        private EmployeeRepository _employeeRepository = new EmployeeRepository();
        public EditEmployeeViewModel(EmployeeWrapper employee = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);            

            Employee = employee;
            IsUpdate = true;
        }

        
        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private EmployeeWrapper _employee { get; set; }
        public EmployeeWrapper Employee
        {
            get 
            { 
                return _employee; 
            }
            set 
            { 
                _employee = value; 
                OnPropertyChanged(); 
            }
        }

        private bool _isUpdate;
        public bool IsUpdate
        {
            get
            {
                return _isUpdate;
            }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<EmployeeWrapper> _employees;
        public ObservableCollection<EmployeeWrapper> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        private void Confirm(object obj)
        {
            _employeeRepository.Update(Employee);
            CloseWindow(obj as Window);
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }
        private void CloseWindow(Window window)
        {
            window.Close();
        }

    }
}
