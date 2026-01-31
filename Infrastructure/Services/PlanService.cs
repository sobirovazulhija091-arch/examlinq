using System.Net;
public class PlanService(IPlanServiceRepo planRepo):IPlanService
{
     private readonly IPlanServiceRepo repo =planRepo;

    public async Task<Response<string>> AddAsync(AddPlanDto planDto)
    {
        var plan = new Plan
        {
            Name=planDto.Name,
            DurationDays=planDto.DurationDays,
            Price=planDto.Price,
            IsActive=planDto.IsActive
        };
        await repo.AddAsync(plan);
         return new Response<string>(HttpStatusCode.OK,"Added successfully");
    }

    public async Task<Response<string>> DeleteAsync(int planid)
    {
        var res= await repo.DeleteAsync(planid);
         return res ? new Response<string>(HttpStatusCode.OK,"Deleted successfully")
       : new Response<string>(HttpStatusCode.NotFound,"Can not found");
    }

    public async Task<Response<List<Plan>>> GetAsync()
    {
        var plans = await repo.GetAllAsync();
        return new Response<List<Plan>>(HttpStatusCode.OK,"ok", plans);
    }

    public async Task<Response<Plan>> GetByIdAsync(int planid)
    {
       var plan = await repo.GetByIdAsync(planid);
      return new Response<Plan>(HttpStatusCode.OK,"ok",plan);
    }

    public async Task<Response<string>> UpdateAsync(int planid, UpdatePlanDto planDto)
    {
            var res = await repo.GetByIdAsync(planid);
            res.Name=planDto.Name;
            res.DurationDays=planDto.DurationDays;
            res.Price=planDto.Price;
            res.IsActive=planDto.IsActive;
            await repo.UpdateAsync(res);
           return new Response<string>(HttpStatusCode.OK,"Update successfully");
    }

    public async Task<Response<string>> UpdateToggleAsync(int planid, bool togger)
    {
       
         var res = await repo.GetByIdAsync(planid);
         if(res==null){return new Response<string>(HttpStatusCode.NotFound,"Not found");}
         res.IsActive=togger;
         await repo.UpdateAsync(res);
         return new Response<string>(HttpStatusCode.OK,"ok");
    }
}