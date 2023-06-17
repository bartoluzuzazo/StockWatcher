using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Proj_APBD.Client;
using Syncfusion.Blazor;
using Syncfusion.Licensing;


var licenseKey = "MDAxQDMyMzEyZTMwMmUzMGlJZWU2cjQ1aURJOG5SOXNiUFZGQWJOVmNlMXJrQmFZRE0reUFJQTVMVnM9";


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
SyncfusionLicenseProvider.RegisterLicense(licenseKey);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();
