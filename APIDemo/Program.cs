using APIDemo.Interfaces;
using APIDemo.Models;
using APIDemo.Repositories;
using APIDemo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//web api service
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
     option=> {
         option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
         option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
         {
             In = ParameterLocation.Header,
             Description = "Please enter a valid token",
             Name = "Authorization",
             Type = SecuritySchemeType.Http,
             BearerFormat = "JWT",
             Scheme = "Bearer"
         });
         option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });

     }
    );

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
//issure 
var issuer = builder.Configuration["JWT:issuer"];
var audience = builder.Configuration["JWT:audience"];
var key = builder.Configuration["JWT:key"];

builder.Services.AddAuthentication(
    option => {
        option.DefaultAuthenticateScheme =
        option.DefaultChallengeScheme =
        option.DefaultForbidScheme =
        option.DefaultScheme =
        option.DefaultSignInScheme =
        option.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    )
    .AddJwtBearer(opt => {
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = audience,
            ValidIssuer = issuer,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key))
        };
    });
builder.Services.AddAuthorization();


// Add Cors
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IUserAuthRepo, UserAuthRepo>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();

//attribute routing for api
app.MapControllers();
app.Run();
