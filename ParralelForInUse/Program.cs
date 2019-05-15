using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParralelForInUse
{
    class Program
    {
        static void WorkOnItem(int item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        static void Main(string[] args)
        {
            int[] items = Enumerable.Range(0, 500).ToArray();

            Parallel.For(0, items.Length, i =>
            {
                WorkOnItem(items[i]);
            });
            Console.WriteLine("Finished processing. Press a key to end");
            Console.ReadKey();
        }
    }
}
