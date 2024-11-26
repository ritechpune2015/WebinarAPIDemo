using APIDemo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//web api service
builder.Services.AddControllers();
builder.Services.AddDbContextPool<ProductContext>(
     opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("scon"))
    );
var app = builder.Build();

//attribute routing for api
app.MapControllers();
app.Run();
