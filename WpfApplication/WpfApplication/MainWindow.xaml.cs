using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfApplication.Data;
using WpfApplication.Model;
using WpfApplication.UserApp;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginWindow _loginWindow;
        private DataRequest dataRequest = new DataRequest();
        public MainWindow()
        {
            InitializeComponent();

            using (DataUsers db = new DataUsers())
            {
                User user = db.Users.Find("admin");
                if (user == null)
                {
                    db.Users.Add(new User() { Login = "admin", Password = "admin", Role = UserRoles.Administrator });
                    db.Users.Add(new User() { Login = "user", Password = "user", Role = UserRoles.Manager});
                    db.SaveChanges();
                }
            }

            btnMainLogin.Click += btnMainLogin_Click;
            _loginWindow = new LoginWindow();
            _loginWindow.btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(_loginWindow.GetOk())
            {
                dataRequests.ItemsSource = dataRequest.GetRequests();

                if (_loginWindow.GetStatus() == UserRoles.Administrator)
                {
                    
                }
                else
                {
                    
                }
            }
        }

        private void btnMainLogin_Click(object sender, RoutedEventArgs e)
        {
            _loginWindow.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Request request = (Request)dataRequests.SelectedItem;
            dataRequest.Update(request);
        }
    }
}
