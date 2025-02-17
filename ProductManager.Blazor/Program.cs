using ProductManager.Blazor.Domain.Repositories;
using ProductManager.Blazor.Domain.Services;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProductManager.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Default", client =>
{
    client.BaseAddress = new Uri("https://localhost:7124/");
});

builder.Services.AddScoped<IProduitRepository, ProduitService>();


await builder.Build().RunAsync();
