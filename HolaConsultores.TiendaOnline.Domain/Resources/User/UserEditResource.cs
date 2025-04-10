using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Domain.Resources.User
{
    public class UserEditResource
    {
        public UserEditResource()
        {
        }

        public UserEditResource(string password)
        {
            Password = password;
        }

        public UserEditResource(int id, string password)
        {
            Id = id;
            Password = password;
        }

        public int Id { get; set; }
        public required string Password { get; set; }
    }
}
