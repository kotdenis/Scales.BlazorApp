using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Scales.BlazorApp;
using Scales.BlazorApp.Infrastructure.States;
using Scales.BlazorApp.Infrastructure.Weighing;
using Scales.BlazorApp.Services.Journal;
using Scales.BlazorApp.Constants;
using Scales.BlazorApp.Services.ReferenceBook;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IWeighingSimulator, WeighingSimulator>();
builder.Services.AddSingleton<JournalState>();
builder.Services.AddSingleton<RefBookState>();
builder.Services.AddScoped<IJournalService, JournalService>();
builder.Services.AddScoped<IRefBookService, RefBookService>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("myclient", cl =>
{
    cl.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
})
.AddHttpMessageHandler(sp =>
{
    var handler = sp.GetService<AuthorizationMessageHandler>()!
    .ConfigureHandler(
         authorizedUrls: new[] { UrlConstants.JOURNAL_URL, UrlConstants.REFBOOK_URL },
         scopes: new[] { "journalAPI", "referenceAPI" }
     );
    return handler;
});

builder.Services.AddScoped(
   sp => sp.GetService<IHttpClientFactory>()!.CreateClient("myclient"));

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("oidc", options.ProviderOptions);
});

await builder.Build().RunAsync();
