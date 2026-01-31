using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;

[Route("api/[controller]")]
    [ApiController]
    public class PlanController(IPlanService planService):Controller
    {
         private IPlanService _planService=planService;
           [HttpPost]
    public async Task<Response<string>> AddAsync( AddPlanDto planDto)
    {
        return await _planService.AddAsync(planDto);
    }

    
    [HttpDelete("{planId}")]
    public async Task<Response<string>> DeleteAsync(int planId)
    {
        return await _planService.DeleteAsync(planId);
    }

    [HttpPut("(planId)")]
    public async Task<Response<string>> UpdateAsync(int planId,UpdatePlanDto planDto)
    {
        return await _planService.UpdateAsync(planId, planDto);
    }

    [HttpGet("(planId)")]
    public async Task<Response<Plan>> GetByIdAsync(int planId)
    {
        return await _planService.GetByIdAsync(planId);
    }
    [HttpGet]
    public async Task<Response<List<Plan>>> GetAsync()
    {
        return await _planService.GetAsync();
    }

    [HttpPatch]
    public async Task<Response<string>> UpdateToggleAsync(int planId, bool isActive)
    {
        return await _planService.UpdateToggleAsync(planId, isActive);
    }
    }