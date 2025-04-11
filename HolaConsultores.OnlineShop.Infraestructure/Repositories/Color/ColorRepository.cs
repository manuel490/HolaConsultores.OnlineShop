using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Infraestructure.Context;
using HolaConsultores.OnlineShop.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HolaConsultores.OnlineShop.Infraestructure.Repositories.Color
{
    public class ColorRepository : Repository, IRepository<ColorModel>
    {
        public ColorRepository(MyContext context) : base(context)
        {
        }

        #region GET
        public async Task<IEnumerable<ColorModel>> GetAllAsync()
        {
            return await _context.Colors.Include(c => c.Products)
                                        .ThenInclude(pC => pC.Product)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<ColorModel>> GetAllAsync(int offset, int limit)
        {
            return await _context.Colors.Include(c => c.Products)
                                        .ThenInclude(pC => pC.Product)
                                        .Skip(offset)
                                        .Take(limit)
                                        .ToListAsync();
        }

        public async Task<ColorModel> GetByIdAsync(int id)
        {
            return await _context.Colors.Include(c => c.Products)
                                        .ThenInclude(pC => pC.Product)                                        
                                        .Where(c => c.Id == id)
                                        .FirstAsync();
        }

        #endregion

        #region ADD
        public async Task<ColorModel> AddAsync(ColorModel obj)
        {
            try
            {
                var result = await _context.Colors.AddAsync(obj);
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
        public async Task<ColorModel> DeleteAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                _context.Colors.Remove(result);
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
        public async Task<ColorModel> UpdateAsync(ColorModel obj)
        {
            try
            {
                var result = await GetByIdAsync(obj.Id);                
                result.Name = obj.Name;
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
