using StructureMap;
using System;
using System.IO;
using Topshelf;
using Topshelf.StructureMap;

namespace TopShelfTestAppWithPlugins
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                var container = ConfigureContainer(); 
                x.UseStructureMap(container);

                x.Service<ServiceRunner>(s =>                                   
                {
                    s.ConstructUsing(name => new ServiceRunner(container.GetAllInstances<IExecute>()));                
                    s.WhenStarted(tc => tc.Start());                        
                    s.WhenStopped(tc => tc.Stop()); 
                });

                x.RunAsLocalSystem();
                x.SetDescription("Sample Topshelf Host");                  
                x.SetDisplayName("Stuff");                                  
                x.SetServiceName("Stuff"); 
            });                                                             

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  
            Environment.ExitCode = exitCode;
        }

        private static Container ConfigureContainer()
        {
            string pluginPath = Path.Combine(AppContext.BaseDirectory, "plugins");

            if (!Directory.Exists(pluginPath))
            {
                Directory.CreateDirectory(pluginPath);
            }
            return new Container(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.AssembliesFromPath(pluginPath);
                    scan.LookForRegistries();
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            });
        }
    }
}
