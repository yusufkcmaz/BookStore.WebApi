using BookStore.BusinessLayer.Abstract;
using BookStore.BusinessLayer.Concrete;
using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.EntityFramework;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Baðýmlýlýklarý yönetmek 
builder.Services.AddDbContext<BookStoreContext>();

builder.Services.AddScoped<ICategoryDal , EfCategoryDal>();
builder.Services.AddScoped<ICategoryService , CategoryManager>();

builder.Services.AddScoped<IProductDal , EfProductDal>();
builder.Services.AddScoped<IProductService , ProductManager>();

builder.Services.AddScoped<IBillboardDal , EfBillboardDal>();
builder.Services.AddScoped<IBillboardService , BillboardManager >();

builder.Services.AddScoped<IFeatureDal , EfFeatureDal>();
builder.Services.AddScoped<IFeatureService , FeatureManager>();

builder.Services.AddScoped<IWriterDal , EfWriterDal>(); 
builder.Services.AddScoped<IWriterService , WriterManager >();



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
