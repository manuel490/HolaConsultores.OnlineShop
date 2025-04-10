using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Domain.Resources.User
{
    public class UserResource
    {
        public UserResource()
        {
        }

        public UserResource(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public UserResource(int id, string email, string password)
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
