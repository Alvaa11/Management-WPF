using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEstoque.Model
{
    internal class UsersModel
    {
        public UsersModel() { }
        public UsersModel(string user, string pass, bool adm)
        {
            Username = user;
            Password = pass;
            isAdmin = adm;
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool isAdmin { get; set; }
    }
}
