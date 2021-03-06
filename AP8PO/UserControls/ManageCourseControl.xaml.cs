﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    public class CourseViewModel : Model
    {
        private Course selectedEmployee;
        public Course SelectedEmployee
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
        public CourseViewModel()
        {

        }

        public Course CreateNew()
        {
            var course = new Course();
            SelectedEmployee = course;
            DataConnection.DbContext.Insert(course);
            return course;
        }

        public void Remove(Course course)
        {
            DataConnection.DbContext.Delete(course);
        }

        public void ConfirmChanges()
        {
            DataConnection.DbContext.SaveChanges();
        }
    }

    /// <summary>
    /// Interaction logic for ManageCourseControl.xaml
    /// </summary>
    public partial class ManageCourseControl : UserControl, ITab
    {
        public CourseViewModel ViewModel = new CourseViewModel();
        public IList<Course> Courses;
        public ManageCourseControl()
        {
            InitializeComponent();
            DataConnection.DbContext.Courses.Load();
            Courses = DataConnection.DbContext.Courses.Local;
            list.ItemsSource = DataConnection.DbContext.Courses.Local;
            list.AutoGeneratedColumns += List_AutoGeneratedColumns;
            ViewModel.ConfirmChanges();

        }

        private void List_AutoGeneratedColumns(object sender, EventArgs e)
        {
            list.Columns[0].Visibility = Visibility.Hidden;
            list.Columns[1].Visibility = Visibility.Hidden;
            list.Columns[4].Header = "Max Students";
            list.Columns[5].Header = "Weeks";
            list.Columns[list.Columns.Count - 1].Visibility = Visibility.Hidden;
        }


        private void DeleteCourseButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedRecord();
        }

        public void AddRecord()
        {
            ViewModel.CreateNew();
        }

        public void DeleteSelectedRecord()
        {
            if (list.SelectedItem is Course)
                ViewModel.Remove(list.SelectedItem as Course);
        }
    }
}
