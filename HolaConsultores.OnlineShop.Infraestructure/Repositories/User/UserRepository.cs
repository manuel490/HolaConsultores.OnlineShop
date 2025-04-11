using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Infraestructure.Context;
using HolaConsultores.OnlineShop.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HolaConsultores.OnlineShop.Infraestructure.Repositories.User
{
    public class UserRepository : Repository, IRepository<UserModel>
    {
        public UserRepository(MyContext context) : base(context)
        {
        }

        #region GET
        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync(int offset, int limit)
        {
            return await _context.Users.Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstAsync();
        }
        #endregion

        #region ADD
        public async Task<UserModel> AddAsync(UserModel obj)
        {
            try
            {
                var result = await _context.Users.AddAsync(obj);
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
        public async Task<UserModel> DeleteAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                _context.Users.Remove(result);
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
        public async Task<UserModel> UpdateAsync(UserModel obj)
        {
            try
            {
                var result = await GetByIdAsync(obj.Id);
                result.Email = obj.Email;
                result.Password = obj.Password;
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
