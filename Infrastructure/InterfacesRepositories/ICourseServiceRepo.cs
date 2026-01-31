public interface ICourseServiceRepo
{
   Task<int> AddAsync(Course course);
    Task<Course?> GetByIdAsync(int courseId);
    Task<List<Course?>> GetAllAsync();
    Task<bool> UpdateAsync(Course course);
    Task<bool> DeleteAsync(int courseId); 
}