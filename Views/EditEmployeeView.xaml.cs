using Employees.Models;
using Employees.Models.Wrappers;
using Employees.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
