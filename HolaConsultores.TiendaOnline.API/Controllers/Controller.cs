using HolaConsultores.TiendaOnline.Domain.Interfaces.IControllers;
using HolaConsultores.TiendaOnline.Domain.Resources.Size;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HolaConsultores.TiendaOnline.API.Controllers
{
    [Authorize]
    public class Controller<IService> : ControllerBase 
    {
        public readonly IService _service;
        public Controller(IService service)
        {
            _service = service;
        }
    }
}
