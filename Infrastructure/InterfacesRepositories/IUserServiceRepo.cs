public interface IUserServiceRepo
{
     Task<int> AddAsync(User user);
    Task<User?> GetByIdAsync(int userId);
    Task<List<User?>> GetAllAsync();
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(int userId);
}