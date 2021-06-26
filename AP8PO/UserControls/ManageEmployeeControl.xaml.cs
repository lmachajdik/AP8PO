using AP8PO.Database.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AP8PO.UserControls
{
    public class EmployeeViewModel : Model
    {
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                OnPropertyChanged();
                return selectedEmployee;
            }
            set
            {
                selectedEmployee = value;
            }
        }
        public EmployeeViewModel()
        {
            
        }

        public Employee CreateNew()
        {
            var employee = new Employee();
            SelectedEmployee = employee;
            DataConnection.DbContext.Insert(employee);
            return employee;
        }

        public void Remove(Employee employee)
        {
            DataConnection.DbContext.Delete(employee);
        }

        public void ConfirmChanges()
        {
            DataConnection.DbContext.SaveChanges();
        }
    }

    /// <summary>
    /// Interaction logic for ManageEployeeControl.xaml
    /// </summary>
    public partial class ManageEmployeeControl : UserControl
    {
        public EmployeeViewModel ViewModel = new EmployeeViewModel();

        public ManageEmployeeControl()
        {
            InitializeComponent();
            DataConnection.DbContext.Employees.Load();
            list.ItemsSource = DataConnection.DbContext.Employees.Local;
            LoadTypeCombobox.ItemsSource = Enum.GetValues(typeof(LoadTypes)).OfType<LoadTypes>().ToList();
        }


        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CreateNew();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ConfirmChanges();
        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem is Employee)
            {
                Employee employee = (Employee)list.SelectedItem;
                ViewModel.Remove(employee);
            }
        }
    }
}
