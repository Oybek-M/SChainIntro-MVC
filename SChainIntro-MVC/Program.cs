using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.BLL.Common.Validator;
using SChainIntro_MVC.BLL.Common.Validator.Validator;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.BLL.Services;
using SChainIntro_MVC.Data;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;
using SChainIntro_MVC.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// Connection String | DataBase with MySQL:
//var connectionString = builder.Configuration.GetConnectionString("LocalDB3");
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
//});
// ____________________


// Db Context with SqlServer
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
// ____________________


// DB Context with PostgreSQL
// builder.Services.AddDbContext<AppDbContext>(options =>
// {
//     options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDB"));
//     options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
// });
// ____________________



// Validators
builder.Services.AddTransient<IValidator<Post>, PostValidator>();
builder.Services.AddTransient<IValidator<Service>, ServiceValidator>();
builder.Services.AddTransient<IValidator<Video>, VideoValidator>();
builder.Services.AddTransient<IValidator<Partner>, PartnerValidator>();
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
