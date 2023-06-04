global using Microsoft.AspNetCore.Http;
global using Dapper;
global using Hepra_testing_Mudblazor.Server.Data;
global using Mapster;
global using Microsoft.Data.SqlClient;
global using Microsoft.AspNetCore.Mvc;
global using Domain.DTOs;
global using Domain.Entities;
global using Hepra_testing_Mudblazor.Server.Services.UserService;
global using Hepra_testing_Mudblazor.Server.Services.GroupService;

using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Asp.Versioning;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);

// Add data services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGroupService, GroupService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Validation
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();