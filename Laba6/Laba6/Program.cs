using System;
using System.Collections.Generic;
using System.Threading;

/*
 * Программу, моделирующую управление несколькими потоками в операционной системе. 
 * В системе помимо центрального процессора присутствует 5 ресурсов. 
 * Каждому процессу во время выполнения необходим доступ к некоторым из этих ресурсов (порядок доступа произвольный).
 * ОС должна реализовывать алгоритм с относительными приоритетами.  
*/
namespace Laba6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = true;

            List<Thread> potoki = new List<Thread>();
            Thread t = Thread.CurrentThread;
            potoki.Add(t);
            t.Name = "Ujh";
            do
            {
                Console.Clear();
                foreach (var item in potoki)
                {
                    Console.WriteLine($"{item.Name} {item.IsAlive} {item.ThreadState} {Thread.GetDomain().FriendlyName}\n");
                }
                Console.WriteLine("6 - Выход");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 6:
                        exit = false;
                        break;
                    default:
                        break;
                }
            } while (exit);
        }
    }
}
