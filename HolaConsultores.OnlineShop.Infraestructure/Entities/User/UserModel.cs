using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.OnlineShop.Infraestructure.Entities.User
{
    public class UserModel
    {
        public UserModel()
        {
        }

        public UserModel(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public UserModel(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
