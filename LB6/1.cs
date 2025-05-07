using System;
using System.Threading;

namespace LB6PROPolynkoKN23
{
    class Program
    {
        static void Sec()
        {
            while (true)
            {
                Console.WriteLine(new string(' ', 10) + "Second");
                Thread.Sleep(200);
            }
        }

        static void Main()
        {
            ThreadStart sec = new ThreadStart(Sec);
            Thread thread = new Thread(sec);
            thread.Start();

            while (true)
            {
                Console.WriteLine("Primary");
                Thread.Sleep(200);
            }
        }
    }
}