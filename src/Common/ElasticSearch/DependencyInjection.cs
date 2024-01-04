using System.Reflection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Common.ElasticSearch;

public static class DependencyInjection
{

    public static IHostBuilder AddElasticSearchLogging(this IHostBuilder host)
    {

        host.UseSerilog((context, configuration) =>
        {
            configuration.Enrich
                .FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Elasticsearch(
                    new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(
                        new Uri(context.Configuration["ElasticConfiguration:Uri"]))
                    {

                        IndexFormat =
                            $"applog-{Assembly.GetExecutingAssembly().GetName().Name.ToLower()}-{context.HostingEnvironment.EnvironmentName}-log-{DateTime.UtcNow:yy-MM-dd}",
                        AutoRegisterTemplate = true,
                        NumberOfShards = 2,
                        NumberOfReplicas = 1
                    }
                )
                .Enrich.WithProperty("Enviroment",context.HostingEnvironment.EnvironmentName)
                .ReadFrom.Configuration(context.Configuration);

        });



        return host;
    }

}