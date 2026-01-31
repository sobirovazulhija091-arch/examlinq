
using Microsoft.EntityFrameworkCore;

public class UserServiceRepo(ApplicationDbcontext dbcontext) : IUserServiceRepo
{
      private readonly ApplicationDbcontext context=dbcontext;
    public async Task<int> AddAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<bool> DeleteAsync(int userId)
    {
       var res = await context.Users.FindAsync(userId);
       if(res==null){return false;}
         context.Users.Remove(res);
         await context.SaveChangesAsync();
         return true;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int userId)
    {
       return await context.Users.FindAsync(userId);
    }

    public async Task<bool> UpdateAsync(User user)
    {
       context.Users.Update(user);
       await context.SaveChangesAsync();
       return true; 
    }
}