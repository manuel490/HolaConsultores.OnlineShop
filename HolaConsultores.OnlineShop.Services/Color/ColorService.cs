using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using HolaConsultores.OnlineShop.Domain.Resources.Product;
using HolaConsultores.OnlineShop.Infraestructure.Entities.Color;
using HolaConsultores.OnlineShop.Mappers.Color;
using HolaConsultores.OnlineShop.Mappers.Product;

namespace HolaConsultores.OnlineShop.Services.Color
{
    public class ColorService : Service<IRepository<ColorModel>>, IService<ColorResource, ColorInputResource>
    {
        public ColorService(IRepository<ColorModel> repository) : base(repository)
        {
        }

        #region GET
        public async Task<IEnumerable<ColorResource>> GetAllAsync()
        {
            try
            {
                return (await _repository.GetAllAsync()).ToList().ToResource();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ColorResource>> GetAllAsync(int offset, int limit)
        {
            try
            {
                return (await _repository.GetAllAsync(offset, limit)).ToList().ToResource();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ColorResource> GetByIdAsync(int id)
        {
            try
            {
                return (await _repository.GetByIdAsync(id)).ToResource();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region ADD
        public async Task<ColorResource> AddAsync(ColorInputResource obj)
        {
            try
            {
                var resource = new ColorResource(obj.Name);
                var result = await _repository.AddAsync(resource.ToModel());
                return result.ToResource();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding {ex}");
            }
        }
        #endregion

        #region DELETE
        public async Task<ColorResource> DeleteAsync(int id)
        {
            try
            {
                return (await _repository.DeleteAsync(id)).ToResource();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting {ex}");
            }
        }
        #endregion

        #region UPDATE
        public async Task<ColorResource> UpdateAsync(ColorInputResource obj)
        {
            try
            {
                var resource = new ColorResource(obj.Id, obj.Name);
                var result = await _repository.UpdateAsync(resource.ToModel());
                return result.ToResource();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating {ex}");
            }
        }
        #endregion

    }
}
