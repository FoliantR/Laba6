using System;
using System.Collections.Generic;
using System.Threading;

namespace Laba6
{
    class Program
    {
        delegate void Print();

        static int ResourceCPU = 100, ResourceGPU = 100, ResourceOZU = 16000, ResourceNet = 80, ResourceDisk = 30;
        const int ResourceCPUForGame = 16, ResourceGPUForGame = 40,  ResourceOZUForGame = 4000, ResourceNetForGame = 6, ResourceDiskForGame = 5;
        const int ResourceCPUForGraphic = 25, ResourceGPUForGraphic = 30, ResourceOZUForGraphic = 8000, ResourceNetForGraphic = 4, ResourceDiskForGraphic = 10;
        const int ResourceCPUForCode = 15, ResourceGPUForCode = 5, ResourceOZUForCode = 600, ResourceNetForCode = 3, ResourceDiskForCode = 1;
        static void Main(string[] args)
        {
            Print print = OS; //Небольшая демонстрация работы собственных делегатов
            print += Wellcome; 
            print();


            Thread paint = new Thread(new ThreadStart(GraphicRedactor)); // В качестве входного параметра
            Thread game = new Thread(new ThreadStart(ComputerGame)); // для всех стартов потока является разработанные методы
            Thread microsoftVisual = new Thread(new ThreadStart(CodeRedactor));

            game.Start();
            paint.Start();

            for (int i = 0; i < 10; i++)
            {
                if (i == 3) microsoftVisual.Start();
                Console.WriteLine($"Сколько свободно CPU {ResourceCPU}% GPU {ResourceGPU}% OZU {ResourceOZU}mb Net {ResourceNet}mbi/s Disk {ResourceDisk}mb/s");
                Thread.Sleep(3000);
            }
        }
        public static void ComputerGame()
        {
            ResourceCPU -= ResourceCPUForGame; ResourceGPU -= ResourceGPUForGame; ResourceOZU -= ResourceOZUForGame; ResourceNet -= ResourceNetForGame; ResourceDisk -= ResourceDiskForGame;
            Console.WriteLine("Запустилась игра!.........................");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Что то проиходит в игре. Использующиеся ресурсы:  " +
                    $"CPU {ResourceCPUForGame}% " +
                    $"GPU {ResourceGPUForGame}% " +
                    $"OZU {ResourceOZUForGame}mb" +
                    $"Net {ResourceNetForGame}mbi/s " +
                    $"Disk {ResourceDiskForGame}mb/s ");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Игра завершила свою работу!.........................");
            ResourceCPU += ResourceCPUForGame; ResourceGPU += ResourceGPUForGame; ResourceOZU += ResourceOZUForGame; ResourceNet += ResourceNetForGame; ResourceDisk += ResourceDiskForGame;
        }
        public static void GraphicRedactor()
        {
            ResourceCPU -= ResourceCPUForGraphic; ResourceGPU -= ResourceGPUForGraphic; ResourceOZU -= ResourceOZUForGraphic; ResourceNet -= ResourceNetForGraphic; ResourceDisk -= ResourceDiskForGraphic;
            Console.WriteLine("Запустился графический редактор!.........................");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Что то проиходит в графическом редакторе. Использующиеся ресурсы: " +
                    $"CPU {ResourceCPUForGraphic}% " +
                    $"GPU {ResourceGPUForGraphic}% " +
                    $"OZU {ResourceOZUForGraphic}mb" +
                    $"Net {ResourceNetForGraphic}mbi/s " +
                    $"Disk {ResourceDiskForGraphic}mb/s ");
                Thread.Sleep(600);
            }
            Console.WriteLine("Графический редактор завершил свою работу!.................");
            ResourceCPU += ResourceCPUForGraphic; ResourceGPU += ResourceGPUForGraphic; ResourceOZU += ResourceOZUForGraphic; ResourceNet += ResourceNetForGraphic; ResourceDisk += ResourceDiskForGraphic;
        }
        public static void CodeRedactor()
        {
            ResourceCPU -= ResourceCPUForCode; ResourceGPU -= ResourceGPUForCode; ResourceOZU -= ResourceOZUForCode; ResourceNet -= ResourceNetForCode; ResourceDisk -= ResourceDiskForCode;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Что то проиходит в среде разработке. Использующиеся ресурсы: " +
                    $"CPU {ResourceCPUForCode}% " +
                    $"GPU {ResourceGPUForCode}% " +
                    $"OZU {ResourceOZUForCode}mb" +
                    $"Net {ResourceNetForCode}mbi/s " +
                    $"Disk {ResourceDiskForCode}mb/s ");
                Thread.Sleep(500);
            }
            Console.WriteLine("Среда разработки завершила свою работу!.................");
            ResourceCPU += ResourceCPUForCode; ResourceGPU += ResourceGPUForCode; ResourceOZU += ResourceOZUForCode; ResourceNet += ResourceNetForCode; ResourceDisk += ResourceDiskForCode;
        }

        static void OS()
        {
            Console.WriteLine("OS 14.22.3");
        }
        static void Wellcome()
        {
            Console.WriteLine("Добро пожаловать");
        }
    }
}