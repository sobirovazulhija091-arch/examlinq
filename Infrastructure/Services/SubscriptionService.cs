using System.Net;
public class SubscriptionService(ISubscriptionServiceRepo subRepo):ISubscriptionService
{
     private readonly ISubscriptionServiceRepo repo=subRepo;

    public async Task<Response<string>> AddAsync(AddSubscriptionDto subDto)
    {
       var sub = new Subscription
       {
           UserId=subDto.UserId,
           PlanId=subDto.PlanId,
           EndDate=subDto.EndDate,
           Status=subDto.Status
       };
       await repo.AddAsync(sub);
        return new Response<string>(HttpStatusCode.OK,"Added successfully");
    }

    public async Task<Response<string>> AddCancelAsync(int subid,string status)
    {
       var sub = await repo.GetByIdAsync(subid);
       if(sub==null){return new Response<string>(HttpStatusCode.NotFound,"Not Found");}
         sub.Status = EnumStatusSubscription.Canceled;
         await repo.UpdateAsync(sub);
         return new Response<string>(HttpStatusCode.OK,"OK");
         }

    public async Task<Response<string>> AddPurchaseAsync(int subid, string status)
    {
        var sub = await repo.GetByIdAsync(subid);
        if(sub==null){return new Response<string>(HttpStatusCode.NotFound,"Not Found");}
        sub.Status=EnumStatusSubscription.Active;
         await repo.UpdateAsync(sub);
         return new Response<string>(HttpStatusCode.OK,"OK");
    }

    public async Task<Response<string>> DeleteAsync(int subid)
    {
       var res = await repo.DeleteAsync(subid);
        return res ? new Response<string>(HttpStatusCode.OK,"Deleted successfully")
       : new Response<string>(HttpStatusCode.NotFound,"Can not found");
    }

    public async Task<Response<List<Subscription>>> GetAsync()
    {
           var sub = await repo.GetAllAsync();
        return new Response<List<Subscription>>(HttpStatusCode.OK,"ok", sub);
    }

    public async Task<Response<Subscription>> GetByIdAsync(int subid)
    {
         var sub = await repo.GetByIdAsync(subid);
      return new Response<Subscription>(HttpStatusCode.OK,"ok",sub);
    }

    public async Task<Response<List<Subscription>>> GetUserAsync(int userid)
    {
       var sub = await repo.GetAllAsync();
       var anduser =  sub .Where(s=>s.UserId==userid).ToList();
       if(anduser==null){return new Response<List<Subscription>>(HttpStatusCode.NotFound,"Not Found");}
       return new Response<List<Subscription>>(HttpStatusCode.OK,"ok",anduser);
    }

    public async Task<Response<string>> UpdateAsync(int subid, UpdateSubscriptionDto subDto)
    {
        var sub = await repo.GetByIdAsync(subid);
        sub.UserId=subDto.UserId;
             sub.PlanId=subDto.PlanId;
             sub.EndDate=subDto.EndDate;
             sub.Status=subDto.Status;
             await repo.UpdateAsync(sub);
    return new Response<string>(HttpStatusCode.OK,"Update successfully");

    }
}