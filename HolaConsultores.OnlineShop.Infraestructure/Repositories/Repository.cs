using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Infraestructure.Context;

namespace HolaConsultores.OnlineShop.Infraestructure.Repositories
{
    public class Repository
    {
        public readonly MyContext _context;

        public Repository(MyContext context)
        {
            _context = context;
        }
    }
}
