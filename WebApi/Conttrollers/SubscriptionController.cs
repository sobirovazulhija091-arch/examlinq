using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;

[Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController(ISubscriptionService subscriptionService):ControllerBase
    {
         private readonly ISubscriptionService service = subscriptionService;
         [HttpPost]
    public async Task<Response<string>> AddAsync(AddSubscriptionDto subDto)
    {
        return await AddAsync(subDto);
    }
    [HttpPost]
    public async Task<Response<string>> AddPurchaseAsync(int subid,string status)
    {
        return await AddPurchaseAsync(subid,status);
    }
    [HttpPost]
    public async Task<Response<string>> AddCancelAsync(int subid,string status)
    {
        return await service.AddCancelAsync(subid,status);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int subid)
    {
        return await  service.DeleteAsync(subid);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(int subid,UpdateSubscriptionDto subDto)
    {
        return await service.UpdateAsync(subid,subDto);
    }
    [HttpGet("(sunid)")]
    public async  Task<Response<Subscription>> GetByIdAsync(int subid)
    {
        return await  service.GetByIdAsync(subid);
    }
    [HttpGet]
    public async Task<Response<List<Subscription>>> GetAsync()
    {
        return  await service.GetAsync();
    }
    [HttpGet("(userid)")]
    public async Task<Response<List<Subscription>>> GetUserAsync(int userid)
    {
       return await service.GetUserAsync(userid);
    }
    }