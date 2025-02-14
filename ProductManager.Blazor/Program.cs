using DR = ProductManager.Blazor.Dal.Repositories;
using DS = ProductManager.Blazor.Dal.Services;

using ProductManager.Blazor.Bll.Repositories;
using ProductManager.Blazor.Bll.Services;

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

builder.Services.AddScoped<DR.IProduitRepository, DS.ProduitService>();
builder.Services.AddScoped<IProduitRepository, ProduitService>();


await builder.Build().RunAsync();
