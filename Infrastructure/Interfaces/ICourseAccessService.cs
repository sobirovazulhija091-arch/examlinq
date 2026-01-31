public interface ICourseAccessService
{
    Task<Response<string>> AddAsync(AddCourseAccessDto accessDto);
    Task<Response<string>> AddGrantedAtAsync(AddCourseAccessDto accessDto);
    Task<Response<string>> AddRevokedAtAsync(AddCourseAccessDto accessDto);
    Task<Response<string>> DeleteAsync(int accessid);
    Task<Response<string>> UpdateAsync(int accessid,UpdateCourseAccessDto accessDto);
    Task<Response<CourseAccess>> GetByIdAsync(int accessid);
    Task<Response<List<CourseAccess>>> GetAsync();
}