using System;
using System.Threading;
using System.Threading.Tasks;


namespace CreatingThreads
{
    class Program
    {
        static void ThreadHello()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(2000);
        }
        static void Main(string[] args)
        {
            // Listing 1-20
            Thread thread = new Thread(() =>
            {
                Console.WriteLine("Hello from the thread");
                Thread.Sleep(2000);
            });

            thread.Start();
            Console.WriteLine("Press a key to end.");
            Console.ReadKey();

            // Listing 1-19 (old methode)
            //ThreadStart ts = new ThreadStart(ThreadHello);
            //Thread thread = new Thread(ts);
            //thread.Start();

            // Listing 1-18
            //Thread thread = new Thread(ThreadHello);
            //thread.Start();
        }
    }
}
