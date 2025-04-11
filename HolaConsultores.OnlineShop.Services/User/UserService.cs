using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Interfaces.IRepositories;
using HolaConsultores.OnlineShop.Domain.Interfaces.IServices;
using HolaConsultores.OnlineShop.Domain.Resources.User;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using HolaConsultores.OnlineShop.Domain.Resources.Size;
using HolaConsultores.OnlineShop.Infraestructure.Entities;
using HolaConsultores.OnlineShop.Mappers.Color;
using HolaConsultores.OnlineShop.Mappers.User;

namespace HolaConsultores.OnlineShop.Services.User
{
    public class UserService : Service<IRepository<UserModel>>, IUserService<UserResource, UserResource>
    {
        public UserService(IRepository<UserModel> repository) : base(repository)
        {
        }

        #region GET
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            try
            {
                return (await _repository.GetAllAsync()).ToList().ToResource();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<UserResource>> GetAllAsync(int offset, int limit)
        {
            try
            {
                return (await _repository.GetAllAsync(offset, limit)).ToList().ToResource();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UserResource> GetByIdAsync(int id)
        {
            try
            {
                return (await _repository.GetByIdAsync(id)).ToResource();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region ADD
        public async Task<UserResource> AddAsync(UserResource obj)
        {
            try
            {
                var resource = new UserResource()
                {
                    Email = obj.Email,
                    Password = obj.Password
                };
                var result = await _repository.AddAsync(resource.ToModel());
                return result.ToResource();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding {ex}");
            }
        }
        #endregion

        #region DELETE
        public async Task<UserResource> DeleteAsync(int id)
        {
            try
            {
                return (await _repository.DeleteAsync(id)).ToResource();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting {ex}");
            }
        }
        #endregion

        #region UPDATE
        public async Task<UserResource> UpdateAsync(UserResource obj)
        {
            try
            {
                var result = await _repository.UpdateAsync(obj.ToModel());
                return result.ToResource();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating {ex}");
            }
        }
        #endregion

        public async Task<bool> UserExist(UserResource obj)
        {
            try
            {
                var result = await GetAllAsync();
                return result.Any(u => u.Email == obj.Email && u.Password == obj.Password);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
