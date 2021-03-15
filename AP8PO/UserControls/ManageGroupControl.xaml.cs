using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ManageGroupControl.xaml
    /// </summary>
    public partial class ManageGroupControl : UserControl
    {
        internal ObservableCollection<Group> Groups { get; set; }

        public ManageGroupControl()
        {
            InitializeComponent();
            list.ItemsSource = Groups;
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
