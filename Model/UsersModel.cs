using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoEstoque.Context;

namespace GerenciamentoEstoque.Model
{
    internal class UsersModel
    {
        public UsersModel() { }
        public UsersModel(string user, string pass, int adm = 0)
        {
            Username = user;
            Password = pass;
            isAdmin = adm;
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int isAdmin { get; set; }
    }
}
