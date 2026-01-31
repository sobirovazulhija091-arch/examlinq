public  interface IPaymentService
{
      Task<Response<string>> AddAsync(AddPaymentDto payDto);
     Task<Response<string>> DeleteAsync(int payid);
     Task<Response<string>> UpdateAsync(int payid,UpdatePaymentDto payDto);
     Task<Response<Payment>> GetByIdAsync(int payid);
     Task<Response<List<Payment>>> GetAsync();
}