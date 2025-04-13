using HolaConsultores.OnlineShop.Domain.Interfaces.IControllers;
using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.ProductSize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolaConsultores.OnlineShop.API.Controllers.ProductSize
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeController : Controller<IService<ProductSizeResource, ProductSizeResource>>, IController<ProductSizeResource, ProductSizeResource>
    {
        public ProductSizeController(IService<ProductSizeResource, ProductSizeResource> service) : base(service)
        {
        }

        #region GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSizeResource>>> Get()
        {
            var result = await _service.GetAllAsync();

            return result != null ? Ok(result) : NotFound();
        }
        [HttpGet("{offset}/{limit}")]
        public async Task<ActionResult<IEnumerable<ProductSizeResource>>> Get(int offset, int limit)
        {
            var result = await _service.GetAllAsync(offset, limit);
            return result != null ? Ok(result) : NotFound();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSizeResource>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
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
