using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoEstoque.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstoque.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=product.sqlite");
        }
    }
}
