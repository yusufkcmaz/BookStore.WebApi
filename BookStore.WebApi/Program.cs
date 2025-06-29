using BookStore.BusinessLayer.Abstract;
using BookStore.BusinessLayer.Concrete;
using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.EntityFramework;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Baðýmlýlýklarý yönetmek 
builder.Services.AddDbContext<BookStoreContext>();

builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<BookStoreContext>()
.AddDefaultTokenProviders();


builder.Services.AddScoped<ICategoryDal , EfCategoryDal>();
builder.Services.AddScoped<ICategoryService , CategoryManager>();

builder.Services.AddScoped<IProductDal , EfProductDal>();
builder.Services.AddScoped<IProductService , ProductManager>();

builder.Services.AddScoped<IBillboardDal , EfBillboardDal>();
builder.Services.AddScoped<IBillboardService , BillboardManager >();

builder.Services.AddScoped<IFeatureDal , EfFeatureDal>();
builder.Services.AddScoped<IFeatureService , FeatureManager>();

builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
builder.Services.AddScoped<ISubscribeService , SubscribeManager>();

builder.Services.AddScoped<IQuoteDal, EfQuoteDal>();
builder.Services.AddScoped<IQuoteService, QuoteManager>();

builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

builder.Services.AddScoped<IFooterDal , EfFooterDal>();
builder.Services.AddScoped<IFooterService , FooterManager>();

builder.Services.AddScoped<IUserDal , EfUserDal>();
builder.Services.AddScoped<IUserService , UserManager>();

builder.Services.AddScoped<IEmailSender, EmailManager>();


var testService = builder.Services.BuildServiceProvider().GetService<ISubscribeService>();
Console.WriteLine(testService == null ? "Baðýmlýlýk yüklenemedi!" : "Baðýmlýlýk baþarýyla yüklendi!");


//CORS ayar.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("AllowAll"); 



app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);


app.MapAreaControllerRoute(
    name: "admin",
      areaName: "Admin",
      pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );
