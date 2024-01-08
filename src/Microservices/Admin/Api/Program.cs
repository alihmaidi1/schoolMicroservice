using Admin;
using Api.Middleware;
using Common.Api;
using Common.Authorization.Handlers;
using Common.ElasticSearch;
using Common.Email;
using Common.Enum;
using Common.Jwt;
using Common.Opentelemetry;
using Common.Swagger;
using Domain.Enum;
using Hangfire;
using HealthChecks.UI.Client;
using Infrutructure;
using Infrutructure.Seed;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],failureStatus:HealthStatus.Degraded)
    .AddRedis(builder.Configuration["RedisConnection"],failureStatus:HealthStatus.Degraded)
    .AddHangfire(null);




if (!Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development"))
{
    builder.Services.AddteleMetry(builder.Configuration);
    builder.Host.AddElasticSearchLogging();
}




// builder.Services.Configure<JwtSetting>(builder.Configuration.GetRequiredSection("JwtAdmin"));
builder.Services.Configure<MailSetting>(builder.Configuration.GetRequiredSection("Email"));

builder.Services.AddTransient<ErrorHandling>();
builder.Services.AddScoped<IAuthorizationHandler,RolesAuthorizationHandler>();
builder.Services.AddInfrustucture(builder.Configuration);


builder.Services.AddRepository(builder.Configuration);

builder.Services.AddAdmindependency();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddJwtConfigration(builder.Configuration,JwtSchema.JwtAdmin.ToString(),JwtSchema.JwtAdmin.ToString(),JwtSchema.JwtResetAdmin.ToString());


builder.Services.AddServices();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen().AddOpenApi("admin","admin dashboard","v1","admin description deocument");

builder.Services.AddHttpClient();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{

    
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {


    using(var scope= app.Services.CreateScope()){
        await DatabaseSeed.InitializeAsync(scope.ServiceProvider);
    }
    app.ConfigureOpenAPI("admin");
    app.UseSwagger();
    app.UseSwaggerUI();
// }


app.UseMiddleware<ErrorHandling>();



app.UseHttpsRedirection();



app.MapHealthChecks("/_healthcheck",new HealthCheckOptions()
{
    
    Predicate = _=>true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    
});


app.UseHangfireDashboard("/hangfiredashboard");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();