using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Infraestructure.Entities
{
    public class UserModel
    {
        public UserModel()
        {
        }

        public UserModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public UserModel(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
