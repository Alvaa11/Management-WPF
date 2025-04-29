using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;
using GerenciamentoEstoque.Context;
using GerenciamentoEstoque.Model;

namespace GerenciamentoEstoque
{
    /// <summary>
    /// Lógica interna para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public void OnSubmit(object s, RoutedEventArgs e)
        {
            using (UsersContext context = new UsersContext())
            {
                bool userFound = context.Users.Any(context => context.Username == UserTxt.Text &&
                                                            context.Password == PassTxt.Password);
                if (userFound)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos.");
                }
            }
        }

        public void OnClose(object s, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {

                this.DragMove();
            }
        }
    }
}
