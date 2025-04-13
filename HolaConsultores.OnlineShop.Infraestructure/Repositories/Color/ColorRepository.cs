using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Infraestructure.Context;
using HolaConsultores.OnlineShop.Infraestructure.Entities.Color;
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
                                        .FirstOrDefaultAsync();
        }

        #endregion

        #region ADD
        public async Task<ColorModel> AddAsync(ColorModel obj)
        {
            try
            {
                var colors = await GetAllAsync();

                if (!colors.Any(x => x.Name.Equals(obj.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    var result = await _context.Colors.AddAsync(obj);
                    _context.SaveChanges();

                    return result.Entity;
                }else
                {
                    throw new Exception("This color already exist.");
                }
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
                if (result != null)
                {
                    _context.Colors.Remove(result);
                    await _context.SaveChangesAsync();
                    return result;
                } else
                {
                    throw new Exception("There are not any color with the specified id");
                }
                
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
                if (result != null)
                {
                    result.Name = obj.Name;
                    _context.SaveChanges();
                    return result;
                } else
                {
                    throw new Exception("There are not any color with the specified id");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error has been occurred during the operation: {ex.Message}");
            }
        }
        #endregion
    }
}
