using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Domain.Interfaces.IServices
{
    public interface IService<R, I>
    {
        public Task<R> AddAsync(I obj);
        public Task<R> DeleteAsync(int id);
        public Task<R> UpdateAsync(I obj);
        public Task<R> GetByIdAsync(int id);
        public Task<IEnumerable<R>> GetAllAsync();
        public Task<IEnumerable<R>> GetAllAsync(int offset, int limit);
    }
}
