public interface ISubscriptionServiceRepo
{
     Task<int> AddAsync(Subscription subscription);
    Task<Subscription?> GetByIdAsync(int subscriptionId);
    Task<List<Subscription?>> GetAllAsync();
    Task<bool> UpdateAsync(Subscription subscription);
    Task<bool> DeleteAsync(int subscriptionId);
}