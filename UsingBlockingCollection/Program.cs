using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace UsingBlockingCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // listing 1-40
            ConcurrentDictionary<string, int> ages = new ConcurrentDictionary<string, int>();
            if (ages.TryAdd("Rob", 21))
            {
                Console.WriteLine("Rob added succesfully");
            }
            Console.WriteLine("Rob's age: {0}", ages["Rob"]);
            // Set Rob's age to 22 if it's 21
            if (ages.TryUpdate("Rob", 22, 21))
            {
                Console.WriteLine("Age updated succesfully");
            }
            Console.WriteLine("Rob's new age: {0}", ages["Rob"]);
            // Increment Rob's age atomically using factory method
            Console.WriteLine("Rob's age updated to: {0}",
                ages.AddOrUpdate("Rob", 1, (name,age) => age = age+1));
            Console.WriteLine("Rob's new age: {0}", ages["Rob"]);

            // listing 1-39
            //ConcurrentBag<string> bag = new ConcurrentBag<string>();
            //bag.Add("Rob");
            //bag.Add("Miles");
            //bag.Add("Hull");
            //string str;
            //if (bag.TryPeek(out str))
            //{
            //    Console.WriteLine("Peek: {0}", str);
            //}
            //if (bag.TryTake(out str))
            //{
            //    Console.WriteLine("Take: {0}", str);
            //}

            // listing 1-38
            //ConcurrentStack<string> stack = new ConcurrentStack<string>();
            //stack.Push("Rob");
            //stack.Push("Miles");
            //string str;
            //if (stack.TryPeek(out str))
            //{
            //    Console.WriteLine("Peek: {0}", str);
            //}
            //if (stack.TryPop(out str))
            //{
            //    Console.WriteLine("Pop: {0}", str);
            //}

            // listing 1-37
            //ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
            //queue.Enqueue("Rob");
            //queue.Enqueue("Miles");
            //string str;
            //if (queue.TryPeek(out str))
            //{
            //    Console.WriteLine("Peek: {0}", str);
            //}
            //if (queue.TryDequeue(out str))
            //{
            //    Console.WriteLine("Dequeue: {0}", str);
            //}

            // listing 1-36
            //BlockingCollection<int> data = new BlockingCollection<int>(new ConcurrentStack<int>(), 5);

            // listing 1-35
            // Blocking collection that can hold 5 items
            // BlockingCollection<int> data = new BlockingCollection<int>(5);

            //Task.Run(() =>
            //{
            //    // Attempt to add 10 items to the collection - blockst after 5th
            //    for (int i = 0; i < 11; i++)
            //    {
            //        data.Add(i);
            //        Console.WriteLine("Data {0} added succesfully.", i);
            //    }
            //    // indicate we have no more to add
            //    data.CompleteAdding();
            //});

            //Console.ReadKey();
            //Console.WriteLine("Reading collection");

            //Task.Run(() =>
            //{
            //    while (!data.IsCompleted)
            //    {
            //        try
            //        {
            //            int v = data.Take();
            //            Console.WriteLine("Data {0} taken succesfully.", v);
            //        }
            //        catch (InvalidOperationException)
            //        {

            //        }
            //    }
            //});

            Console.ReadKey();
        }
    }
}
