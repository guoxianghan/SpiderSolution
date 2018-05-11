using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace HttpTaskManage
{
    public class HttpTaskDbContext : DbContext
    {
        private string _ConnectionStrings;

        public HttpTaskDbContext()
        {
            //_ConnectionStrings = System.Configuration.ConfigurationManager.ConnectionStrings["HttpTaskConnectionString"].ConnectionString; 
           
            Database.Initialize(true);
        }
 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
        }
        public HttpTaskDbContext(string connectionStrings):base(connectionStrings)
        {
            _ConnectionStrings = connectionStrings;
            Database.Initialize(true);
        }

 
        public DbSet<HttpRequestCfg> HttpRequestCfg { get; set; }
        public DbSet<HttpRequestChildCfg> HttpRequestChildCfg { get; set; }
        public DbSet<HttpResultCfg> HttpResultCfg { get; set; }
    }
}
