
using Microsoft.EntityFrameworkCore;

public class CourseAccessServiceRepo(ApplicationDbcontext dbcontext):ICourseAccessServiceRepo
{
      private readonly ApplicationDbcontext context=dbcontext;

    public async Task<int> AddAsync(CourseAccess access)
    {
        await context.CourseAccesses.AddAsync(access);
        await context.SaveChangesAsync();
        return access.Id;
    }

    public async Task<bool> DeleteAsync(int accessId)
    {
       var res =  await context.CourseAccesses.FindAsync(accessId);
       if(res==null){return false;}
        context.CourseAccesses.Remove(res);
        return true;
    }

    public async Task<List<CourseAccess?>> GetAllAsync()
    {
        return await context.CourseAccesses.ToListAsync();
    }

    public async Task<CourseAccess?> GetByIdAsync(int accessId)
    {
       return await context.CourseAccesses.FindAsync(accessId);
    }

    public async Task<bool> UpdateAsync(CourseAccess access)
    {
        context.CourseAccesses.Update(access);
        await context.SaveChangesAsync();
        return true;
    }
}