global using Domain.Entities;
global using Domain.DTOs;
global using Hepra_testing_Mudblazor.Client.Services.UserService;
global using Hepra_testing_Mudblazor.Client.Services.GroupService;

using Hepra_testing_Mudblazor.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Hepra_testing_Mudblazor.Client.Services.GroupService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGroupService, GroupService>();

await builder.Build().RunAsync();