using Blazored.LocalStorage;
using Blazored.Toast;
using Medical_App_1.Client.Handlers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Medical_App_1.Client.Services;
using Medical_App_1.Client.Services.MedicalService.Interfaces;
using Medical_App_1.Client.Services.MedicalService;
//using Syncfusion.Blazor;
using MudBlazor.Services;
namespace Medical_App_1.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTg0MDE3QDMxMzkyZTM0MmUzMEJrS1JpRndWU3ZVMTVIdTRZQU1Sb21MZFRPa1I4QlEwNENpLythWCs0SW89");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            // builder.Services.AddSyncfusionBlazor();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            AddHttpClients(builder);

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddTransient<CustomAuthorizationHandler>();
            builder.Services.AddBlazoredToast();
            builder.Services.AddMudServices();
            await builder.Build().RunAsync();
        }
        public static void AddHttpClients(WebAssemblyHostBuilder builder)
        {
            ////transactional named http clients
            //builder.Services.AddHttpClient<IProfileViewModel, ProfileViewModel>
            //    ("ProfileViewModelClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            //    .AddHttpMessageHandler<CustomAuthorizationHandler>();

            //builder.Services.AddHttpClient<IContactsViewModel, ContactsViewModel>
            //    ("ContactsViewModelClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            //    .AddHttpMessageHandler<CustomAuthorizationHandler>();

            //builder.Services.AddHttpClient<ISettingsViewModel, SettingsViewModel>
            //    ("SettingsViewModelClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            //    .AddHttpMessageHandler<CustomAuthorizationHandler>();

            //authentication http clients RegisterUserServiceClient
            builder.Services.AddHttpClient<IRegisterUserServiceClient, RegisterUserServiceClient>
                ("LoginViewModelClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient<ILoginServices, LoginServices>
                ("LoginViewModelClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));


            builder.Services.AddHttpClient<IMedicineServiceClient, MedicineServiceClient>
              ("MedicineServiceClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)).AddHttpMessageHandler<CustomAuthorizationHandler>(); ;

            builder.Services.AddHttpClient<IPurchaseServiceClient, PurchaseServiceClient>
              ("PurchaseServiceClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)).AddHttpMessageHandler<CustomAuthorizationHandler>();

            builder.Services.AddHttpClient<IReportServiceClient, ReportServiceClient>
             ("ReportServiceClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)).AddHttpMessageHandler<CustomAuthorizationHandler>();

            builder.Services.AddHttpClient<IUserAccountServiceClient, UserAccountServiceClient>
            ("UserAccountServiceClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)).AddHttpMessageHandler<CustomAuthorizationHandler>();

            builder.Services.AddHttpClient<ISalesServiceClient, SalesServiceClient>
("UserAccountServiceClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)).AddHttpMessageHandler<CustomAuthorizationHandler>();
        }
    }
}
