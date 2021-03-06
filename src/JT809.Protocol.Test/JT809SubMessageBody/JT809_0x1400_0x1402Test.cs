﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Enums;
using JT809.Protocol.Internal;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1400_0x1402Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        [Fact]
        public void Test1()
        {
            JT809_0x1400_0x1402 jT809_0x1400_0x1402 = new JT809_0x1400_0x1402
            {
                 WarnSrc= JT809WarnSrc.车载终端,
                 WarnType = JT809WarnType.偏离路线报警,
                 WarnTime=DateTime.Parse("2018-09-26"),
                 InfoContent = "gfdf454553",
                 InfoID = 3344,
            };
            var hex = JT809Serializer.Serialize(jT809_0x1400_0x1402).ToHexString();
            // "01 00 0B 00 00 00 00 5B AA 5B 80 00 00 0D 10 00 00 00 0A 67 66 64 66 34 35 34 35 35 33"
            Assert.Equal("01000B000000005BAA5B8000000D100000000A67666466343534353533", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "01 00 0B 00 00 00 00 5B AA 5B 80 00 00 0D 10 00 00 00 0A 67 66 64 66 34 35 34 35 35 33".ToHexBytes();
            JT809_0x1400_0x1402 jT809_0x1400_0x1402 = JT809Serializer.Deserialize<JT809_0x1400_0x1402>(bytes);
            Assert.Equal(JT809WarnSrc.车载终端, jT809_0x1400_0x1402.WarnSrc);
            Assert.Equal("gfdf454553", jT809_0x1400_0x1402.InfoContent);
            Assert.Equal(JT809WarnType.偏离路线报警, jT809_0x1400_0x1402.WarnType);
            Assert.Equal((uint)3344, jT809_0x1400_0x1402.InfoID);
            Assert.Equal((uint)10, jT809_0x1400_0x1402.InfoLength);
            Assert.Equal(DateTime.Parse("2018-09-26"), jT809_0x1400_0x1402.WarnTime);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1400_0x1402 jT809_0x1400_0x1402 = new JT809_0x1400_0x1402
            {
                SourcePlatformId = "12345678900",
                WarnType = JT809WarnType.偏离路线报警,
                WarnTime = DateTime.Parse("2020-04-23"),
                StartTime= DateTime.Parse("2020-04-23"),
                EndTime= DateTime.Parse("2020-04-24"),
                VehicleNo="粤A11111",
                VehicleColor= JT809VehicleColorType.蓝色,
                DestinationPlatformId = "12345678900",
                InfoContent = "gfdf454553",
            };
            var hex = JT809_2019_Serializer.Serialize(jT809_0x1400_0x1402).ToHexString();
            Assert.Equal("3132333435363738393030000B000000005EA06A00000000005EA06A00000000005EA1BB80D4C141313131313100000000000000000000000000013132333435363738393030000000000000000A67666466343534353533", hex);
        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "3132333435363738393030000B000000005EA06A00000000005EA06A00000000005EA1BB80D4C141313131313100000000000000000000000000013132333435363738393030000000000000000A67666466343534353533".ToHexBytes();
            JT809_0x1400_0x1402 jT809_0x1400_0x1402 = JT809_2019_Serializer.Deserialize<JT809_0x1400_0x1402>(bytes);
            Assert.Equal("12345678900", jT809_0x1400_0x1402.SourcePlatformId);
            Assert.Equal("gfdf454553", jT809_0x1400_0x1402.InfoContent);
            Assert.Equal(JT809WarnType.偏离路线报警, jT809_0x1400_0x1402.WarnType);
            Assert.Equal((uint)10, jT809_0x1400_0x1402.InfoLength);
            Assert.Equal(DateTime.Parse("2020-04-23"), jT809_0x1400_0x1402.WarnTime);
            Assert.Equal(DateTime.Parse("2020-04-23"), jT809_0x1400_0x1402.StartTime);
            Assert.Equal(DateTime.Parse("2020-04-24"), jT809_0x1400_0x1402.EndTime);
            Assert.Equal("粤A11111", jT809_0x1400_0x1402.VehicleNo);
            Assert.Equal(JT809VehicleColorType.蓝色, jT809_0x1400_0x1402.VehicleColor);
            Assert.Equal("12345678900", jT809_0x1400_0x1402.DestinationPlatformId);
        }
    }
}
