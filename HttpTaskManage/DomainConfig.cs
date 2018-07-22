using HttpTaskModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HttpTaskManage
{
    /// <summary>
    /// 站点域名管理
    /// </summary>
    [DataContract(IsReference = true)]
    public class DomainConfig : EntityBase
    {
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsEnable { get; set; } = true;
        /// <summary>
        /// 域名
        /// </summary>
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false)]
        public string Domain { get; set; }

    }
    /// <summary>
    /// 终端服务器管理
    /// </summary>
    [DataContract(IsReference = true)]
    public class TerminalServer : EntityBase
    {
        [MaxLength(20)]
        public string IP { get; set; }
        public uint Port { get; set; }
        [MaxLength(20)]
        public string Route { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; } = true;
        /// <summary>
        /// 设置封禁时间 /min
        /// </summary>
        public uint Time { get; set; }
    }
    /// <summary>
    /// 终端服务器与域名管理 用于配置该域名在该终端是否可用
    /// </summary>
    [DataContract]
    public class TerminalDomainServer
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; } = true;
        /// <summary>
        /// 设置封禁时间 /min
        /// </summary>
        public uint Time { get; set; }

        public DomainConfig DomainConfig { get; set; }
        public TerminalServer TerminalServer { get; set; }
    }
}
