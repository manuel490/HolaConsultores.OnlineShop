using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Infraestructure.Context;
using HolaConsultores.OnlineShop.Infraestructure.Entities.ProductColor;
using Microsoft.EntityFrameworkCore;

namespace HolaConsultores.OnlineShop.Infraestructure.Repositories.ProductColor
{
    public class ProductColorRepository :Repository, IRepository<ProductColorModel>
    {
        public ProductColorRepository(MyContext context) : base(context)
        {
        }

        #region GET
        public async Task<IEnumerable<ProductColorModel>> GetAllAsync()
        {
            return await _context.ProductColors.ToListAsync();
        }

        public async Task<IEnumerable<ProductColorModel>> GetAllAsync(int offset, int limit)
        {
            return await _context.ProductColors.Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<ProductColorModel> GetByIdAsync(int id)
        {
            return await _context.ProductColors.Where(pC => pC.Id == id).FirstOrDefaultAsync();
        }
        #endregion

        #region ADD
        public async Task<ProductColorModel> AddAsync(ProductColorModel obj)
        {
            try
            {
               

                var productColors = await GetAllAsync();

                if (!productColors.Any(x => x.ProductId == obj.ProductId && x.ColorId == obj.ColorId))
                {
                    var result = await _context.ProductColors.AddAsync(obj);
                    _context.SaveChanges();
                    return result.Entity;
                }
                else
                {
                    throw new Exception("This product already have this color.");
                }

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
               

                if (result != null)
                {
                    _context.ProductColors.Remove(result);
                    await _context.SaveChangesAsync();
                    return result;
                }
                else
                {
                    throw new Exception("There are not any productColor with the specified id");
                }
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
