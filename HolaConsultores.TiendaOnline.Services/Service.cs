using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Services
{
    public class Service<IRepository>
    {
        public readonly IRepository _repository;
        public Service(IRepository repository) 
        {
            _repository = repository;
        }
    }
}
