
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

public class SubscriptionServiceRepo(ApplicationDbcontext dbcontext):ISubscriptionServiceRepo
{
    private readonly ApplicationDbcontext context=dbcontext;

    public async Task<int> AddAsync(Subscription subscription)
    {
        await context.Subscriptions.AddAsync(subscription);
        await context.SaveChangesAsync();
        return subscription.Id;
    }

    public async Task<bool> DeleteAsync(int subscriptionId)
    {
        var res = await context.Subscriptions.FindAsync(subscriptionId);
        if(res==null){return false;}
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Subscription?>> GetAllAsync()
    {
        return await context.Subscriptions.ToListAsync();
    }

    public async Task<Subscription?> GetByIdAsync(int subscriptionId)
    {
         return await context.Subscriptions.FindAsync(subscriptionId);
    }

    public async Task<bool> UpdateAsync(Subscription subscription)
    {
         context.Subscriptions.Update(subscription);
         await context.SaveChangesAsync();
         return true;
    }
}