using System.Net;
public class CourseService(ICourseServiceRepo  courseRepo):ICourseService
{
     private readonly ICourseServiceRepo repo = courseRepo;

    public async Task<Response<string>> AddAsync(AddCourseDto courseDto)
    {
        var course = new Course
        {
          Description=courseDto.Description,
          Title=courseDto.Title,
          Price=courseDto.Price,
          IsPublished=courseDto.IsPublished
        };
        await repo.AddAsync(course);
        return new Response<string>(HttpStatusCode.OK,"Added successfully");
    }

    public async Task<Response<string>> DeleteAsync(int courseid)
    {
      var res = await repo.DeleteAsync(courseid);
        return res ? new Response<string>(HttpStatusCode.OK,"Deleted successfully")
       : new Response<string>(HttpStatusCode.NotFound,"Can not found");
    }

    public async Task<Response<List<Course>>> GetAsync()
    {
        var course = await repo.GetAllAsync();
        return new Response<List<Course>>(HttpStatusCode.OK,"ok", course);
    }

    public async Task<Response<Course>> GetByIdAsync(int courseid)
    {
       var course = await repo.GetByIdAsync(courseid);
      return new Response<Course>(HttpStatusCode.OK,"ok",course);
    }

    public async Task<Response<string>> UpdateAsync(int courseid, UpdateCourseDto courseDto)
    {
        var course = await repo.GetByIdAsync(courseid);
          course.Description=courseDto.Description;
           course.Title=courseDto.Title;
           course.Price=courseDto.Price;
           course.IsPublished=courseDto.IsPublished;
           await repo.UpdateAsync(course);
           return new Response<string>(HttpStatusCode.OK,"Update successfully");
    }

    public async Task<Response<string>> UpdatePublishAsync(int courseid, bool ispublish)
    {
         var res = await repo.GetByIdAsync(courseid);
         if(res==null){return new Response<string>(HttpStatusCode.NotFound,"Not found");}
         res.IsPublished=ispublish;
         await repo.UpdateAsync(res);
         return new Response<string>(HttpStatusCode.OK,"ok");
    }
}