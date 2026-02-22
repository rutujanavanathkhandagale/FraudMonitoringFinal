using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Helpers;
using FraudMonitoringSystem.Repositories.Customer.Implementations;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using FraudMonitoringSystem.Services.Customer.Implementations;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using Microsoft.EntityFrameworkCore;
using FraudMonitoringSystem.Data;

using FraudMonitoringSystem.Hubs;
using Microsoft.EntityFrameworkCore;





var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<WebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("webContext")));

builder.Services.Configure<SmtpSettings>(
    builder.Configuration.GetSection("SmtpSettings"));

builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<EmailHelper>();

builder.Services.AddScoped<IPersonalDetailsRepository, PersonalDetailsRepository>();
builder.Services.AddScoped<IPersonalDetailsService, PersonalDetailsService>();


builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IKYCRepository, KYCRepository>();
builder.Services.AddScoped<IKYCService, KYCService>();

builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IChatService, ChatService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();



app.Run();
