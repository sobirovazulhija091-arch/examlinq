using Microsoft.EntityFrameworkCore;

public class PaymentServiceRepo(ApplicationDbcontext dbcontext): IPaymentServiceRepo
{
    private readonly ApplicationDbcontext context=dbcontext;

    public async Task<int> AddAsync(Payment payment)
    {
        await context.Payments.AddAsync(payment);
        await context.SaveChangesAsync();
        return payment.Id;
    }

    public async Task<Payment?> GetByIdAsync(int payId)
    {
        return await context.Payments.FindAsync(payId);
    }

    public async Task<List<Payment?>> GetAllAsync()
    {
        return await context.Payments.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Payment payment)
    {
        context.Payments.Update(payment);
        await context.SaveChangesAsync() ;
        return true;
    }

    public async Task<bool> DeleteAsync(int payId)
    {
        var payment = await context.Payments.FindAsync(payId);
        if (payment == null) {return false;}

        context.Payments.Remove(payment);
        await context.SaveChangesAsync();
        return true;
    }
}
