using Blazored.LocalStorage;
using EcommerceMedDistUI;
using EcommerceMedDistUI.Authentication;
using EcommerceMedDistUI.Services;
using EcommerceMedDistUI.Services.IServices;
using EcommerceMedDistUI.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<IProducsServices, ProducsServices>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IPaymentServices, PaymentServices>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton<StateContainer>();

#region Authentication
builder.Services.AddScoped(typeof(AccountClaimsPrincipalFactory<RemoteUserAccount>), typeof(CustomAccountFactory));
builder.Services.AddScoped<CustomAuthorizationHeaderHandler>();
var backendOrigin = builder.Configuration["BaseAPIUrl"]!;
builder.Services
    .AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WebAPI"))
    .AddHttpClient("WebAPI", client => client.BaseAddress = new Uri(backendOrigin))
    .AddHttpMessageHandler<CustomAuthorizationHeaderHandler>();
builder.Services.AddCustomAuthentication(options =>
{
    builder.Configuration.Bind("Oidc", options.ProviderOptions);
    options.UserOptions.RoleClaim = "roles";
});
builder.Services.AddApiAuthorization();
#endregion

await builder.Build().RunAsync();
