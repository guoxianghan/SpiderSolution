using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using HttpTaskModel;
using HttpTaskManage.ModelEntityConfiguration;

namespace HttpTaskDbContext
{
    public class HttpTaskDBContext : DbContext
    {
        private string _ConnectionStrings;

        public HttpTaskDBContext() : base("name=SpiderTask")
        { 
            //Console.WriteLine("_ConnectionStrings");
            //_ConnectionStrings = System.Configuration.ConfigurationManager.ConnectionStrings["HttpTaskDb"].ConnectionString;
            //_ConnectionStrings = "Data Source=.;Pooling=true;  Min Pool Size=0;Max Pool Size=500; Initial Catalog=HttpTaskDb;User ID=sa;Password=123, providerName = System.Data.SqlClient";
            //Database.Initialize(true);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HttpTaskDBContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new HttpRequestCfgEntityConfiguration());
            //modelBuilder.Entity<HttpRequestChildCfg>().HasRequired(x=>x.HttpRequestId).WithMany(d=>d.)
            //modelBuilder.RegisterEntityType(typeof(HttpRequestCfg));
        }
        public HttpTaskDBContext(string connectionStrings) : base(connectionStrings)
        {
            _ConnectionStrings = connectionStrings;
            //Database.Initialize(true);
        }
        public DbSet<HttpRequestCfg> HttpRequestCfg { get; set; }
        public DbSet<HttpRequestChildCfg> HttpRequestChildCfg { get; set; }
        public DbSet<HttpResponseCfg> HttpResultCfg { get; set; }
        ~HttpTaskDBContext()
        {
            this.Dispose(true);
        }


    }
}
