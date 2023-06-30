using Employees.Commands;
using Employees.Models;
using Employees.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            RefreshEmployeesCommand = new RelayCommand(RefreshEmployees);
            ReadEmployeesFileCommand = new RelayCommand(ReadEmployeesFile);
            EditEmployeeCommand = new RelayCommand(EditEmployee, CanEditEmployee);

            RefreshDiary();

        }
        

        public ICommand RefreshEmployeesCommand { get; set; }
        public ICommand ReadEmployeesFileCommand { get; set; }
        public ICommand EditEmployeeCommand { get; set; }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
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

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
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

        private void RefreshDiary()
        {
            Employees = new ObservableCollection<Employee>
            {
                new Employee
                {
                    id="1",
                    Name="Rafal",
                    Surename="Kalata",
                    Email="rafal@rafal.pl",
                    phone="502215223"
                },
                new Employee
                {
                    id="2",
                    Name="Piotr",
                    Surename="Kowal",
                    Email="rafal@rafal.pl",
                    phone="502215223"
                },
                new Employee
                {
                    id="3",
                    Name="Pawel",
                    Surename="Mieczkowski",
                    Email="rafal@rafal.pl",
                    phone="502215223"
                }
            };
        }

        private void RefreshEmployees(object obj)
        {
            RefreshDiary();
        }

        private void ReadEmployeesFile(object obj)
        {
            
        }

        private void EditEmployee(object obj)
        {
            var addEditEmployeeWindow = new EditEmployeeView(obj as Employee);
            addEditEmployeeWindow.Closed += EditEmployeeWindow_Closed;
            addEditEmployeeWindow.ShowDialog();
        }

        private void EditEmployeeWindow_Closed(object sender, EventArgs e)
        {
            RefreshDiary(); ;
        }

        private bool CanEditEmployee(object obj)
        {
            return SelectedEmployee != null;
        }

    }
}
