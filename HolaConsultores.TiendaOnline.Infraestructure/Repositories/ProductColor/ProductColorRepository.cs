using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IRepositories;
using HolaConsultores.TiendaOnline.Infraestructure.Context;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HolaConsultores.TiendaOnline.Infraestructure.Repositories.ProductColor
{
    public class ProductColorRepository :Repository, IRepository<ProductColorModel>
    {
        public ProductColorRepository(MyContext context) : base(context)
        {
        }

        #region GET (Not implemented)
        public Task<IEnumerable<ProductColorModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductColorModel>> GetAllAsync(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<ProductColorModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ADD
        public async Task<ProductColorModel> AddAsync(ProductColorModel obj)
        {
            try
            {
                var result = await _context.ProductColors.AddAsync(obj);
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
        public async Task<ProductColorModel> DeleteAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                _context.ProductColors.Remove(result);
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
        public Task<ProductColorModel> UpdateAsync(ProductColorModel obj)
        {
            throw new NotImplementedException();
        }
        #endregion
        
    }
}
