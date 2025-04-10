using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IRepositories;
using HolaConsultores.TiendaOnline.Infraestructure.Context;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HolaConsultores.TiendaOnline.Infraestructure.Repositories.Size
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
                                       .FirstAsync();
        }

        #endregion

        #region ADD
        public async Task<SizeModel> AddAsync(SizeModel obj)
        {
            try
            {
                var result = await _context.Sizes.AddAsync(obj);
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
        public async Task<SizeModel> DeleteAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                _context.Sizes.Remove(result);
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
        public async Task<SizeModel> UpdateAsync(SizeModel obj)
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
