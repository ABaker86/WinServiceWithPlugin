using System;
using System.Threading;
using TopShelfTestAppWithPlugins;

namespace TSPlugin.HI
{
    public class HIPlugin : IExecute
    {
        public void Execute()
        {
            Console.WriteLine("I am executing the code for HI.");
            int Counter = 20;
            while (Counter > 0)
            {
                Console.WriteLine($"HI Plugin counter = {Counter}");
                Thread.Sleep(2000);
                Counter--;
            }
        }
    }
}
