public interface IPlanService
{
     Task<Response<string>> AddAsync(AddPlanDto planDto);
     Task<Response<string>> DeleteAsync(int planid);
     Task<Response<string>> UpdateAsync(int planid,UpdatePlanDto planDto);
     Task<Response<Plan>> GetByIdAsync(int planid);
     Task<Response<List<Plan>>> GetAsync();
     Task<Response<string>> UpdateToggleAsync(int planid,bool togger);
}