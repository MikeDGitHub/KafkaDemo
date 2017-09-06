using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ProtoBuf;

namespace ConsoleConsumer
{
    public static class ModelSerialization
    {
        public static byte[] SerializationBytes<T>(this T t)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, t);
                return ms.ToArray();
            }
        }
        public static T DeSerialize<T>(this byte[] value)
        {
            using (MemoryStream ms = new MemoryStream(value))
            {
                return Serializer.Deserialize<T>(ms);
            }
        }
    }
}
