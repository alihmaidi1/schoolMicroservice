using Newtonsoft.Json;
using Ocelot.Configuration.File;
using OcelotGateway.OcelotConfigration;

namespace OcelotGateway.Extension;

public static class ConfigrationBuilderExtension
{

    public static IConfigurationBuilder AddOcelotFileConfig(this IConfigurationBuilder builder, string folder)
    {

        const string primary = "ocelot.json";
        const string global = "ocelot.json";
        var files = Directory.GetFiles(folder, "*", SearchOption.AllDirectories);
        var fileConfigration = new MyFileConfigration();
        
        foreach (var file in files)
        {
            if (file.Equals(primary,StringComparison.OrdinalIgnoreCase))
            {
                
                continue;
            }

            var lines = File.ReadAllText(file);
            var config = JsonConvert.DeserializeObject<MyFileConfigration>(lines);

            if (file.Equals(global,StringComparison.OrdinalIgnoreCase))
            {
                fileConfigration.GlobalConfiguration = config.GlobalConfiguration;

            }
            
            fileConfigration.Aggregates.AddRange(config.Aggregates);
            fileConfigration.Routes.AddRange(config.Routes);
            fileConfigration.SwaggerEndPoints.AddRange(config.SwaggerEndPoints);
        }
        var json = JsonConvert.SerializeObject(fileConfigration);
        File.WriteAllText(primary,json);
        
        builder.AddJsonFile(primary, true, true);

        return builder;
    }
    
}