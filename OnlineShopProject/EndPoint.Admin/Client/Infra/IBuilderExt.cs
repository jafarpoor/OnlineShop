using EndPoint.Admin.Client.ClientServices.Base;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace Infra;
public static class IBuilderExt
    {
        /// <summary>
        /// تمامی سرویس های کلاینت در این متد اضافه میشوند
        /// </summary>
        public static void AddClientServices(this WebAssemblyHostBuilder builder)
        {

            builder.Services.AddAuthorizationCore();
            //builder.Services.AddTransient<AuthenticationStateProvider, BffAuthenticationStateProvider>();

            //builder.Services.AddTransient<AntiforgeryHandler>();

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddHttpClient("backend", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            //    .AddHttpMessageHandler<AntiforgeryHandler>();
            //builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("backend"));



            builder.Services.AddTransient<IBaseHttpService, BaseHttpService>();

            //builder.Services.AddTransient<DetailAccBookSummaryServicesRep>();
            //builder.Services.AddTransient<DialogService>();
            //builder.Services.AddTransient<NotificationService>();
            //builder.Services.AddTransient<TooltipService>();
            //builder.Services.AddTransient<ContextMenuService>();
            //builder.Services.AddTransient<FileService>();


        }
    }

