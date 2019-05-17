using System;
using System.Threading;
using System.Threading.Tasks;

namespace Create_RunTasks
{
    class Program
    {
        public static void DoWork()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished. Press a key to end.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Task newTask = new Task(() => DoWork());
            newTask.Start();
            newTask.Wait();
        }
    }
}
