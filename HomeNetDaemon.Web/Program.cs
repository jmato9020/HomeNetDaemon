using HomeNetDaemon.Web.Components;
using System.Reflection;
using NetDaemon.AppModel;
using NetDaemon.Extensions.Logging;
using NetDaemon.Runtime;
using HomeNetDaemon.Access;
using HomeNetDaemon.Web;
var builder = WebApplication.CreateBuilder(args);


builder.Host
  .UseNetDaemonAppSettings()
  .UseNetDaemonDefaultLogging()
  .UseNetDaemonRuntime()
  .ConfigureServices((_, services) =>
  {
    services
        .AddAppsFromAssembly(Assembly.GetExecutingAssembly())
        .AddNetDaemonStateManager()
        .AddHomeAssistantGenerated().AddSingleton<IEntities,Entities>();
  });


// adding MVC / WebAPI controllers
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



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

// use controller routes
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
