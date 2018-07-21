namespace DBContext.Migrations
{
    using CommonUtl;
    using HttpTaskModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HttpTaskDbContext.HttpTaskDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HttpTaskDbContext.HttpTaskDBContext context)
        {
            var co = new List<Cookie>();
            co.Add(new Cookie() { Name = "PHPSESSID", Value = "qs4f6ttm7g5vl2rqiqh7aia7m1", Domain = "www.chinesesfpm.com" });
            Guid guid = Guid.NewGuid();
            HttpRequestCfg obj = new HttpRequestCfg() { CreatedTime = DateTime.Now, HasChildTask = false, Host = "www.chinesesfpm.com", PageMax = 20, WebName = "chinesesfpm", TaskStatus = HttpTaskModel.TaskStatus.Created, PageMin = 1, Key = guid, SchedulerType = HttpTaskManage.SchedulerType.Page };
            //obj.PageMax = 20;
            //obj.PageMin = 1;
            obj.HttpRequestChildCfgs.Add(new HttpRequestChildCfg()
            {
                Key = guid,
                Accept = "application/json, text/javascript, */*; q=0.01",
                Accept_Encoding = "gzip, deflate",
                Accept_Language = "zh-CN,zh;q=0.9",
                ContentType = "application/x-www-form-urlencoded; charset=UTF-8",
                Host = "www.chinesesfpm.com",
                Method = HttpMethod.POST,
                //UserAgent = "",
                UACPU = "",
                Encoding = "utf-8",
                Url = "http://www.chinesesfpm.com/index/index/getAjaxSearch.html",
                ResponseType = FilenameExtension.Text,
                PostData = "court_sheng=&court_city=&court_arer=&province=&city=&district=&min_price=&max_price=&do_paimai=1&do_s_type=&biaodi_type=&do_isajax=1&page={page}&do_label=0",
                PostDataType = PostDataType.String,
                x_requested_with = "XMLHttpRequest",
                //PHPSESSID=qs4f6ttm7g5vl2rqiqh7aia7m1
                Cookie = co.ToJson()
            });
            var re = context.HttpRequestCfg.Add(obj);
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
