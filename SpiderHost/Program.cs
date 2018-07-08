using SpiderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
 
namespace SpiderMasterHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uri[] uri =new Uri[1];
            //uri[0] = new Uri("tcp:localhost");
            ServiceHost host = new ServiceHost(typeof(RequestService),new Uri("net.tcp://localhost:8089/"));
            //host.h
            host.Opened += delegate
            {
                Console.WriteLine("RequestContract已经启动！");
            };
            //host.Opened += (x,y) => { };
            host.Open();
            Console.ReadKey();
        }
    }
}
