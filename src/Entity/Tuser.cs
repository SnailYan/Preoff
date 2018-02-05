using System;
using System.Collections.Generic;

namespace Preoff.Entity
{
    /// <summary>
    /// 用户类
    /// </summary>
    public partial class Tuser
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户帐号
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string CValue { get; set; }
    }
}
