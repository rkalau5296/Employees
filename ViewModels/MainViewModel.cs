﻿using CsvHelper;
using CsvHelper.TypeConversion;
using Employees.Commands;
using Employees.Models.Domains;
using Employees.Models.Repositories;
using Employees.Models.Wrappers;
using Employees.Views;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
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

        private void ReadEmployeesFile(object obj)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();

                using (var reader = new StreamReader(openFileDialog.FileName))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<EmployeeMap>();
                    var records = csv.GetRecords<Employee>();
                    var employees = records.ToList();
                    _employeeRepository.AddToDb(employees);
                }                                  
                Refresh();
            }
            catch (TypeConverterException)
            {
                MessageBox.Show($"Próba załączenia pliku o nieprawidłowym rozszerzeniu, lub nieprawidłowe dane w pliku.");
            }
            catch (BadDataException)
            {
                MessageBox.Show($"Załączony plik nie posiada rekordów.");
            }
            catch (ArgumentException)
            {
                MessageBox.Show($"Nie wybrano ścieżki do pliku.");
            }
            catch(DbUpdateException)
            {
                MessageBox.Show($"Podany plik zawiera numery Id, którę już istnieją w bazie. Brak możliwości dodania kolejnego rekordu zawierającego to samo Id.");
            }            
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
