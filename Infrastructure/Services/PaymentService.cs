using System.Net;
public class PaymentService(IPaymentServiceRepo paymentRepo):IPaymentService
{
     private readonly IPaymentServiceRepo repo = paymentRepo;

    public async Task<Response<string>> AddAsync(AddPaymentDto payDto)
    {
       var pay = new Payment
       {
           UserId=payDto.UserId,
           SubscriptionId=payDto.SubscriptionId,
           Amount=payDto.Amount,
           Status=payDto.Status,
           Provider= payDto.Provider,
           ExternalReference=payDto.ExternalReference
       };
       await repo.AddAsync(pay);
        return new Response<string>(HttpStatusCode.OK,"Added successfully");
    }

    public async Task<Response<string>> DeleteAsync(int payid)
    {
         var res = await repo.DeleteAsync(payid);
        return res ? new Response<string>(HttpStatusCode.OK,"Deleted successfully")
       : new Response<string>(HttpStatusCode.NotFound,"Can not found");
    }

    public async Task<Response<List<Payment>>> GetAsync()
    {
         var pay = await repo.GetAllAsync();
        return new Response<List<Payment>>(HttpStatusCode.OK,"ok", pay);
    }

    public async Task<Response<Payment>> GetByIdAsync(int payid)
    {
        var pay = await repo.GetByIdAsync(payid);
      return new Response<Payment>(HttpStatusCode.OK,"ok",pay);
    }

    public async Task<Response<string>> UpdateAsync(int payid, UpdatePaymentDto payDto)
    {
        var pay = await repo.GetByIdAsync(payid);
         pay.UserId=payDto.UserId;
           pay.SubscriptionId=payDto.SubscriptionId;
           pay.Amount=payDto.Amount;
           pay.Status=payDto.Status;
           pay.Provider= payDto.Provider;
           pay.ExternalReference=payDto.ExternalReference;
           await repo.UpdateAsync(pay);
           return new Response<string>(HttpStatusCode.OK,"Update successfully");
    }
    }
