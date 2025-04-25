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
using System.Windows.Shapes;
using GerenciamentoEstoque.Context;
using GerenciamentoEstoque.Model;

namespace GerenciamentoEstoque
{
    /// <summary>
    /// Lógica interna para AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }
        private void Register(object s, RoutedEventArgs e)
        {
            using (UsersContext context = new UsersContext())
            {
                if(AdminCheckBox.IsChecked == true)
                {
                    // Adiciona o usuário com permissão admin

                    UsersModel newUser = new UsersModel(UserTxt.Text, PassTxt.Password, true);
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    MessageBox.Show("Usuário Registrado com sucesso!");
                }
                else
                {
                    // Adiciona o usuário sem permissão admin

                    UsersModel newUser = new UsersModel(UserTxt.Text, PassTxt.Password, false);
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    MessageBox.Show("Usuário Registrado com sucesso!");
                }

            }
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
