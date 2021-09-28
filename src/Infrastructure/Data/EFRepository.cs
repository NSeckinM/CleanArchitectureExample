using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    //GENERİC REPOSİTORY PATTERN
    public class EFRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<T> AddAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task CountAsync(ISpecification<T> specification)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task FirsOrDefaulttAsync(ISpecification<T> specification)
        {
            throw new System.NotImplementedException();
        }

        public Task FirstAsync(ISpecification<T> specification)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            //set<T> T ne ise onun tüm verilerini getir için kullanılıyor.
            return await _context.Set<T>().ToListAsync();
        }

        public Task<List<T>> ListAsync(ISpecification<T> specification)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
