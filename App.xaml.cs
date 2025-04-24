using System.Configuration;
using System.Data;
using System.Windows;
using GerenciamentoEstoque.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GerenciamentoEstoque
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade databaseUsers = new DatabaseFacade(new UsersContext());
            databaseUsers.EnsureCreated();
            DatabaseFacade databaseProduct = new DatabaseFacade(new ProductContext());
            databaseProduct.EnsureCreated();
        }
    }

}
