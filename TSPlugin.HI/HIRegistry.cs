using StructureMap;
using TopShelfTestAppWithPlugins;

namespace TSPlugin.HI
{
    public class HIRegistry : Registry
    {
        public HIRegistry()
        {
            For<IExecute>().Use<HIPlugin>();
        }
        
    }
}
