using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Helpers;
using FraudMonitoringSystem.Hubs;
using FraudMonitoringSystem.Repositories.Customer.Implementations;
using FraudMonitoringSystem.Repositories.Customer.Implementations.Admin;
using FraudMonitoringSystem.Repositories.Customer.Implementations.Rules;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Rules;
using FraudMonitoringSystem.Services.Customer.Implementations;
using FraudMonitoringSystem.Services.Customer.Implementations.Admin;
using FraudMonitoringSystem.Services.Customer.Implementations.Rules;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;






var builder = WebApplication.CreateBuilder(args);//configure dependancy injection,load appseting,json

// Add services
builder.Services.AddControllers();//dependancy njection controller
builder.Services.AddEndpointsApiExplorer();//swagger endpoint find out
builder.Services.AddSwaggerGen();//register swagger gen //api testing

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

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();

builder.Services.AddScoped<IPermissionService, PermissionService>();

builder.Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
builder.Services.AddScoped<IRolePermissionService, RolePermissionService>();

builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();




//Roles
builder.Services.AddScoped<IScenarioRepository, ScenarioRepository>();

// Register Services
builder.Services.AddScoped<IScenarioService, ScenarioService>();

// Register DetectionRule Repository & Service
builder.Services.AddScoped<IDetectionRuleRepository, DetectionRuleRepository>();
builder.Services.AddScoped<IDetectionRuleService, DetectionRuleService>();

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
