public interface ICourseAccessServiceRepo
{
    Task<int> AddAsync(CourseAccess access);
    Task<CourseAccess?> GetByIdAsync(int accessId);
    Task<List<CourseAccess?>> GetAllAsync();
    Task<bool> UpdateAsync(CourseAccess access);
    Task<bool> DeleteAsync(int accessId);   
}