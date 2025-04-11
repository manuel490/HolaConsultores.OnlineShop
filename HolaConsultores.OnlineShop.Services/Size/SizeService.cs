using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.Size;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using HolaConsultores.OnlineShop.Domain.Resources.Product;
using HolaConsultores.OnlineShop.Infraestructure.Entities;
using HolaConsultores.OnlineShop.Mappers.Color;
using HolaConsultores.OnlineShop.Mappers.Product;
using HolaConsultores.OnlineShop.Mappers.Size;

namespace HolaConsultores.OnlineShop.Services.Size
{
    public class SizeService : Service<IRepository<SizeModel>>, IService<SizeResource, SizeInputResource>
    {
        public SizeService(IRepository<SizeModel> repository) : base(repository)
        {
        }

        #region GET
        public async Task<IEnumerable<SizeResource>> GetAllAsync()
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

        public async Task<IEnumerable<SizeResource>> GetAllAsync(int offset, int limit)
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

        public async Task<SizeResource> GetByIdAsync(int id)
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
        public async Task<SizeResource> AddAsync(SizeInputResource obj)
        {
            try
            {
                var resource = new SizeResource(obj.Name);
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
        public async Task<SizeResource> DeleteAsync(int id)
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
        public async Task<SizeResource> UpdateAsync(SizeInputResource obj)
        {
            try
            {
                var resource = new SizeResource(obj.Id, obj.Name);
                var result = await _repository.UpdateAsync(resource.ToModel());
                return result.ToResource();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating {ex}");
            }
        }
    }
    #endregion
}
