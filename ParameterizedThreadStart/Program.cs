using System;
using System.Threading;

namespace Parameterized_ThreadStart
{
    class Program
    {
        static void WorkOnData(object data)
        {
            Console.WriteLine("Working on: {0}", data);
            Thread.Sleep(1000);
        }
        static void Main(string[] args)
        {
            // Listing 1-21
            //ParameterizedThreadStart ps = new ParameterizedThreadStart(WorkOnData);
            //Thread thread = new Thread(ps);
            //thread.Start(99);

            // Listing 1-22
            Thread thread = new Thread((data) =>
            {
                WorkOnData(data);
            });
            thread.Start(99);
        }
    }
}
