using Common.Swagger;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.Hubs;
using SignalRServer.Hubs.Notifications.Admin;
using SignalRServer.Hubs.Notifications.Student;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSingleton<IUserIdProvider, NameUserIdProvider>();

builder.Services.AddSignalR();
builder.Services.AddOpenApi("realtime","realtime with signalr","v1","realtime signalr description",true);


var app = builder.Build();


app.ConfigureOpenAPI("realtime");    

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<AdminHub>("adminhub");

app.MapHub<StudentHub>("studenthub");

app.Run();