using Microsoft.AspNetCore.Mvc;
using System.Net;

 [Route("api/[controller]")]
    [ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService  user = userService;
    [HttpPost]
    public async Task<Response<string>> AddAsync(AddUserDto userDto)
    {
        return await AddAsync(userDto);
    }
    [HttpDelete("(userid)")]
    public async Task<Response<string>> DeleteAsync(int userid)
    {
        return await  DeleteAsync(userid);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(int userid,UpdateUserDto userDto)
    {
        return await UpdateAsync(userid,userDto);
    }
    [HttpGet("(userid)")]
     public async Task<Response<User>> GetByIdAsync(int userid)
    {
        return await GetByIdAsync(userid);
    }
    [HttpGet]
    public async Task<Response<List<User>>> GetAsync()
    {
        return await GetAsync();
    }
}
