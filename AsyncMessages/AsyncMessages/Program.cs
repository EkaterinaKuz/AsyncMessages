using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncMessages
{
    class Program
    {
        private static void CreateMessage(BlockingCollection<string> blockingCollection)
        {
            for(int i = 0; i < 1000; i++)
            {
                Message.Create(blockingCollection);
                Console.WriteLine("\nCurrent number of emails sent - " + i);
            }
        }

        private static void Sending(BlockingCollection<string> blockingCollection)
        {
            var send = Task.Run(async () =>
            {
                await Message.Send();
            });
        }

        public static void Main(string[] args)
        {
            var blockingCollection = new BlockingCollection<string>();

            var threadCreate = new Thread(new ThreadStart(() => CreateMessage(blockingCollection)));
            threadCreate.Start();

            var threadProcess = new Thread(new ThreadStart(() => Sending(blockingCollection)));
            threadProcess.Start();
        }
    }
}
