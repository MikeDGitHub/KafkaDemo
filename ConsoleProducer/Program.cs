using RdKafka;
using System;
using System.Text;
using System.Threading;

namespace ConsoleProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Producer 接受一个或多个 BrokerList
            using (Producer producer = new Producer("10.0.9.56:9092"))
            //发送到一个名为 testtopic 的Topic，如果没有就会创建一个
            using (Topic topic = producer.Topic("testtopic"))
            {
                //将message转为一个 byte[]

                while (true)
                {
                    byte[] data = Encoding.UTF8.GetBytes($"Hello RdKafka,{DateTime.Now}");
                    DeliveryReport deliveryReport = topic.Produce(data).Result;
                    Console.WriteLine($"发送到分区：{deliveryReport.Partition}, Offset 为: {deliveryReport.Offset}");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}