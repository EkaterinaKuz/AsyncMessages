using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncMessages
{
    class Message
    {
        public static void Create(BlockingCollection<string> blockingCollection)
        {
            var message = Guid.NewGuid().ToString();
            
            if (blockingCollection.TryAdd(message))
            {
                Console.WriteLine("\nCurrent number of messages in the queue - " + blockingCollection.Count);
            }
        }

        public static async Task Send()
        {
            var random = new Random().Next(1000);
            await Task.Delay(random);
        }

    }
}
