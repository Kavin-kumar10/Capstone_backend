using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class BaseRepository<T> : IRepository<int, T> where T : class
    {
        MatrimonialContext _context;
        public BaseRepository(MatrimonialContext context) {
            _context = context;
        }
        public async Task<T> Create(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var elem = await Get(id);
            if (elem == null)
                return elem;
            _context.Remove(id);
            await _context.SaveChangesAsync();
            return elem;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task<T> Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }
    }
}
