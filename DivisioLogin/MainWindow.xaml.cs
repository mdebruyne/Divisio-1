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

        private void OpenLogin(object sender, RoutedEventArgs e)
        {
            Login_Window login = new Login_Window();
            this.Visibility = Visibility.Hidden;
            login.Show();
        }

        private void OpenRegister(object sender, RoutedEventArgs e)
        {
            Register_Window register = new Register_Window();
            this.Visibility = Visibility.Hidden;
            register.Show();
        }
    }
}
