using HolaConsultores.OnlineShop.Domain.Interfaces.IControllers;
using HolaConsultores.OnlineShop.Domain.Resources.Size;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HolaConsultores.OnlineShop.API.Controllers
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
