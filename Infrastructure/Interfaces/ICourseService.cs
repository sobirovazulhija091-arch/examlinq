public interface ICourseService
{
     Task<Response<string>> AddAsync(AddCourseDto courseDto);
     Task<Response<string>> DeleteAsync(int courseid);
     Task<Response<string>> UpdateAsync(int courseid,UpdateCourseDto courseDto);
     Task<Response<Course>> GetByIdAsync(int courseid);
     Task<Response<List<Course>>> GetAsync();
     Task<Response<string>> UpdatePublishAsync(int courseid, bool ispublish);
}