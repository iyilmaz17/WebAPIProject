using AutoMapper;
using Business.Abstract;
using Business.AutoMapper;
using Business.Concrete;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;



// CORS Etkinleþtimek için 
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
// CORS Etkinleþtimek için
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});
builder.Services.AddMemoryCache();
// Add services to the container.
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<IUserDal, EfUsersDal>();
builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddScoped<ICityDal, EfCityDal>();
builder.Services.AddScoped<ICityService,CityManager >();

builder.Services.AddScoped<IDistrictDal, EfDistrictDal>();
builder.Services.AddScoped<IDistrictService, DistrictManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IAddressDal, EfAddressDal>();
builder.Services.AddScoped<IAddressService, AddressManager>();


builder.Services.AddScoped<ICacheManager, MemoryCacheManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();


var assembly = System.Reflection.Assembly.GetExecutingAssembly();

// AutoMapper

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});
var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

// AutoMapper


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
