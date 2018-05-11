namespace HttpTaskManage.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HttpTaskManage.HttpTaskDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HttpTaskManage.HttpTaskDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var e = new HttpRequestCfg() { Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8", CreateTime = DateTime.Now, Url = "http://m.ctrip.com/html5/hotel/sitemap-qingdao7", Host = "m.ctrip.com", Cookie = "", Encoding = "utf-8", Method = HttpMethod.GET, Referer = "", Origin = "", UACPU = "", UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.221 Safari/537.36 SE 2.X MetaSr 1.0", x_requested_with = "", WebName = "", ResponseType = FilenameExtension.Text, Upgrade_Insecure_Requests = "1", Accept_Encoding = "gzip, deflate, sdch", Accept_Language = "zh-CN,zh;q=0.8", Cache_Control = "max-age=0", Connection = "keep-live" };
            context.HttpRequestCfg.AddOrUpdate(e);
            context.SaveChanges();
        }
    }
}
