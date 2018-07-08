using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using HttpTaskModel;

namespace HttpTaskDbContext
{
    public class HttpTaskDBContext : DbContext
    {
        private string _ConnectionStrings;

        public HttpTaskDBContext()
        {
            //_ConnectionStrings = System.Configuration.ConfigurationManager.ConnectionStrings["HttpTaskConnectionString"].ConnectionString; 

            Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public HttpTaskDBContext(string connectionStrings) : base(connectionStrings)
        {
            _ConnectionStrings = connectionStrings;
            Database.Initialize(true);
        }
        public DbSet<HttpRequestCfg> HttpRequestCfg { get; set; }
        public DbSet<HttpRequestChildCfg> HttpRequestChildCfg { get; set; }
        public DbSet<HttpResultCfg> HttpResultCfg { get; set; }
        ~HttpTaskDBContext()
        {
            this.Dispose(true);
        }


    }
}
