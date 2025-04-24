using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoEstoque.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstoque.Context
{
    internal class UsersContext : DbContext
    {
        public DbSet<UsersModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=users.sqlite");
        }
    }
}
