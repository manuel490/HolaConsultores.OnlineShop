using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IRepositories;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IServices;
using HolaConsultores.TiendaOnline.Domain.Resources.Color;
using HolaConsultores.TiendaOnline.Domain.Resources.Product;
using HolaConsultores.TiendaOnline.Domain.Resources.Size;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using HolaConsultores.TiendaOnline.Mappers.Product;
using HolaConsultores.TiendaOnline.Mappers.Color;
using HolaConsultores.TiendaOnline.Mappers.Size;

namespace HolaConsultores.TiendaOnline.Services.Product
{
    public class ProductService : Service<IRepository<ProductModel>>, IService<ProductResource, ProductInputResource>
    {
        public ProductService(IRepository<ProductModel> repository) : base(repository)
        {
        }

        #region GET
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
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

        public async Task<IEnumerable<ProductResource>> GetAllAsync(int offset, int limit)
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

        public async Task<ProductResource> GetByIdAsync(int id)
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
        public async Task<ProductResource> AddAsync(ProductInputResource obj)
        {
            try
            {
                var resource = new ProductResource(obj.Price, obj.Description);
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
        public async Task<ProductResource> DeleteAsync(int id)
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
        public async Task<ProductResource> UpdateAsync(ProductInputResource obj)
        {
            try
            {
                var resource = new ProductResource(obj.Id, obj.Price, obj.Description);
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
