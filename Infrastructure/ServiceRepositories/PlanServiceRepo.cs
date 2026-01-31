
using Microsoft.EntityFrameworkCore;

public class PlanServiceRepo(ApplicationDbcontext dbcontext):IPlanServiceRepo
{
    private readonly ApplicationDbcontext context=dbcontext;

    public async Task<int> AddAsync(Plan plan)
    {
        await context.Plans.AddAsync(plan);
        await context.SaveChangesAsync();
        return plan.Id;
    }

    public async Task<bool> DeleteAsync(int planId)
    {
        var res = await context.Plans.FindAsync(planId);
        if(res==null){return false;}
        context.Plans.Remove(res);
        return true; 
    }

    public async Task<List<Plan?>> GetAllAsync()
    {
        return await context.Plans.ToListAsync();
    }

    public async Task<Plan?> GetByIdAsync(int planId)
    {
       return await context.Plans.FindAsync(planId);
    }

    public async Task<bool> UpdateAsync(Plan plan)
    {
        context.Plans.Update(plan);
        await context.SaveChangesAsync();
        return true;
    }
}