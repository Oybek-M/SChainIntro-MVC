using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.BLL.Services;
using SChainIntro_MVC.Data;
using SChainIntro_MVC.Data.Interfaces;
using SChainIntro_MVC.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// Connection String | DataBase with MySQL:
var connectionString = builder.Configuration.GetConnectionString("LocalDB1");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
// ____________________



// Services
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IFileService, FileService>();

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IPartnerService, PartnerService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<IStaticsService, StaticsService>();
builder.Services.AddTransient<IVideoService, VideoService>();
// ____________________



// HttpContextAccessor
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// ____________________



// Auth
builder.Services.AddAuthentication()
    .AddCookie("Admin", config =>
    {
        config.LoginPath = "/admin/auth/login";
    });
// ____________________



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
