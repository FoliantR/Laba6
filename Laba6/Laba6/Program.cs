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
        static int ResourceCPU = 100, ResourceGPU = 100;
        const int ResourceCPUForGame = 16, ResourceGPUForGame = 40;
        const int ResourceCPUForGrpaphic = 25, ResourceGPUForGraphic = 30;

        static void Main(string[] args)
        {
            Thread paint = new Thread(new ThreadStart(GraphicRedactor));
            Thread game = new Thread(new ThreadStart(ComputerGame));

            game.Start();
            paint.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Сколько свободно CPU{ResourceCPU}% GPU{ResourceGPU}%");
                Thread.Sleep(3000);
            }
        }
        public static void ComputerGame()
        {
            ResourceCPU -= ResourceCPUForGame;
            ResourceGPU -= ResourceGPUForGame;
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Что то проиходит в игре ресурсы использующиеся " +
                    $"CPU {ResourceCPUForGame}%" +
                    $"GPU {ResourceGPUForGame}% ");
                Thread.Sleep(1000);
            }
            ResourceCPU += ResourceCPUForGame;
            ResourceGPU += ResourceGPUForGame;
        }
        public static void GraphicRedactor()
        {
            ResourceCPU -= ResourceCPUForGrpaphic;
            ResourceGPU -= ResourceGPUForGraphic;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Что то проиходит в граическом редокторе ресурсы использующиеся " +
                    $"CPU {ResourceCPUForGrpaphic}%" +
                    $"GPU {ResourceGPUForGraphic}% ");
                Thread.Sleep(600);
            }
            Console.WriteLine("Граический редактор завершил свою работу");
            ResourceCPU += ResourceCPUForGrpaphic;
            ResourceGPU += ResourceGPUForGraphic;
        }
    }
}
