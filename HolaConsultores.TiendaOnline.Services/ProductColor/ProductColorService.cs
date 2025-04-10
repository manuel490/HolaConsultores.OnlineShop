using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IRepositories;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IServices;
using HolaConsultores.TiendaOnline.Domain.Resources.ProductColor;
using HolaConsultores.TiendaOnline.Domain.Resources.Color;
using HolaConsultores.TiendaOnline.Mappers.ProductColor;

namespace HolaConsultores.TiendaOnline.Services.ProductColor
{
    public class ProductColorService : Service<IRepository<ProductColorModel>>, IService<ProductColorResource, ProductColorResource>
    {
        public ProductColorService(IRepository<ProductColorModel> repository) : base(repository)
        {
        }

        #region GET (Not implemented)
        public async Task<IEnumerable<ProductColorResource>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductColorResource>> GetAllAsync(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductColorResource> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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
