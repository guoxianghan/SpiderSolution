using HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpTaskDbContext;
using HttpTaskModel;
using System.ServiceModel;
using System.Threading;
using SpiderContract;
using SpiderClient;

namespace SpiderTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IRequestContract> channelFactory = new ChannelFactory<IRequestContract>("Request");
            var client = channelFactory.CreateChannel();
            SchedulerTask schedulerTask = new SpiderClient.SchedulerTask(client);
            while (true)
            {
                var list = client.HttpRequestCfgSingleGet(-1, 1);
                if (list != null)
                    foreach (var items in list.data)
                    {
                        client.HttpRequestCfgSaveStatus(items.Id, HttpTaskModel.TaskStatus.Running, items.CurrentPage, items.CurrentDate, items.info);
                        schedulerTask.RunSpider(items);
                    }
                Thread.Sleep(10000);
            }
        }
    }
}
