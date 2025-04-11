using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Resources.Product;
using HolaConsultores.OnlineShop.Infraestructure.Context;
using HolaConsultores.OnlineShop.Infraestructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using HolaConsultores.OnlineShop.Domain.Interfaces.IControllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HolaConsultores.OnlineShop.API.Controllers.Color
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ColorController : Controller<IService<ColorResource, ColorInputResource>>, IController<ColorResource, ColorInputResource>
    {
        public ColorController(IService<ColorResource, ColorInputResource> service) : base(service)
        {
        }

        #region GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorResource>>> Get()
        {
            var result = await _service.GetAllAsync();

            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{offset}/{limit}")]
        public async Task<ActionResult<IEnumerable<ColorResource>>> Get(int offset, int limit)
        {
            var result = await _service.GetAllAsync(offset, limit);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColorResource>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result): NotFound();
        }
        #endregion

        #region ADD
        [HttpPost]
        public async Task<ActionResult<ColorResource>> Post(ColorInputResource resource)
        {
            var result = await _service.AddAsync(resource);
            return Ok(result);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<ColorResource>> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result != null ? Ok(result) : NotFound();
        }
        #endregion

        #region UPDATE
        [HttpPut]
        public async Task<ActionResult<ColorResource>> Put(ColorInputResource resource)
        {
            var result = await _service.UpdateAsync(resource);
            return result != null ? Ok(result) : NotFound();
        }
        #endregion

    }
}
