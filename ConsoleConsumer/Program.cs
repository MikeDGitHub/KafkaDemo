using RdKafka;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using ProtoBuf;

namespace ConsoleConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Dictionary<string, List<YuanXinLogContext>> dictionary = new Dictionary<string, List<YuanXinLogContext>>();
            //配置消费者组
            try
            {
                var config = new Config() { GroupId = "example-csharp-consumer" };
                using (var consumer = new EventConsumer(config, "10.0.8.145:9092,10.0.8.147:9092"))
                {
                    //注册一个事件
                    consumer.OnMessage += (obj, msg) =>
                    {
                        var myclient = msg.Payload.DeSerialize<YuanXinLogContext>();
                        var key = myclient.ContextId;
                        if (dictionary.ContainsKey(key))
                        {
                            List<YuanXinLogContext> list;
                            dictionary.TryGetValue(key, out list);
                            list.Add(myclient);
                            dictionary.Remove(key);
                            dictionary.Add(key, list);
                        }
                        else
                        {
                            dictionary.Add(key, new List<YuanXinLogContext> { myclient });
                        }
                        Console.WriteLine($"Topic: {msg.Topic} Partition: {msg.Partition} Offset: {msg.Offset}");
                    };

                    //订阅一个或者多个Topic
                    var tops = new List<string>();
                    tops.Add("LoggerTopic");
                    consumer.Subscribe(tops);

                    //启动
                    consumer.Start();
                    Console.WriteLine("Started consumer, press enter to stop consuming");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }

    }
}