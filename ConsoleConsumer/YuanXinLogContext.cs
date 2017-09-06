using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace ConsoleConsumer
{
    [ProtoContract]
    public class YuanXinLogContext
    {
        [ProtoMember(1)]
        public string ContextId { get; set; }
        [ProtoMember(2)]
        public DateTime StartTime { get; set; }
        [ProtoMember(3)]
        public TimeSpan RunTime { get; set; }
        [ProtoMember(4)]
        public DateTime EndTime { get; set; }
        [ProtoMember(5)]
        public string RequestData { get; set; }
        [ProtoMember(6)]
        public string ResponseData { get; set; }
        [ProtoMember(7)]
        public string Url { get; set; }
        [ProtoMember(8)]
        public string ServiceIp { get; set; }
        [ProtoMember(9)]
        public string ActionInfo { get; set; }
    }
}
