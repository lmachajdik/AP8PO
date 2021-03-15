using AP8PO.Database.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            var employee = new Employee()
            {
                Name = "New"
            };
            
            SelectedEmployee = employee;
            DataConnection.DbContext.Insert(employee);
            ConfirmChanges();
            return employee;
        }

        public void Remove(Employee employee)
        {
            DataConnection.DbContext.Delete(employee);
            ConfirmChanges();

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
            list.SelectionChanged += (object sender, SelectionChangedEventArgs e) =>
            {
                ViewModel.SelectedEmployee = ((ListView)(sender)).SelectedItem as Employee;
                formGrid.DataContext = ViewModel.SelectedEmployee;
            };

            LoadTypeCb.ItemsSource = Enum.GetValues(typeof(LoadTypes)).Cast<LoadTypes>();
            LoadTypeCb.SelectionChanged += (object sender, SelectionChangedEventArgs e) =>
            {
                LoadTypes loadType = (LoadTypes)Enum.Parse(typeof(LoadTypes), LoadTypeCb.SelectedItem?.ToString());
                LoadTypeOtherPercentualTb.IsEnabled = loadType == LoadTypes.Other;

                if (loadType != LoadTypes.Other)
                    LoadTypeOtherPercentualTb.Text = Convert.ToString((int)loadType);
            };
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CreateNew();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ConfirmChanges();
        }

        private void ContextMenuDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = (Employee)((sender as MenuItem).DataContext);
            ViewModel.Remove(employee);
        }
    }
}
