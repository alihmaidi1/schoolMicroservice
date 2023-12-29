using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot();
builder.Services.AddSwaggerForOcelot(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

builder.Configuration.AddJsonFile($"ocelot.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json");

var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.UseSwaggerForOcelotUI(option =>
{

    option.PathToSwaggerGenerator = "/swagger/docs";

});


app.UseOcelot().Wait();
app.Run();