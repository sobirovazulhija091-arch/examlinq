using System.Net;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
public class CourseAccessService(ICourseAccessServiceRepo accessRepo):ICourseAccessService
{
    private readonly ICourseAccessServiceRepo repo= accessRepo;

    public async Task<Response<string>> AddAsync(AddCourseAccessDto accessDto)
    {
       var couresas = new CourseAccess
       {
          UserId=accessDto.UserId,
          CourseId=accessDto.CourseId,
          IsActive=accessDto.IsActive  
       };
       await repo.AddAsync(couresas);
        return new Response<string>(HttpStatusCode.OK,"Added successfully");
    }

    public async Task<Response<string>> AddGrantedAtAsync(AddCourseAccessDto accessDto)
    {
       var allAccesses = await repo.GetAllAsync();
       var a1 = allAccesses
        .FirstOrDefault(a => a.UserId == accessDto.UserId && a.CourseId == accessDto.CourseId);
          if (a1== null){
    
        a1 = new CourseAccess
        {
            UserId = a1.UserId,
            CourseId = a1.CourseId,
            GrantedAt = DateTime.UtcNow,
            IsActive = true
        };
        await repo.AddAsync(a1);
        return new Response<string>(HttpStatusCode.OK,"Add");
        }
    else
    {
        a1.GrantedAt = DateTime.UtcNow;
        a1.IsActive = true;
        await repo.UpdateAsync(a1);   
    }
           return new Response<string>(HttpStatusCode.InternalServerError,"Error");
    }

    public async Task<Response<string>> AddRevokedAtAsync(AddCourseAccessDto accessDto)
    {
         var allAccesses = await repo.GetAllAsync();
       var a1 = allAccesses
        .FirstOrDefault(a => a.UserId == accessDto.UserId && a.CourseId == accessDto.CourseId);
          if (a1== null){return new Response<string>(HttpStatusCode.NotFound,"Not found");}
           a1.IsActive = false;  
            a1.RevokedAt = DateTime.UtcNow;
            await  repo.UpdateAsync(a1);
            return new Response<string>(HttpStatusCode.OK,"ok");
    }

    public  async Task<Response<string>> DeleteAsync(int accessid)
    {
         var res = await repo.DeleteAsync(accessid);
        return res ? new Response<string>(HttpStatusCode.OK,"Deleted successfully")
       : new Response<string>(HttpStatusCode.NotFound,"Can not found");
    }

    public async Task<Response<List<CourseAccess>>> GetAsync()
    {
        var access = await repo.GetAllAsync();
          return new Response<List<CourseAccess>>(HttpStatusCode.OK,"ok", access);
    }

    public async Task<Response<CourseAccess>> GetByIdAsync(int accessid)
    {
      var access = await repo.GetByIdAsync(accessid);
       return new Response<CourseAccess>(HttpStatusCode.OK,"ok",access);
    }

    public async Task<Response<string>> UpdateAsync(int accessid, UpdateCourseAccessDto accessDto)
    {
        var access = await repo.GetByIdAsync(accessid);
           access.UserId=accessDto.UserId;
          access.CourseId=accessDto.CourseId;
          access.IsActive=accessDto.IsActive;
          await repo.UpdateAsync(access);
           return new Response<string>(HttpStatusCode.OK,"Update successfully");
    }
}