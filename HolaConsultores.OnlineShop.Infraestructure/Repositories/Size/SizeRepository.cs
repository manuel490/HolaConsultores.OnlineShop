using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Infraestructure.Context;
using HolaConsultores.OnlineShop.Infraestructure.Entities.Size;
using Microsoft.EntityFrameworkCore;

namespace HolaConsultores.OnlineShop.Infraestructure.Repositories.Size
{
    public class SizeRepository : Repository, IRepository<SizeModel>
    {
        public SizeRepository(MyContext context) : base(context)
        {
        }

        #region GET
        public async Task<IEnumerable<SizeModel>> GetAllAsync()
        {
            return await _context.Sizes.Include(s => s.Products)
                                       .ThenInclude(pS => pS.Product)
                                       .ToListAsync();
        }

        public async Task<IEnumerable<SizeModel>> GetAllAsync(int offset, int limit)
        {
            return await _context.Sizes.Include(s => s.Products)
                                       .ThenInclude(pS => pS.Product)
                                       .Skip(offset)
                                       .Take(limit)
                                       .ToListAsync();
        }

        public async Task<SizeModel> GetByIdAsync(int id)
        {
            return await _context.Sizes.Include(s => s.Products)
                                       .ThenInclude(pS => pS.Product)
                                       .Where(c => c.Id == id)
                                       .FirstOrDefaultAsync();
        }

        #endregion

        #region ADD
        public async Task<SizeModel> AddAsync(SizeModel obj)
        {
            try
            {
                var products = await GetAllAsync();
                if (!products.Any(x => x.Name.Equals(obj.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    var result = await _context.Sizes.AddAsync(obj);
                    _context.SaveChanges();
                    return result.Entity;
                } else
                {
                    throw new Exception("This size already exist.");
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception($"An error has been occurred during the operation: {ex.Message}");
            }
        }
        #endregion

        #region DELETE
        public async Task<SizeModel> DeleteAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                if (result != null)
                {
                    _context.Sizes.Remove(result);
                    await _context.SaveChangesAsync();
                    return result;
                }
                else
                {
                    throw new Exception("There are not any size with the specified id");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error has been occurred during the operation: {ex.Message}");
            }
        }
        #endregion

        #region UPDATE
        public async Task<SizeModel> UpdateAsync(SizeModel obj)
        {
            try
            {
                var result = await GetByIdAsync(obj.Id);

                if (result != null)
                {
                    result.Name = obj.Name;
                    _context.SaveChanges();
                    return result;
                }
                else
                {
                    throw new Exception("There are not any size with the specified id");
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
