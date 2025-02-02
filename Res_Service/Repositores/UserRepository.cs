using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Res_Service.Data;
using Res_Service.Models;


namespace Res_Service.Repositores
{
    public class UserRepository<T> : IUserRepository<T> where T : UserBase
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<T> _dbSet;
        public UserRepository(ApplicationDBContext context )
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> GetUserByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllUsersAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> CreateUserAsync(T user)
        {
            await _dbSet.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<T> UpdateUserAsync(T user)
        {
            _dbSet.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<T> DeleteUserAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }
    }
    
    
}
