using AutoMapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Pacagroup.Ecommerce.Application.Interfaces;
using Pacagroup.Ecommerce.Application.Main;
using Pacagroup.Ecommerce.Domain.Core;
using Pacagroup.Ecommerce.Domain.Interfaces;
using Pacagroup.Ecommerce.Infraestructura.Data;
using Pacagroup.Ecommerce.Infraestructure.Interface;
using Pacagroup.Ecommerce.Infraestructure.Repository;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Transversal.Mapper;
using System.Data;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;
using Pacagroup.Ecommerce.Services.WebApi.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
var myPolicy = "policyApiEcommerce";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(x=> x.AddProfile(new MappingsProfile()));

var appsettingConfigure = builder.Configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appsettingConfigure);

var appSettingSection = appsettingConfigure.Get<AppSettings>();
builder.Services.AddCors(options => options.AddPolicy(myPolicy, config => config.WithOrigins(builder.Configuration["Config:OriginsCors"])
                                                                                                                 .AllowAnyHeader()
                                                                                                                 .AllowAnyMethod()));



builder.Services.AddSingleton<IConnectionsFactory, ConnectionFactory>();
builder.Services.AddScoped<ICustomerRepository, CustomersRepository>();
builder.Services.AddScoped<ICustomerDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersApplication, CustomersApplication>();
builder.Services.AddScoped<IUserApplication, UserApplication>();
builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var Key = Encoding.ASCII.GetBytes(appSettingSection.Secret);
var issuer = appSettingSection.Issuer;
var Audience = appSettingSection.Audience;

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var userId = int.Parse(context.Principal.Identity.Name);
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
    x.IncludeErrorDetails = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Key),
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Hace que Swagger UI esté en la raíz
});
app.UseCors(myPolicy);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
