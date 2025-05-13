using AI_Agent_WebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register all repositories
builder.Services.AddScoped<AI_Agent_WebApp.Repositories.Interfaces.IAgentRepository, AI_Agent_WebApp.Repositories.Implementations.AgentRepository>();
builder.Services.AddScoped<AI_Agent_WebApp.Repositories.Interfaces.IArticleRepository, AI_Agent_WebApp.Repositories.Implementations.ArticleRepository>();
builder.Services.AddScoped<AI_Agent_WebApp.Repositories.Interfaces.IReviewRepository, AI_Agent_WebApp.Repositories.Implementations.ReviewRepository>();
builder.Services.AddScoped<AI_Agent_WebApp.Repositories.Interfaces.IStaffRepository, AI_Agent_WebApp.Repositories.Implementations.StaffRepository>();
builder.Services.AddScoped<AI_Agent_WebApp.Repositories.Interfaces.ISupplierRepository, AI_Agent_WebApp.Repositories.Implementations.SupplierRepository>();
builder.Services.AddScoped<AI_Agent_WebApp.Repositories.Interfaces.ISystemLogRepository, AI_Agent_WebApp.Repositories.Implementations.SystemLogRepository>();
builder.Services.AddScoped<AI_Agent_WebApp.Repositories.Interfaces.IUserRepository, AI_Agent_WebApp.Repositories.Implementations.UserRepository>();

// Register all services
builder.Services.AddScoped<AI_Agent_WebApp.Services.Interfaces.IAgentService, AI_Agent_WebApp.Services.Implementations.AgentService>();
builder.Services.AddScoped<AI_Agent_WebApp.Services.Interfaces.IArticleService, AI_Agent_WebApp.Services.Implementations.ArticleService>();
builder.Services.AddScoped<AI_Agent_WebApp.Services.Interfaces.IReviewService, AI_Agent_WebApp.Services.Implementations.ReviewService>();
builder.Services.AddScoped<AI_Agent_WebApp.Services.Interfaces.IStaffService, AI_Agent_WebApp.Services.Implementations.StaffService>();
builder.Services.AddScoped<AI_Agent_WebApp.Services.Interfaces.ISupplierService, AI_Agent_WebApp.Services.Implementations.SupplierService>();
builder.Services.AddScoped<AI_Agent_WebApp.Services.Interfaces.ISystemLogService, AI_Agent_WebApp.Services.Implementations.SystemLogService>();
builder.Services.AddScoped<AI_Agent_WebApp.Services.Interfaces.IUserService, AI_Agent_WebApp.Services.Implementations.UserService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
    });

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
