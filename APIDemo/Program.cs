using APIDemo.Interfaces;
using APIDemo.Models;
using APIDemo.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//web api service
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<ProductContext>(
     opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("scon"))
    );

builder.Services.AddIdentity<AppUser, IdentityRole>(
     opt => {
         opt.Password.RequireNonAlphanumeric = false;
         opt.Password.RequiredLength = 4;
         opt.Password.RequireDigit = false;
         opt.Password.RequireLowercase = false;
         opt.Password.RequireUppercase = false;
     }
    ).AddEntityFrameworkStores<ProductContext>();

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IUserAuthRepo, UserAuthRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//attribute routing for api
app.MapControllers();
app.Run();
