﻿using System;
using System.Threading;

namespace AbortingAThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread tickThread = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("Tick");
                    Thread.Sleep(1000);
                }
            });

            tickThread.Start();

            Console.WriteLine("Press a key to stop the clock");
            Console.ReadKey();
            tickThread.Abort();
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }
}
