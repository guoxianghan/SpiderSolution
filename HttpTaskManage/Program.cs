using System;

namespace HttpTaskDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpTaskDbContext db = new HttpTaskDbContext("HttpTaskConnectionString");
            //var e = new HttpRequestCfg() { Accept = "", Connectionlimit = 12, ContentType = "12", CreateTime = DateTime.Now };
            //e.HttpRequestChildCfgs.Add(new HttpRequestChildCfg { Accept = "fasdf", ContentType = "adf", CreateTime = DateTime.Now });
            //db.HttpRequestCfg.Add(e);
            //db.SaveChanges();

            Console.WriteLine("Hello World!");
        }
    }
}