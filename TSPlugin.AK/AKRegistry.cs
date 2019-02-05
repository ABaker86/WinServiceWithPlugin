using StructureMap;
using TopShelfTestAppWithPlugins;

namespace TSPlugin.AK
{
    public class AKRegistry : Registry
    {
        public AKRegistry()
        {
            For<IExecute>().Use<AKPlugin>();
        }
    }
}
