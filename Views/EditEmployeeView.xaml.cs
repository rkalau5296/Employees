using Employees.Models.Wrappers;
using Employees.ViewModels;
using MahApps.Metro.Controls;
using System.Windows;

namespace Employees.Views
{
    /// <summary>
    /// Interaction logic for EditEmployeeView.xaml
    /// </summary>
    public partial class EditEmployeeView : MetroWindow
    {
        public EditEmployeeView(EmployeeWrapper employee = null)
        {
            InitializeComponent();
            DataContext = new EditEmployeeViewModel(employee);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
