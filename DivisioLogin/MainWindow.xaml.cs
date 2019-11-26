using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace DivisioLogin
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

       /* private void OpenLogin(object sender, RoutedEventArgs e)
        {
            Login_Window login = new Login_Window();
            this.Visibility = Visibility.Hidden;
            login.Show();
        }*/

        private void OpenRegister(object sender, RoutedEventArgs e)
        {
            Register_Window register = new Register_Window();
            this.Visibility = Visibility.Hidden;
            register.Show();
        }

        public static string username;
        public static string getusername
        {
            get { return username; }
            set { username = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=MSI;Initial Catalog=Divsio;Integrated Security=True;");
            
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                getusername = TxtUsername.Text;    
                String query = "SELECT COUNT(1) FROM tblUser WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query,sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", TxtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", TxtPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Login_Window login = new Login_Window();
                    this.Visibility = Visibility.Hidden;
                    login.Show();
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Username or password is incorrect.");
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
