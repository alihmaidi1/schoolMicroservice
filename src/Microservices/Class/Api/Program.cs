
using Api.Middleware;
using Class;
using Class.Repository;
using ClassInfrutructure;
using ClassInfrutructure.Seed;
using Common.Api;
using Common.Authorization.Handlers;
using Common.ElasticSearch;
using Common.Email;
using Common.Enum;
using Common.Jwt;
using Common.Opentelemetry;
using Common.Redis;
using Common.Swagger;
using Hangfire;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


builder.Services.AddTransient<ICacheRepository,CacheRepository>();


builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddHangfireServer();


builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]??"null", failureStatus: HealthStatus.Degraded)
    .AddRedis(builder.Configuration["RedisConnection"]??"", failureStatus: HealthStatus.Degraded)
    .AddHangfire(null);

if (!Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development"))
{
    builder.Services.AddteleMetry(builder.Configuration);
    builder.Host.AddElasticSearchLogging();
}


builder.Services.Configure<MailSetting>(builder.Configuration.GetRequiredSection("Email"));
builder.Services.AddTransient<ErrorHandling>();
builder.Services.AddScoped<IAuthorizationHandler,RolesAuthorizationHandler>();
builder.Services.AddInfrustucture(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddJwtConfigration(builder.Configuration,JwtSchema.JwtStudent.ToString(),JwtSchema.JwtStudent.ToString(),JwtSchema.JwtAdmin.ToString());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen().AddOpenApi("student","student Service","v1","student description decoument");
builder.Services.AddHttpClient();
builder.Services.AddRepository();

builder.Services.AddClass();

var app = builder.Build();


using(var scope= app.Services.CreateScope()){
    await ClassDatabasebSeed.InitializeAsync(scope.ServiceProvider);
}

app.ConfigureOpenAPI("student");

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