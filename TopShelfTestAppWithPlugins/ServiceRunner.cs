using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TopShelfTestAppWithPlugins
{
    public class ServiceRunner
    {
        private readonly IEnumerable<IExecute> _plugins;
        private List<Thread> _threadpool = new List<Thread>();

        public ServiceRunner(IEnumerable<IExecute> plugins)
        {
            _plugins = plugins;
        }

        public void Start()
        {
            if (_plugins.Any())
            {
                //_plugins.ForEach(x => x.Execute());
                _plugins.ForEach(x => {
                    Thread thread = new Thread(x.Execute) {
                        IsBackground = true,
                        Name = $"{x.GetType().Name }_Thread"
                    };
                    
                    _threadpool.Add(thread);
                    thread.Start();
                });
                
            }
            
        }

        public void Stop()
        {
            
            _threadpool.ForEach(x => x.Abort());
            Console.WriteLine("Stoping service");
        }
    }
}
