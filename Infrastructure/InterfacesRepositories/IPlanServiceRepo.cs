public interface IPlanServiceRepo
{
    Task<int> AddAsync(Plan plan);
    Task<Plan?> GetByIdAsync(int planId);
    Task<List<Plan?>> GetAllAsync();
    Task<bool> UpdateAsync(Plan plan);
    Task<bool> DeleteAsync(int planId);
}