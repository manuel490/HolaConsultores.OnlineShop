using HolaConsultores.OnlineShop.Domain.Interfaces.IControllers;
using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.ProductColor;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using HolaConsultores.OnlineShop.Domain.Resources.Product;
using HolaConsultores.OnlineShop.Domain.Resources.Size;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolaConsultores.OnlineShop.API.Controllers.ProductColor
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductColorController : Controller<IService<ProductColorResource, ProductColorResource>>, IController<ProductColorResource, ProductColorResource>
    {
        public ProductColorController(IService<ProductColorResource, ProductColorResource> service) : base(service)
        {
        }

        #region GET
        [NonAction]
        public Task<ActionResult<IEnumerable<ProductColorResource>>> Get()
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public Task<ActionResult<IEnumerable<ProductColorResource>>> Get(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public Task<ActionResult<ProductColorResource>> GetById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ADD
        [HttpPost]
        public async Task<ActionResult<ProductColorResource>> Post(ProductColorResource resource)
        {
            var result = await _service.AddAsync(resource);
            return Ok(result);
        }
        #endregion

        #region DELETE
        [HttpDelete]
        public async Task<ActionResult<ProductColorResource>> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }
        #endregion

        #region UPDATE
        [NonAction]
        public async Task<ActionResult<ProductColorResource>> Put(ProductColorResource resource)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
