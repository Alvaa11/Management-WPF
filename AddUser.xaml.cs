using System.Windows;
using GerenciamentoEstoque.Context;
using GerenciamentoEstoque.Model;

namespace GerenciamentoEstoque
{
    /// <summary>
    /// Lógica interna para AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        UsersModel NewUser = new UsersModel();
        public AddUser()
        {
            InitializeComponent();
            LoadUsers();
            NovoUserGrid.DataContext = NewUser;
        }

        private void LoadUsers()
        {
            using (UsersContext context = new UsersContext())
            {
                var users= context.Users.ToList();
                DataGridUsers.ItemsSource = users;
            }
        }
        private void Register(object s, RoutedEventArgs e)
        {
            using (UsersContext context = new UsersContext())
            {
                if (VerificarUsuario(NewUser) == true)
                {
                    MessageBox.Show("Usuário já existe! Por favor, escolha outro nome de usuário.");
                }
                else
                {
                    int isChecked = AdminCheckBox.IsChecked == true ? 1 : 0;
                    UsersModel newUser = new UsersModel(UserTxt.Text, PassTxt.Password, isChecked);
                    context.Add(newUser);
                    context.SaveChanges();
                    LoadUsers();
                    NovoUserGrid.DataContext = NewUser;
                    MessageBox.Show("Usuário adicionado com sucesso!");
                }
            }
        }
       
        private void RemoveUser(object s, RoutedEventArgs e)
        {
            using (UsersContext context = new UsersContext())
            {
                var UserDelete = (s as FrameworkElement).DataContext as UsersModel;
                context.Remove(UserDelete);
                context.SaveChanges();
                LoadUsers();
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
                bool userFound = context.Users.Any(context => context.Username == UserTxt.Text);
                return userFound;
            }
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
