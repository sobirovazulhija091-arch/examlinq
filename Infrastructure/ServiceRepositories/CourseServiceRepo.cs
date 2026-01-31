
using Microsoft.EntityFrameworkCore;

public class CourseServiceRepo(ApplicationDbcontext dbcontext):ICourseServiceRepo
{
     private readonly ApplicationDbcontext context=dbcontext;

    public async Task<int> AddAsync(Course course)
    {
       await context.Courses.AddAsync(course);
       await context.SaveChangesAsync();
       return course.Id;
    }

    public async Task<bool> DeleteAsync(int courseId)
    {
         var res = await context.Courses.FindAsync(courseId);
         if(res==null){return false;}
         context.Courses.Remove(res);
         await context.SaveChangesAsync();
         return true;
    }

    public async Task<List<Course?>> GetAllAsync()
    {
       return await context.Courses.ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(int courseId)
    {
        return await context.Courses.FindAsync(courseId);
    }

    public async Task<bool> UpdateAsync(Course course)
    {
          context.Courses.Update(course);
          await context.SaveChangesAsync();
          return true;
    }
}