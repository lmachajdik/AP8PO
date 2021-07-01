using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace AP8PO.UserControls
{
    /// <summary>
    /// Interaction logic for SendEmailDialog.xaml
    /// </summary>
    public partial class SendEmailDialog : Window
    {
		public SendEmailDialog()
		{
			InitializeComponent();
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			if (IsValid(Email))
				this.DialogResult = true;
			else
				MessageBox.Show($"{Email} is not a valid email!", "Invalid email", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		public bool IsValid(string emailaddress)
		{
			try
			{
				MailAddress m = new MailAddress(emailaddress);

				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			txtEmail.SelectAll();
			txtEmail.Focus();
		}

		public string Email
		{
			get { return txtEmail.Text; }
		}
	}
}
