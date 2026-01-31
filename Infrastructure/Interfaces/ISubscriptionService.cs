public interface ISubscriptionService
{
     Task<Response<string>> AddAsync(AddSubscriptionDto subDto);
     Task<Response<string>> AddPurchaseAsync(int subid,string status);
     Task<Response<string>> AddCancelAsync(int subid,string status);
     Task<Response<string>> DeleteAsync(int subid);
     Task<Response<string>> UpdateAsync(int subid,UpdateSubscriptionDto subDto);
     Task<Response<Subscription>> GetByIdAsync(int subid);
     Task<Response<List<Subscription>>> GetAsync();
     Task<Response<List<Subscription>>> GetUserAsync(int userid);
}