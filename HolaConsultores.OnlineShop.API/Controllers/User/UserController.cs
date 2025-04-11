using HolaConsultores.OnlineShop.Domain.Interfaces.IControllers;
using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.User;
using HolaConsultores.OnlineShop.Domain.Resources.Size;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolaConsultores.OnlineShop.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller<IUserService<UserResource, UserResource>>, IController<UserResource, UserResource>
    {
        public UserController(IUserService<UserResource, UserResource> service) : base(service)
        {
        }

        #region GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResource>>> Get()
        {
            var result = await _service.GetAllAsync();

            return result != null ? Ok(result) : NotFound();
        }
        [HttpGet("{offset}/{limit}")]
        public async Task<ActionResult<IEnumerable<UserResource>>> Get(int offset, int limit)
        {
            var result = await _service.GetAllAsync(offset, limit);
            return result != null ? Ok(result) : NotFound();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResource>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }
        #endregion

        #region ADD
        [HttpPost]
        public async Task<ActionResult<UserResource>> Post(UserResource resource)
        {
            var result = await _service.AddAsync(resource);
            return Ok(result);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserResource>> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result != null ? Ok(result) : NotFound();
        }
        #endregion

        #region UPDATE
        [HttpPut]
        public async Task<ActionResult<UserResource>> Put(UserResource resource)
        {
            var result = await _service.UpdateAsync(resource);
            return result != null ? Ok(result) : NotFound();
        }
        #endregion

    }
}
