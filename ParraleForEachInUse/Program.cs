using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParraleForEachInUse
{
    class Program
    {
        static void WorkOnItem(int item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on; " + item);
        }

        static void Main(string[] args)
        {
            System.Collections.Generic.IEnumerable<int> items = Enumerable.Range(0, 500);
            Parallel.ForEach(items, item =>
            {
                WorkOnItem(item);
            });

            Console.WriteLine("Finshed processing. Press a key to continue");
            Console.ReadKey();
        }
    }
}
