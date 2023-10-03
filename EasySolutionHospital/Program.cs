using Blazored.SessionStorage;
using EasySolutionHospital;
using EasySolutionHospital.Helper;
using EasySolutionHospital.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CurrentUserState>();

builder.Services.AddScoped<IHealthPackageService, HealthPackageService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7027") });
builder.Services.AddScoped<IHttpService, HttpSsaervice>();

await builder.Build().RunAsync();
