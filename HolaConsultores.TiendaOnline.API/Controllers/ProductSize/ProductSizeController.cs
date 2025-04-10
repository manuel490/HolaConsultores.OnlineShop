using HolaConsultores.TiendaOnline.Domain.Interfaces.IControllers;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IServices;
using HolaConsultores.TiendaOnline.Domain.Resources.ProductSize;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolaConsultores.TiendaOnline.API.Controllers.ProductSize
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeController : Controller<IService<ProductSizeResource, ProductSizeResource>>, IController<ProductSizeResource, ProductSizeResource>
    {
        public ProductSizeController(IService<ProductSizeResource, ProductSizeResource> service) : base(service)
        {
        }

        #region GET
        [NonAction]
        public async Task<ActionResult<IEnumerable<ProductSizeResource>>> Get()
        {
            throw new NotImplementedException();
        }
        [NonAction]
        public async Task<ActionResult<IEnumerable<ProductSizeResource>>> Get(int offset, int limit)
        {
            throw new NotImplementedException();
        }
        [NonAction]
        public async Task<ActionResult<ProductSizeResource>> GetById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ADD
        [HttpPost]
        public async Task<ActionResult<ProductSizeResource>> Post(ProductSizeResource resource)
        {
            var result = await _service.AddAsync(resource);
            return Ok(result);
        }
        #endregion

        #region DELETE
        [HttpDelete]
        public async Task<ActionResult<ProductSizeResource>> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }
        #endregion

        #region UPDATE
        [NonAction]
        public async Task<ActionResult<ProductSizeResource>> Put(ProductSizeResource resource)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
