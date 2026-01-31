using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICourseAccessService,CourseAccessService>();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<IPlanService,PlanService>();
builder.Services.AddScoped<IPaymentService,PaymentService>();
builder.Services.AddScoped<ISubscriptionService,SubscriptionService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ICourseAccessServiceRepo,CourseAccessServiceRepo>();
builder.Services.AddScoped<ICourseServiceRepo,CourseServiceRepo>();
builder.Services.AddScoped<IPlanServiceRepo,PlanServiceRepo>();
builder.Services.AddScoped<IPaymentServiceRepo,PaymentServiceRepo>();
builder.Services.AddScoped<ISubscriptionServiceRepo,SubscriptionServiceRepo>();
builder.Services.AddScoped<IUserServiceRepo,UserServiceRepo>();
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddLogging(conf=>{conf.AddConsole();});
builder.Services.AddDbContext<ApplicationDbcontext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
}

 app.MapOpenApi();
 app.UseMiddleware<RequestTimeMiddleware>();
 app.MapControllers();
app.Run();
