using System;
using System.Threading;
using System.Threading.Tasks;

namespace AttachedChildTasks
{
    class Program
    {
        public static void DoChild(object state)
        {
            Console.WriteLine("Child {0} starting", state);
            Thread.Sleep(2000);
            Console.WriteLine("Child {0} finished", state);
        }
        static void Main(string[] args)
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent starts");
                for (int i = 0; i < 10; i++)
                {
                    int taskNo = i;
                    Task.Factory.StartNew(
                        (x) => DoChild(x),
                        taskNo,
                        TaskCreationOptions.AttachedToParent);
                }
            });

            Thread.Sleep(5000);
            Console.WriteLine("Parent Finished. Press a key to continue.");
            Console.ReadKey();
        }
    }
}
