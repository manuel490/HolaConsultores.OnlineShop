using HolaConsultores.TiendaOnline.Domain.Interfaces.IControllers;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IServices;
using HolaConsultores.TiendaOnline.Domain.Resources.Color;
using HolaConsultores.TiendaOnline.Domain.Resources.Product;
using HolaConsultores.TiendaOnline.Domain.Resources.Size;
using HolaConsultores.TiendaOnline.Infraestructure.Context;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HolaConsultores.TiendaOnline.API.Controllers.Size
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : Controller<IService<SizeResource, SizeInputResource>>, IController<SizeResource, SizeInputResource>
    {
        public SizeController(IService<SizeResource, SizeInputResource> service) : base(service)
        {
        }

        #region GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeResource>>> Get()
        {
            var result = await _service.GetAllAsync();

            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{offset}/{limit}")]
        public async Task<ActionResult<IEnumerable<SizeResource>>> Get(int offset, int limit)
        {
            var result = await _service.GetAllAsync(offset, limit);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SizeResource>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        #endregion

        #region ADD
        [HttpPost]
        public async Task<ActionResult<SizeResource>> Post(SizeInputResource resource)
        {
            var result = await _service.AddAsync(resource);
            return Ok(result);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<SizeResource>> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result != null ? Ok(result) : NotFound();
        }
        #endregion

        #region UPDATE
        [HttpPut]
        public async Task<ActionResult<SizeResource>> Put(SizeInputResource resource)
        {
            var result = await _service.UpdateAsync(resource);
            return result != null ? Ok(result) : NotFound();
        }
        #endregion

    }
}
