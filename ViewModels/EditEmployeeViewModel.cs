﻿using Employees.Commands;
using Employees.Models.Repositories;
using Employees.Models.Wrappers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

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
            if (!Employee.IsValid)
                return;
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
