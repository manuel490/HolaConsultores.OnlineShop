using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using HolaConsultores.OnlineShop.Mappers.ProductColor;
using HolaConsultores.OnlineShop.Domain.Resources.ProductColor;
using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Infraestructure.Entities.ProductColor;

namespace HolaConsultores.OnlineShop.Services.ProductColor
{
    public class ProductColorService : Service<IRepository<ProductColorModel>>, IService<ProductColorResource, ProductColorResource>
    {
        public ProductColorService(IRepository<ProductColorModel> repository) : base(repository)
        {
        }

        #region GET
        public async Task<IEnumerable<ProductColorResource>> GetAllAsync()
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

        public async Task<IEnumerable<ProductColorResource>> GetAllAsync(int offset, int limit)
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

        public async Task<ProductColorResource> GetByIdAsync(int id)
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
        public async Task<ProductColorResource> AddAsync(ProductColorResource obj)
        {
            try
            {
                var result = await _repository.AddAsync(obj.ToModel());
                return result.ToResource();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding {ex}");
            }
        }
        #endregion

        #region DELETE
        public async Task<ProductColorResource> DeleteAsync(int id)
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

        #region UPDATE (Not implemented)
        public async Task<ProductColorResource> UpdateAsync(ProductColorResource obj)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
