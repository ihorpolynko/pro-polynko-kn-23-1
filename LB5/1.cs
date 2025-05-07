using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Default;

        int L = 250; // Розмір матриці

        // Ініціалізація матриць
        double[,] arrayA = GenerateRandom(L, L);
        double[,] arrayB = GenerateRandom(L, L);
        double[,] arrayR = new double[L, L];

        // Вимірювання часу
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        Variant1(arrayA, arrayB, arrayR, L);

        stopwatch.Stop();

        Console.WriteLine($"Час виконання: {stopwatch.ElapsedMilliseconds} мс");
    }

    static double[,] GenerateRandom(int rows, int cols)
    {
        Random rand = new Random();
        double[,] matrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = rand.NextDouble() * 100;

        return matrix;
    }

    static void Variant1(double[,] arrayA, double[,] arrayB, double[,] arrayD, int L)
    {
        for (int i = 0; i < L; i++)
            for (int k = 0; k < L; k++)
                for (int j = 0; j < L; j++)
                    arrayD[i, j] += arrayA[i, k] * arrayB[k, j];
    }
}