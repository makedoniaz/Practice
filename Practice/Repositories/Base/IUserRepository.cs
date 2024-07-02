using Practice.Dtos;
using Practice.Models;

namespace Practice.Repositories.Base;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();

    Task<int> CreateAsync(User user);

    Task<int> DeleteByIdAsync(int id);

    Task<int> PutAsync(LoginDto loginDto, int id);
}