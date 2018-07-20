using HttpTaskModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTaskManage.ModelEntityConfiguration
{
    public class HttpRequestCfgEntityConfiguration : EntityTypeConfiguration<HttpRequestCfg>
    {
        public HttpRequestCfgEntityConfiguration()
        {
            this.HasMany(x => x.HttpRequestChildCfgs).WithRequired(c => c.Target);
        }
    }
}
