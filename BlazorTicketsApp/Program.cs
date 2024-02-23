using BlazorTicketsApp;
using BlazorTicketsApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IResponseService, ResponseService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ITicketTagService, TicketTagService>();


await builder.Build().RunAsync();
