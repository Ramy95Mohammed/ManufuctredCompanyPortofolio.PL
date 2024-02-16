using ManufuctredCompanyPortofolio.BL.GenericRepositories;
using ManufctredCompanyPortofolio.BLL.IGenericRepositories;
using ManufuctredCompanyPortofolio.DAL;
using ManufuctredCompanyPortofolio.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using ManufctredCompanyPortofolio.BLL.IUnitOfWork;
using ManufctredCompanyPortofolio.BLL.UnitOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using ManufuctredCompanyPortofolio.PL.Mapers;
using ManufuctredCompanyPortofolio.DAL.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("ManufctredCompanyConn"));
   
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IProgramLanguage, ProgramLanguage>();
builder.Services.AddAutoMapper(m => m.AddProfile(new UserProfile()));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = new PathString("/Account/Login");
    options.AccessDeniedPath = new PathString("/Home/Error");
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 5;
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<AppDbContext>().AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);
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

app.MapControllerRoute(
    name: "default"
    , "{controller=Account}/{action=Login}/{id?}");


app.Run();
