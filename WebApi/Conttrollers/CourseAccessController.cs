using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;

[Route("api/[controller]")]
    [ApiController]
    public class CourseAccessController(ICourseAccessService courseAccessService):ControllerBase
    {
        private readonly ICourseAccessService _service=courseAccessService;
         [HttpPost("add")]
    public async Task<Response<string>> AddAsync(AddCourseAccessDto accessDto)
    {
        return await _service.AddAsync(accessDto);
    }

    [HttpPost("grant")]
    public async Task<Response<string>> AddGrantedAtAsync(AddCourseAccessDto accessDto)
    {
        return await _service.AddGrantedAtAsync(accessDto);
    }

    [HttpPost("revoke")]
    public async Task<Response<string>> AddRevokedAtAsync(AddCourseAccessDto accessDto)
    {
        return await _service.AddRevokedAtAsync(accessDto);
    }

    [HttpDelete("{accessId}")]
    public async Task<Response<string>> DeleteAsync(int accessId)
    {
        return await _service.DeleteAsync(accessId);
    }

    [HttpPut("{accessId}")]
    public async Task<Response<string>> UpdateAsync(int accessId, UpdateCourseAccessDto accessDto)
    {
        return await _service.UpdateAsync(accessId, accessDto);
    }

    [HttpGet("{accessId}")]
    public async Task<Response<CourseAccess>> GetByIdAsync(int accessId)
    {
        return await _service.GetByIdAsync(accessId);
    }

    [HttpGet]
    public async Task<Response<List<CourseAccess>>> GetAsync()
    {
        return await _service.GetAsync();
    }
    }