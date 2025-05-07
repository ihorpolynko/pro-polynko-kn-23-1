using System;
using System.Threading;

namespace LB6PROPolynkoKN23
{
    class Program
    {
        static bool isRunning = true; // Прапорець для завершення потоку

        static void Sec()
        {
            while (isRunning)
            {
                Thread.Sleep(800); // 800 мс, бо дві "Primary" по 400 мс = 800 мс
                Console.Write(" Second");
            }
        }

        static void Main()
        {
            ThreadStart sт = new ThreadStart(Sec); // Ім'я делегата - sт
            Thread SТ = new Thread(sт); // Ім'я потоку - SТ
            SТ.Start();

            int primaryCount = 0;

            while (isRunning)
            {
                Console.Write("Primary");
                primaryCount++;

                // Виводимо "Second" після кожних двох "Primary" у тому ж рядку
                if (primaryCount % 1 == 0)
                {
                    Console.WriteLine(); // Перехід на новий рядок після пари
                }

                Thread.Sleep(400);

                // Завершення програми при натисненні клавіші
                if (Console.KeyAvailable)
                {
                    Console.ReadKey();
                    isRunning = false;
                }
            }

            // Чекаємо завершення потоку "SТ"
            SТ.Join();
            Console.WriteLine("\nЗавершення програми...");
        }
    }
}