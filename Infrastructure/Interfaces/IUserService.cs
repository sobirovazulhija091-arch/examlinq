public interface IUserService
{
     Task<Response<string>> AddAsync(AddUserDto userDto);
     Task<Response<string>> DeleteAsync(int userid);
     Task<Response<string>> UpdateAsync(int userid,UpdateUserDto userDto);
     Task<Response<User>> GetByIdAsync(int userid);
     Task<Response<List<User>>> GetAsync();
     
}