using Microsoft.Extensions.Hosting.Internal;
using Ocelot.Configuration.File;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotGateway;
using OcelotGateway.Extension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOcelot();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddOcelotFileConfig(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
builder.Services.AddSwaggerForOcelot(builder.Configuration);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.UseSwaggerForOcelotUI(option =>
{
  
    
//
     option.PathToSwaggerGenerator = "/swagger/docs";
//
});


app.UseOcelot().Wait();
app.Run();