using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.ProductSize;
using HolaConsultores.OnlineShop.Domain.Resources.ProductColor;
using HolaConsultores.OnlineShop.Infraestructure.Entities;
using HolaConsultores.OnlineShop.Mappers.ProductSize;

namespace HolaConsultores.OnlineShop.Services.ProductSize
{
    public class ProductSizeService : Service<IRepository<ProductSizeModel>>, IService<ProductSizeResource, ProductSizeResource>
    {
        public ProductSizeService(IRepository<ProductSizeModel> repository) : base(repository)
        {
        }

        #region GET (Not implemented)
        public async Task<IEnumerable<ProductSizeResource>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductSizeResource>> GetAllAsync(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductSizeResource> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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
