using System.Windows;
using GerenciamentoEstoque.Context;
using GerenciamentoEstoque.Model;

namespace GerenciamentoEstoque
{
    /// <summary>
    /// Lógica interna para AddUser.xaml
    /// </summary>
    public partial class loginAdmin : Window
    {
        public loginAdmin()
        {
            InitializeComponent();
        }
        private void Open(object s, RoutedEventArgs e)
        {
            using (UsersContext context = new UsersContext())
            {
                UsersModel UserIsAdmin = new UsersModel(UserTxt.Text, PassTxt.Password);

                if (VerificarUsuario(UserIsAdmin) == false)
                {
                    MessageBox.Show("Você não tem autorização para acessar essa área!");
                    return;
                }
                else
                {
                    AddUser addUser = new AddUser();
                    addUser.Show();
                    this.Close();
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
