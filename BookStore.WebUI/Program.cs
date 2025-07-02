using BookStore.BusinessLayer.Abstract;
using BookStore.BusinessLayer.Concrete;
using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.EntityFramework;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookStoreContext>();

builder.Services.AddIdentity<AppUser, AppRole>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;

})
    .AddEntityFrameworkStores<BookStoreContext>()
  .AddDefaultTokenProviders();
builder.Services.AddControllers();


builder.Services.AddDbContext<BookStoreContext>();

builder.Services.AddScoped<IFooterDal, EfFooterDal>();
builder.Services.AddScoped<IFooterService, FooterManager>();

builder.Services.AddScoped<IEmailSender, EmailManager>();

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));


//var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();


builder.Services.AddControllersWithViews();

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



app.MapAreaControllerRoute(
    name: "admin",
      areaName: "Admin",
      pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );



app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");





app.Run();