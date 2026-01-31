using System.Net;
public class UserService(IUserServiceRepo userrepo):IUserService
{
    private readonly IUserServiceRepo repo = userrepo;

    public async Task<Response<string>> AddAsync(AddUserDto userDto)
    {
        var user = new User
        {
            FullName=userDto.FullName,
            Email=userDto.Email
        };
        await repo.AddAsync(user);
        return new Response<string>(HttpStatusCode.OK,"User added successfully");
    }

    public async Task<Response<string>> DeleteAsync(int userid)
    {
       var res = await repo.DeleteAsync(userid);
       return res ?new Response<string>(HttpStatusCode.OK,"Deleted successfully")
       : new Response<string>(HttpStatusCode.NotFound,"Can not found");
    }

    public async Task<Response<List<User>>> GetAsync()
    {
       var users = await repo.GetAllAsync();
       return new Response<List<User>>(HttpStatusCode.OK,"ok", users);
    }

    public async Task<Response<User>> GetByIdAsync(int userid)
    {
       var users = await repo.GetByIdAsync(userid);
       return new Response<User>(HttpStatusCode.OK,"ok",users);
    }

    public async Task<Response<string>> UpdateAsync(int userid, UpdateUserDto userDto)
    {
       var user = await repo.GetByIdAsync(userid);
       if(user==null){return new Response<string>(HttpStatusCode.NotFound,"Not found");}
          user.FullName = userDto.FullName;
          user.Email = userDto.Email;
           await repo.UpdateAsync(user);
          return new Response<string>(HttpStatusCode.OK,"Update successfully");
    }
}