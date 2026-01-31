using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;

[Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentService paymentService):Controller
    { 
      private readonly IPaymentService _service=paymentService;
       [HttpPost("add")]
    public async Task<Response<string>> AddAsync(AddPaymentDto payDto)
    {
        return await _service.AddAsync(payDto);
    }

    [HttpDelete("{payId}")]
    public async Task<Response<string>> DeleteAsync(int payId)
    {
        return await _service.DeleteAsync(payId);
    }

    [HttpPut("{payId}")]
    public async Task<Response<string>> UpdateAsync(int payId, UpdatePaymentDto payDto)
    {
        return await _service.UpdateAsync(payId, payDto);
    }

    [HttpGet("{payId}")]
    public async Task<Response<Payment>> GetByIdAsync(int payId)
    {
        return await _service.GetByIdAsync(payId);
    }

    [HttpGet]
    public async Task<Response<List<Payment>>> GetAsync()
    {
        return await _service.GetAsync();
    } 
    }