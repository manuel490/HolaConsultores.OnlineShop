using System.Drawing.Imaging;
using System.Text.Json.Serialization;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IRepositories;
using HolaConsultores.TiendaOnline.Domain.Interfaces.IServices;
using HolaConsultores.TiendaOnline.Domain.Resources.Color;
using HolaConsultores.TiendaOnline.Domain.Resources.Product;
using HolaConsultores.TiendaOnline.Domain.Resources.ProductColor;
using HolaConsultores.TiendaOnline.Domain.Resources.ProductSize;
using HolaConsultores.TiendaOnline.Domain.Resources.Size;
using HolaConsultores.TiendaOnline.Infraestructure.Context;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using HolaConsultores.TiendaOnline.Infraestructure.Repositories.Color;
using HolaConsultores.TiendaOnline.Infraestructure.Repositories.Product;
using HolaConsultores.TiendaOnline.Infraestructure.Repositories.ProductColor;
using HolaConsultores.TiendaOnline.Infraestructure.Repositories.ProductSize;
using HolaConsultores.TiendaOnline.Infraestructure.Repositories.Size;
using HolaConsultores.TiendaOnline.Services.Color;
using HolaConsultores.TiendaOnline.Services.Product;
using HolaConsultores.TiendaOnline.Services.ProductColor;
using HolaConsultores.TiendaOnline.Services.ProductSize;
using HolaConsultores.TiendaOnline.Services.Size;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Register Services
builder.Services.AddScoped<IService<ColorResource, ColorInputResource>, ColorService>();
builder.Services.AddScoped<IService<SizeResource, SizeInputResource>, SizeService>();
builder.Services.AddScoped<IService<ProductResource, ProductInputResource>, ProductService>();
builder.Services.AddScoped<IService<ProductColorResource, ProductColorResource>, ProductColorService>();
builder.Services.AddScoped<IService<ProductSizeResource, ProductSizeResource>, ProductSizeService>();
#endregion

#region Register Repositories
builder.Services.AddScoped<IRepository<ColorModel>, ColorRepository>();
builder.Services.AddScoped<IRepository<SizeModel>, SizeRepository>();
builder.Services.AddScoped<IRepository<ProductModel>, ProductRepository>();
builder.Services.AddScoped<IRepository<ProductColorModel>, ProductColorRepository>();
builder.Services.AddScoped<IRepository<ProductSizeModel>, ProductSizeRepository>();
#endregion

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
