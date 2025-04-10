using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IRepositories;
using HolaConsultores.TiendaOnline.Infraestructure.Context;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HolaConsultores.TiendaOnline.Infraestructure.Repositories.ProductSize
{
    public class ProductSizeRepository : Repository, IRepository<ProductSizeModel>
    {
        public ProductSizeRepository(MyContext context) : base(context)
        {
        }

        #region GET (Not implemented)
        public Task<IEnumerable<ProductSizeModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductSizeModel>> GetAllAsync(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<ProductSizeModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ADD
        public async Task<ProductSizeModel> AddAsync(ProductSizeModel obj)
        {
            try
            {
                var result = await _context.ProductSizes.AddAsync(obj);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error has been occurred during the operation: {ex.Message}");
            }
        }
        #endregion

        #region DELETE
        public async Task<ProductSizeModel> DeleteAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                _context.ProductSizes.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error has been occurred during the operation: {ex.Message}");
            }
        }
        #endregion

        #region UPDATE (Not implemented)
        public Task<ProductSizeModel> UpdateAsync(ProductSizeModel obj)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
