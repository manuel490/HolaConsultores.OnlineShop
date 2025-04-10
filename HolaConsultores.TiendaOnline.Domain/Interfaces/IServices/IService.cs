using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Domain.Interfaces.IServices
{
    public interface IService<T, I>
    {
        public Task<T> AddAsync(I obj);
        public Task<T> DeleteAsync(int id);
        public Task<T> UpdateAsync(I obj);
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<IEnumerable<T>> GetAllAsync(int offset, int limit);
    }
}
