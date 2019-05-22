using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContinuationOptions
{
    class Program
    {
        public static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }

        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }
        static void Main(string[] args)
        {
            Task task = Task.Run(() => HelloTask());

            task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnFaulted);

            Thread.Sleep(3000);
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
