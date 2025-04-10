using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HolaConsultores.TiendaOnline.Domain.Resources.Color;
using HolaConsultores.TiendaOnline.Domain.Resources.Size;
using Microsoft.AspNetCore.Mvc;

namespace HolaConsultores.TiendaOnline.Domain.Interfaces.IControllers
{
    public interface IController<R, I>
    {
        public Task<ActionResult<IEnumerable<R>>> Get();
        public Task<ActionResult<IEnumerable<R>>> Get(int offset, int limit);
        public Task<ActionResult<R>> GetById(int id);
        public Task<ActionResult<R>> Post(I resource);
        public Task<ActionResult<R>> Delete(int id);
        public Task<ActionResult<R>> Put(I resource);
    }
}
