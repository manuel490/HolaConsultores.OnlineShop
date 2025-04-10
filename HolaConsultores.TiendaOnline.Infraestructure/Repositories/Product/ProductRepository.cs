using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IRepositories;
using HolaConsultores.TiendaOnline.Infraestructure.Context;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HolaConsultores.TiendaOnline.Infraestructure.Repositories.Product
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
                var product = await _context.Products.AddAsync(obj);
                _context.SaveChanges();
                return product.Entity;
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
                var product = await GetByIdAsync(id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product;
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
                var product = await GetByIdAsync(obj.Id);
                product.Price = obj.Price;
                product.Description = obj.Description;
                _context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error has been occurred during the operation: {ex.Message}");
            }
        }
        #endregion
    }
}
