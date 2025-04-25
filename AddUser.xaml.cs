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
                bool isChecked = AdminCheckBox.IsChecked == true ? true : false;
                UsersModel newUser = new UsersModel(UserTxt.Text, PassTxt.Password, isChecked);

                if(VerificarUsuario(newUser) == false)
                {
                    // Adiciona o usuário com permissão admin            
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    MessageBox.Show("Usuário Registrado com sucesso!");
                    return;
                }
                else
                {
                    MessageBox.Show("Usuário já existe!");
                    return;
                }                                
             }
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool VerificarUsuario(UsersModel user)
        {
            using (UsersContext context = new UsersContext())
            {
                bool userFound = context.Users.Any(context => context.Username == UserTxt.Text &&
                                                                context.Password == PassTxt.Password);
                return userFound;
            }
        }
    }
}
