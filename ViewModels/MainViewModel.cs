﻿using Employees.Commands;
using Employees.Models;
using Employees.Models.Domains;
using Employees.Models.Repositories;
using Employees.Models.Wrappers;
using Employees.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Employees.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private EmployeeRepository _employeeRepository = new EmployeeRepository();

        public MainViewModel()
        {
            using(var context = new ApplicationDbContext())
            {
                var employees = context.Employees.ToList();
            }

            RefreshEmployeesCommand = new RelayCommand(RefreshEmployees);
            ReadEmployeesFileCommand = new RelayCommand(ReadEmployeesFile);
            EditEmployeeCommand = new RelayCommand(EditEmployee, CanEditEmployee);

            Refresh();

        }
        

        public ICommand RefreshEmployeesCommand { get; set; }
        public ICommand ReadEmployeesFileCommand { get; set; }
        public ICommand EditEmployeeCommand { get; set; }

        private EmployeeWrapper _selectedEmployee;
        public EmployeeWrapper SelectedEmployee
        {
            get 
            {
                return _selectedEmployee; 
            } 
            set 
            {
                _selectedEmployee = value; 
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

        private void Refresh()
        {
            Employees = new ObservableCollection<EmployeeWrapper>(_employeeRepository.GetEmployees());            
        }

        private void RefreshEmployees(object obj)
        {
            Refresh();
        }

        private void ReadEmployeesFile(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.ShowDialog();

            //
            // HOW TO DO?
            //

            _employeeRepository.AddToDb(Employees);
        }

        private void EditEmployee(object obj)
        {
            var addEditEmployeeWindow = new EditEmployeeView(obj as EmployeeWrapper);
            addEditEmployeeWindow.Closed += EditEmployeeWindow_Closed;
            addEditEmployeeWindow.ShowDialog();
        }

        private void EditEmployeeWindow_Closed(object sender, EventArgs e)
        {
            Refresh();
        }

        private bool CanEditEmployee(object obj)
        {
            return SelectedEmployee != null;
        }

    }
}
