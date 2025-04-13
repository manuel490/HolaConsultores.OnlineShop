using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Infraestructure.Context;
using HolaConsultores.OnlineShop.Infraestructure.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace HolaConsultores.OnlineShop.Infraestructure.Repositories.Product
{
    public class ProductRepository : Repository, IRepository<ProductModel>
    {
        public ProductRepository(MyContext context) : base(context)
        {
        }

        #region GET
        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Colors)
                                          .ThenInclude(pC => pC.Color)
                                          .Include(p => p.Sizes)
                                          .ThenInclude(pS => pS.Size)
                                          .ToListAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync(int offset, int limit)
        {
            return await _context.Products.Include(p => p.Colors)
                                          .ThenInclude(pC => pC.Color)
                                          .Include(p => p.Sizes)
                                          .ThenInclude(pS => pS.Size)
                                          .Skip(offset)
                                          .Take(limit)
                                          .ToListAsync();
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Colors)
                                          .ThenInclude(pC => pC.Color)
                                          .Include(p => p.Sizes)
                                          .ThenInclude(pS => pS.Size)
                                          .Where(p => p.Id == id)
                                          .FirstAsync();
        }

        #endregion

        #region ADD
        public async Task<ProductModel> AddAsync(ProductModel obj)
        {
            try
            {
                var result = await _context.Products.AddAsync(obj);
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
        public async Task<ProductModel> DeleteAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                _context.Products.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error has been occurred during the operation: {ex.Message}");
            }
        }
        #endregion

        #region UPDATE
        public async Task<ProductModel> UpdateAsync(ProductModel obj)
        {
            try
            {
                var result = await GetByIdAsync(obj.Id);
                result.Price = obj.Price;
                result.Description = obj.Description;
                _context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error has been occurred during the operation: {ex.Message}");
            }
        }
        #endregion
    }
}
