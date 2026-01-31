using Microsoft.VisualBasic;

public class RequestTimeMiddleware
{
    private RequestDelegate _next;
 private readonly ILogger<RequestTimeMiddleware> _logger;   
  public RequestTimeMiddleware(RequestDelegate next, ILogger<RequestTimeMiddleware> logger)
    {
        _next=next;
        _logger=logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation(
            "Income request: {Method} {Path}",
            context.Request.Method,
            context.Request.Path
        );
        var start = DateTime.Now;
        try
        {
            await _next(context);
        }
        catch (System.Exception ex)
        {
         _logger.LogError( ex ,"Something is wrong");
        }
        var end = DateTime.Now;
        _logger.LogInformation("The request finished!");
        Console.WriteLine($"Request took:{(end-start).Milliseconds} ms");
    }
}