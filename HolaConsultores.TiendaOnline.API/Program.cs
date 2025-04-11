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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using HolaConsultores.TiendaOnline.Infraestructure.Repositories.User;
using HolaConsultores.TiendaOnline.Domain.Resources.User;
using HolaConsultores.TiendaOnline.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Register Services
builder.Services.AddScoped<IService<ColorResource, ColorInputResource>, ColorService>();
builder.Services.AddScoped<IService<SizeResource, SizeInputResource>, SizeService>();
builder.Services.AddScoped<IService<ProductResource, ProductInputResource>, ProductService>();
builder.Services.AddScoped<IService<ProductColorResource, ProductColorResource>, ProductColorService>();
builder.Services.AddScoped<IService<ProductSizeResource, ProductSizeResource>, ProductSizeService>();
builder.Services.AddScoped<IUserService<UserResource, UserResource>, UserService>();
#endregion

#region Register Repositories
builder.Services.AddScoped<IRepository<ColorModel>, ColorRepository>();
builder.Services.AddScoped<IRepository<SizeModel>, SizeRepository>();
builder.Services.AddScoped<IRepository<ProductModel>, ProductRepository>();
builder.Services.AddScoped<IRepository<ProductColorModel>, ProductColorRepository>();
builder.Services.AddScoped<IRepository<ProductSizeModel>, ProductSizeRepository>();
builder.Services.AddScoped<IRepository<UserModel>, UserRepository>();

#endregion

builder.Configuration.AddJsonFile("appsettings.json");

var secretKey = builder.Configuration.GetSection("settings")["secretKey"].ToString();
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };

});


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HolaConsultores Tienda Online", Version = "v1" });

    // 🔐 Añadimos soporte para autenticación con Bearer Token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce your token with he following format: Bearer token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
