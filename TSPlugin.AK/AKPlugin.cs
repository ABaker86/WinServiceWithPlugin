using System;
using System.Threading;
using TopShelfTestAppWithPlugins;

namespace TSPlugin.AK
{
    public class AKPlugin : IExecute
    {
        
        public void Execute()
        {
            Console.WriteLine("I am executing the code for AK.");
            int Counter = 20;
            while (Counter > 0)
            {
                Console.WriteLine($"AK Plugin counter = {Counter}");
                Thread.Sleep(2000);
                Counter--;
            }
        }
    }
}
