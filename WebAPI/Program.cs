using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(
    Directory.GetCurrentDirectory())
);

builder.Services.AddDistributedMemoryCache();

// docker run --name my-redis -p 6379:6379 -d redis
builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379");

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// if (app.Environment.IsProduction())
//app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Enable the CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();