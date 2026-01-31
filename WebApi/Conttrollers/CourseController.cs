using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;

[Route("api/[controller]")]
    [ApiController]
     public class CourseController(ICourseService courseService):ControllerBase
    {
        private readonly ICourseService _service=courseService;
        [HttpPost("add")]
    public async Task<Response<string>> AddAsync(AddCourseDto courseDto)
    {
        return await _service.AddAsync(courseDto);
    }

    [HttpDelete("{courseId}")]
    public async Task<Response<string>> DeleteAsync(int courseId)
    {
        return await _service.DeleteAsync(courseId);
    }

    [HttpPut("{courseId}")]
    public async Task<Response<string>> UpdateAsync(int courseId, UpdateCourseDto courseDto)
    {
        return await _service.UpdateAsync(courseId, courseDto);
    }

    [HttpGet("{courseId}")]
    public async Task<Response<Course>> GetByIdAsync(int courseId)
    {
        return await _service.GetByIdAsync(courseId);
    }

    [HttpGet]
    public async Task<Response<List<Course>>> GetAsync()
    {
        return await _service.GetAsync();
    }

    [HttpPut("{courseId}/publish")]
    public async Task<Response<string>> UpdatePublishAsync(int courseId, bool isPublish)
    {
        return await _service.UpdatePublishAsync(courseId, isPublish);
    }
        
    }