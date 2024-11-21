using AutoMapper;
using Delivery.Service.Core.Interfaces;
using Delivery.Service.Core.Mapping;
using Delivery.Service.Core.Services;
using Delivery.Service.Core.Validators;
using Delivery.Service.Data.Contexts;
using Delivery.Service.Data.Interfaces;
using Delivery.Service.Data.Models;
using Delivery.Service.Data.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowClientApplication", corsBuilder =>
    {
        var clientDomain = builder.Configuration["ClientSettings:ClientDomain"];

        corsBuilder
            .WithOrigins(clientDomain)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
builder.Services.AddHttpClient("GetwayApi", ctx => {

    ctx.BaseAddress = new Uri(builder.Configuration["GetwayApiUrl"]);
});


builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IValidator<Deliverys>, DeliveryValidator>();

builder.Services.AddDbContext<DeliveryDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DeliveryDbConnectionString"), npgsqlOptionsAction: options => options.UseNetTopologySuite()));

MapperConfiguration mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile(new DeliveryProfile());
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DeliveryDbContext>();
    context.Database.Migrate();
}

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
