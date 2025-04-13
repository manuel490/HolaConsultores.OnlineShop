using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.ProductSize;
using HolaConsultores.OnlineShop.Domain.Resources.ProductColor;
using HolaConsultores.OnlineShop.Mappers.ProductSize;
using HolaConsultores.OnlineShop.Infraestructure.Entities.ProductSize;

namespace HolaConsultores.OnlineShop.Services.ProductSize
{
    public class ProductSizeService : Service<IRepository<ProductSizeModel>>, IService<ProductSizeResource, ProductSizeResource>
    {
        public ProductSizeService(IRepository<ProductSizeModel> repository) : base(repository)
        {
        }

        #region GET
        public async Task<IEnumerable<ProductSizeResource>> GetAllAsync()
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

        public async Task<IEnumerable<ProductSizeResource>> GetAllAsync(int offset, int limit)
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

        public async Task<ProductSizeResource> GetByIdAsync(int id)
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
        public async Task<ProductSizeResource> AddAsync(ProductSizeResource obj)
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
        public async Task<ProductSizeResource> DeleteAsync(int id)
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
        public async Task<ProductSizeResource> UpdateAsync(ProductSizeResource obj)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
