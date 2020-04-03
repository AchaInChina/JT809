﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Test.JT1078
{
    public class JT808_JT1078_0x1700_0x1701 : JT809SubBodies
    {
        /// <summary>
        /// 企业视频监控平台唯一编码，平台所属企业行政区域代码+平台公共编号
        /// </summary>
        public byte[] PlateFormId { get; set; }
        /// <summary>
        /// 归属地区政府平台使用的时效口令
        /// </summary>
        public byte[] AuthorizeCode1 { get; set; }
        /// <summary>
        /// 跨域地区政府平台使用的时效口令
        /// </summary>
        public byte[] AuthorizeCode2 { get; set; }
    }
}
