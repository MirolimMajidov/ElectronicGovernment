using BankManagementSystem.API.Middlewares;
using BankManagementSystem.Infrastructure;
using BankManagementSystem.Services;
using ElectronicGovernment.API.Repositories;
using ElectronicGovernment.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Adding custom Auth
builder.Services.AddMyAuth();

// Add services to the container.
builder.Services.AddDbContext<EGContext>(con => con.UseSqlServer(builder.Configuration["ConnectionString"])
  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddLogging();
builder.Services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Electronic Government application APIs", Version = "v1" });

    // Add the JWT Bearer authentication scheme
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
    };
    c.AddSecurityDefinition("Bearer", securityScheme);

    // Use the JWT Bearer authentication scheme globally
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
         { securityScheme, new List<string>() }
    });
});

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped(typeof(ISQLRepository<>), typeof(SQLRepository<>));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

//Calls migration to create or update the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<EGContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
