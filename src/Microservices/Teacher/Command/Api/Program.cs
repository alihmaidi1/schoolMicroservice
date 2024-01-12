using Api.Middleware;
using Common.Api;
using Common.Authorization.Handlers;
using Common.ElasticSearch;
using Common.Email;
using Common.Enum;
using Common.Jwt;
using Common.Opentelemetry;
using Common.Redis;
using Common.Swagger;
using Domain.Repository;
using Hangfire;
using HealthChecks.UI.Client;
using infrutructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Teacher;
using Teacherinfrutructure;
using Teacherinfrutructure.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTeacher(builder.Configuration);

builder.Services.AddTransient<ICacheRepository,CacheRepository>();

builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddHangfireServer();
builder.Services.AddHealthChecks()
     .AddSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]??"null", failureStatus: HealthStatus.Degraded)
     .AddRedis(builder.Configuration["RedisConnection"]??"", failureStatus: HealthStatus.Degraded);
     // .AddHangfire(null);


     if (!Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development"))
     {
          builder.Services.AddteleMetry(builder.Configuration);
          builder.Host.AddElasticSearchLogging();
     }





     builder.Services.Configure<MailSetting>(builder.Configuration.GetRequiredSection("Email"));


     builder.Services.AddTransient<ErrorHandling>();
     builder.Services.AddScoped<IAuthorizationHandler,RolesAuthorizationHandler>();
     builder.Services.AddInfrustucture(builder.Configuration);
     builder.Services.AddRepository();
     builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
     builder.Services.AddJwtConfigration(builder.Configuration,JwtSchema.JwtTeacher.ToString(),JwtSchema.JwtTeacher.ToString(),JwtSchema.JwtAdmin.ToString());



     builder.Services.AddEndpointsApiExplorer();
     builder.Services.AddSwaggerGen().AddOpenApi("teacher","Teacher Service","v1","Teacher description deocument");
     builder.Services.AddHttpClient();



var app = builder.Build();




using(var scope= app.Services.CreateScope()){
     await DatabaseSeed.InitializeAsync(scope.ServiceProvider);
}
app.ConfigureOpenAPI("teacher");
app.UseSwagger();
app.UseSwaggerUI();



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