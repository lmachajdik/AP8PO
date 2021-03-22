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
            list.SelectionChanged += (object sender, SelectionChangedEventArgs e) =>
            {
              //  ViewModel.SelectedEmployee = ((Dt)(sender)).SelectedItem as Employee;
                //formGrid.DataContext = ViewModel.SelectedEmployee;
            };

            /*LoadTypeCb.ItemsSource = Enum.GetValues(typeof(LoadTypes)).Cast<LoadTypes>();
            LoadTypeCb.SelectionChanged += (object sender, SelectionChangedEventArgs e) =>
            {
                if (list.SelectedItem == null)
                    return;

                LoadTypes loadType = (LoadTypes)Enum.Parse(typeof(LoadTypes), LoadTypeCb.SelectedItem?.ToString());
                bool isLoadTypeOther = loadType == LoadTypes.Other;

                if (isLoadTypeOther == false)
                    LoadTypeOtherPercentualTb.Text = Convert.ToString((int)loadType);

                LoadTypeOtherPercentualTb.IsEnabled = isLoadTypeOther;
            };*/
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
            Employee employee = (Employee)((sender as Button).DataContext);
            ViewModel.Remove(employee);
        }
    }
}
