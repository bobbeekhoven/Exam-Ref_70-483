using System;
using System.Linq;
using System.Threading.Tasks;

namespace ManagingParallelForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 500).ToArray();
            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) => 
            {
                if (i == 200)
                    loopState.Stop();
            });

            Console.WriteLine("Completed: " + result.IsCompleted);
            Console.WriteLine("Items: " + result.LowestBreakIteration);

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
         }
    }
}
