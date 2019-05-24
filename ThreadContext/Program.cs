using System;
using System.Threading;

namespace ThreadContext
{
    class Program
    {
        static void DisplayThread (Thread t)
        {
            Console.WriteLine("Name: {0}", t.Name);
            Console.WriteLine("Culture: {0}", t.CurrentCulture);
            Console.WriteLine("Priority: {0}", t.Priority);
            Console.WriteLine("Context: {0}", t.ExecutionContext);
            Console.WriteLine("IsBackground?: {0}", t.IsBackground);
            Console.WriteLine("IsPool?: {0}", t.IsThreadPoolThread);
        }

        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Method";
            DisplayThread(Thread.CurrentThread);

            Console.ReadKey();
        }

    }
}
