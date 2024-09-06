using AiBlazorApp.Components;
using AiBlazorApp.Config;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppConfig");
if (string.IsNullOrEmpty(connectionString))
{
    throw new NullReferenceException("Connection string is missing");
}
// App Config 
var appConfig = new AppConfig();
builder.Configuration.AddAzureAppConfiguration(connectionString);
builder.Configuration.GetSection("BlazorApp:Config").Bind(appConfig);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddSingleton(appConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();