using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWaitAll
{
    class Program
    {
        public static void DoWork(int i)
        {
            Console.WriteLine("Task {0} starting", i);
            Thread.Sleep(2000);
            Console.WriteLine("Task {0} finished", i);
        }

        static void Main(string[] args)
        {
            Task[] Tasks = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                int taskNum = i;

                Tasks[i] = Task.Run(() => DoWork(taskNum));
            }
            Task.WaitAll(Tasks);

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
