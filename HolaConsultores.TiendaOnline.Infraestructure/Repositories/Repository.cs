using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Infraestructure.Context;

namespace HolaConsultores.TiendaOnline.Infraestructure.Repositories
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
