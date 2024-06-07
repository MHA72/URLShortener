using URLShortener.Context;
using Microsoft.EntityFrameworkCore;
using URLShortener.Database.Repository;
using Infrastructure.Database.IRepository;
using Application.BusinessServices.UseCase;
using Application.BusinessServices.IUseCase;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<UrlShortenerContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("sqlite")));

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUrlUseCase, UrlUseCase>();
builder.Services.AddScoped<IUrlRepository, UrlRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UrlShortenerContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();