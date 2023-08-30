using Application.Interface.Base;
using Application.Repository.Base;
using Authorize.Services;
using Blazored.LocalStorage;
using EndPoint.Admin.Client;
using EndPoint.Admin.Client.ClientServices;
using EndPoint.Admin.Client.ClientServices.Base;
using Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Persistence.Context;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthorizationServices>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddTransient<IBaseHttpService, BaseHttpService>();
builder.Services.AddTransient<IDataBaseContext, DataBaseContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<UserServices>();
builder.AddClientServices();
await builder.Build().RunAsync();
