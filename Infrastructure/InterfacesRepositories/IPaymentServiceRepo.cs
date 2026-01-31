public interface IPaymentServiceRepo
{
    Task<int> AddAsync(Payment payment);
    Task <Payment?> GetByIdAsync(int payId);
    Task <List<Payment?>> GetAllAsync();
    Task<bool> UpdateAsync(Payment payment);
    Task<bool> DeleteAsync(int payId);
}