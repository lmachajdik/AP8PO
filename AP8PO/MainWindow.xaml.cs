using AP8PO.Converters;
using AP8PO.Database.Models;
using AP8PO.UserControls;
using Microsoft.Win32;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
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

namespace AP8PO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataConnection.CreateNewContext();

        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if ((DataConnection.DbContext.Courses.Local.Count == 0) && //database empty, no need to save
                (DataConnection.DbContext.Employees.Local.Count == 0) &&
                (DataConnection.DbContext.Groups.Local.Count == 0) &&
                (DataConnection.DbContext.CourseCommits.Local.Count == 0))
            {
                MessageBox.Show("Cannot save empty database.");
                return;
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            DataConnection.DbContext.SaveChanges();
            var spd = new SaveFileDialog();
            spd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm | All files|*.*";
            if (spd.ShowDialog().GetValueOrDefault() == true)
            {
                try
                {
                    DataTable coursesTable = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(DataConnection.DbContext.Courses.Local), (typeof(DataTable)));
                    DataTable employeesTable = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(DataConnection.DbContext.Employees.Local), (typeof(DataTable)));
                    DataTable groupTable = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(DataConnection.DbContext.Groups.Local), (typeof(DataTable)));
                    DataTable courseCommitsTable = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(DataConnection.DbContext.CourseCommits.Local), (typeof(DataTable)));

                    FileInfo filePath = new FileInfo(spd.FileName);

                    if (File.Exists(spd.FileName))
                        File.Delete(spd.FileName);

                    using (var excelPack = new ExcelPackage(filePath))
                    {
                        if (DataConnection.DbContext.Courses.Local.Count != 0)
                        {
                            var cws = excelPack.Workbook.Worksheets.Add("Courses");
                            cws.Cells.LoadFromDataTable(coursesTable, true, OfficeOpenXml.Table.TableStyles.Light8);
                        }
                        if (DataConnection.DbContext.Employees.Local.Count != 0)
                        {
                            var ews = excelPack.Workbook.Worksheets.Add("Employees");
                            ews.Cells.LoadFromDataTable(employeesTable, true, OfficeOpenXml.Table.TableStyles.Light8);
                        }
                        if (DataConnection.DbContext.Groups.Local.Count != 0)
                        {
                            var gws = excelPack.Workbook.Worksheets.Add("Groups");
                            gws.Cells.LoadFromDataTable(groupTable, true, OfficeOpenXml.Table.TableStyles.Light8);
                        }
                        if (DataConnection.DbContext.CourseCommits.Local.Count != 0)
                        {
                            var cmws = excelPack.Workbook.Worksheets.Add("CourseCommits");
                            cmws.Cells.LoadFromDataTable(courseCommitsTable, true, OfficeOpenXml.Table.TableStyles.Light8);
                        }

                        excelPack.Save();
                   }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Unexpected message occure. Error message: {ex.Message}");
                }
            }
        }
                
        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var opd = new OpenFileDialog();
            opd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm | All files|*.*";
            if (opd.ShowDialog().GetValueOrDefault() == true)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                
                using (var excelPack = new ExcelPackage())
                {
                    //Load excel stream
                    using (var stream = File.OpenRead(opd.FileName))
                    {
                        excelPack.Load(stream);
                        DataConnection.DbContext.Courses.Local.Clear();
                        DataConnection.DbContext.Employees.Local.Clear();
                        DataConnection.DbContext.Groups.Local.Clear();
                        DataConnection.DbContext.CourseCommits.Local.Clear();

                        foreach (var ws in excelPack.Workbook.Worksheets)
                        {
                            if(ws.Name == "Courses")
                            {
                                var ret = get<IEnumerable<Course>>(ws, true);  
                                DataConnection.DbContext.Courses.AddRange(ret);
                            }

                            if (ws.Name == "Employees")
                            {
                                var ret = get<IEnumerable<Employee>>(ws, true);
                                DataConnection.DbContext.Employees.AddRange(ret);
                            }

                            if (ws.Name == "Groups")
                            {
                                var ret = get<IEnumerable<Group>>(ws, true);
                                DataConnection.DbContext.Groups.AddRange(ret);
                            }                            
                            
                            if (ws.Name == "CourseCommits")
                            {
                                var ret = get<IEnumerable<CourseCommit>>(ws, true);
                                DataConnection.DbContext.CourseCommits.AddRange(ret);
                            }
                        }     
                    }
                }
                DataConnection.DbContext.SaveChanges();
            }
        }


        private dynamic get<T>(ExcelWorksheet ws, bool hasHeader)
        {
            var a = read(ws, hasHeader);
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(a), new BooleanJsonConverter());
        }

        private DataTable read(ExcelWorksheet ws, bool hasHeader)
        {
            DataTable excelasTable = new DataTable();
            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
            {
                //Get colummn details
                if (!string.IsNullOrEmpty(firstRowCell.Text))
                {
                    string firstColumn = string.Format("Column {0}", firstRowCell.Start.Column);
                    excelasTable.Columns.Add(hasHeader ? firstRowCell.Text : firstColumn);
                }
            }
            var startRow = hasHeader ? 2 : 1;
            //Get row details
            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                var wsRow = ws.Cells[rowNum, 1, rowNum, excelasTable.Columns.Count];
                DataRow row = excelasTable.Rows.Add();
                foreach (var cell in wsRow)
                {
                    row[cell.Start.Column - 1] = cell.Text;
                }
            }
            return excelasTable;
        }

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            var itab = (tabControl.SelectedItem as TabItem).Content as ITab;
            itab.AddRecord();
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var itab = (tabControl.SelectedItem as TabItem).Content as ITab;
            itab.DeleteSelectedRecord();
        }
    }
}
