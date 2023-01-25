using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Commons.Modules;
using RoyalCode.Yasamen.Forms.Modules;
using RoyalCode.Yasamen.Forms.Validation;
using RoyalCode.Yasamen.Demos.Forms;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ValidadorFriend>();
builder.Services.AddSingleton<IValidator<Friend>>(sp => sp.GetRequiredService<ValidadorFriend>());

// yasamen js modules
builder.Services.AddScoped<CommonsJsModule>();
builder.Services.AddScoped<ScrollJsModule>();
builder.Services.AddScoped<ToggleJsModule>();
builder.Services.AddScoped<CssStyleJsModule>();
builder.Services.AddScoped<FormsJsModule>();
builder.Services.AddScoped<EventsJsModule>();

// yasamen data services
builder.Services.AddDataServices();

builder.Services.AddScoped<IValidatorProvider, ValidatorProvider>();
builder.Services.Subscribes<CityServices>();

RoyalCode.Yasamen.Icons.Bootstrap.BootstrapIcons.Include();

Tracer.IsActive = true;
Tracer.UseAllowedList = true;
Tracer.AllowedComponents.Add("ModelEditor");
Tracer.AllowedComponents.Add("FieldBase");

await builder.Build().RunAsync();
