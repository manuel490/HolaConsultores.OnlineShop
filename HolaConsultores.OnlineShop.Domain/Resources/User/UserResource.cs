using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.OnlineShop.Domain.Resources.User
{
    public class UserResource
    {
        public UserResource()
        {
        }

        public UserResource(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public UserResource(int id, string name, string email, string password)
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
