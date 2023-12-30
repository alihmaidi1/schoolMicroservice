using MMLib.SwaggerForOcelot.Configuration;
using Ocelot.Configuration.File;
using Swashbuckle.AspNetCore.Swagger;

namespace OcelotGateway.OcelotConfigration;

public class MyFileConfigration
{

    public MyFileConfigration()
    {
        
        
        this.Routes = new List<MyFileRoute>();
        this.GlobalConfiguration = new FileGlobalConfiguration();
        this.Aggregates = new List<FileAggregateRoute>();
        this.DynamicRoutes = new List<FileDynamicRoute>();
        this.SwaggerEndPoints = new List<SwaggerEndPointOptions>();
    }
    public List<MyFileRoute> Routes { get; set; }

    public List<FileDynamicRoute> DynamicRoutes { get; set; }

    public List<FileAggregateRoute> Aggregates { get; set; }

    public FileGlobalConfiguration GlobalConfiguration { get; set; }
    
    public List<SwaggerEndPointOptions> SwaggerEndPoints { get; set; }
    
    
    
}