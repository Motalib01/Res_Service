using Res_Service.Models;

namespace Res_Service.Repositores
{
    public interface IUserRepository<T> where T : UserBase
    {
        Task<T> GetUserByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllUsersAsync();
        Task<T> CreateUserAsync(T user);
        Task<T> UpdateUserAsync(T user);
        Task<T> DeleteUserAsync(Guid id);
    }
}
