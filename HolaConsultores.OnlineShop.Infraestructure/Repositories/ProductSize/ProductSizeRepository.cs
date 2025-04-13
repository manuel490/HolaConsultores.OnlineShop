using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Infraestructure.Context;
using HolaConsultores.OnlineShop.Infraestructure.Entities.ProductSize;
using Microsoft.EntityFrameworkCore;

namespace HolaConsultores.OnlineShop.Infraestructure.Repositories.ProductSize
{
    public class ProductSizeRepository : Repository, IRepository<ProductSizeModel>
    {
        public ProductSizeRepository(MyContext context) : base(context)
        {
        }

        #region GET
        public async Task<IEnumerable<ProductSizeModel>> GetAllAsync()
        {
            return await _context.ProductSizes.ToListAsync();
        }

        public async Task<IEnumerable<ProductSizeModel>> GetAllAsync(int offset, int limit)
        {
            return await _context.ProductSizes.Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<ProductSizeModel> GetByIdAsync(int id)
        {
            return await _context.ProductSizes.Where(pC => pC.Id == id).FirstOrDefaultAsync();
        }
        #endregion

        #region ADD
        public async Task<ProductSizeModel> AddAsync(ProductSizeModel obj)
        {
            try
            {
                var productSize = await GetAllAsync();

                if (!productSize.Any(x => x.ProductId == obj.ProductId && x.SizeId == obj.SizeId))
                {
                    var result = await _context.ProductSizes.AddAsync(obj);
                    _context.SaveChanges();
                    return result.Entity;
                }
                else
                {
                    throw new Exception("This product already have this size.");
                }
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

                if (result != null)
                {
                    _context.ProductSizes.Remove(result);
                    await _context.SaveChangesAsync();
                    return result;
                }
                else
                {
                    throw new Exception("There are not any productSize with the specified id");
                }
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
