﻿using System;

namespace ClassWork
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "NxM table";
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.Write("Введите количество строк таблицы: ");
            int height = 0;
            while (height <= 0 || height >= 25)
            {
                try
                {
                    height = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    if (height <= 0 || height >= 25) throw new ArgumentException();
                }
                catch (Exception ex)
                {
                    Console.Write("Ввод некорректен. Пожалуйста, повторите попытку, введя новое значение: ");
                }

            }

            Console.Write("Введите количество столбцов таблицы: ");
            int width = 0;
            while (width <= 0 || width >= 25)
            {
                try
                {
                    width = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    if (width <= 0 || width >= 25) throw new ArgumentException();
                }
                catch (Exception ex)
                {
                    Console.Write("Ввод некорректен. Пожалуйста, повторите попытку, введя новое значение: ");
                }

            }

            int N = height;
            int M = width;

            Console.Clear();

            DrawTable(N, M);
        }

        public static void DrawTable(int N, int M)
        {
            int[,] numbers = FillArray(N, M);
            int maxLen = GetMaxLen(numbers, N, M);
            DrawUpperLine(numbers, M, maxLen);
            for (int i = 0; i < N; i++)
            {
                DrawFloor(numbers, M, i, maxLen);
                DrawLine(numbers, N, maxLen);
            }

            DrawLowerLine(numbers, N, maxLen);
        }

        public static int[,] FillArray(int N, int M)
        {
            Random rand = new Random();
            int[,] numbers = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    numbers[i, j] = rand.Next(1, 10000);
                }

            }

            return numbers;
        }

        public static void DrawUpperLine(int[,] numbers, int M, int maxLen)
        {
            Console.Write("/+");

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < maxLen + 2; j++)
                {
                    Console.Write("-");
                }

                Console.Write("+");
            }

            Console.WriteLine("\\");
        }

        public static void DrawLowerLine(int[,] numbers, int N, int maxLen)
        {
            Console.Write("\\+");
            for (int i = 0; i < numbers.Length / N; i++)
            {
                for (int j = 0; j < maxLen + 2; j++)
                {
                    Console.Write("-");
                }

                Console.Write("+");
            }

            Console.WriteLine("/");
        }

        public static void DrawLine(int[,] numbers, int N, int maxLen)
        {
            Console.Write("||");
            for (int i = 0; i < numbers.Length / N; i++)
            {
                for (int j = 0; j < maxLen + 2; j++)
                {
                    Console.Write("-");
                }

                Console.Write("|");
            }

            Console.WriteLine("|");
        }

        public static void DrawFloor(int[,] numbers, int M, int floor, int maxLen)
        {
            Console.Write("||");
            for (int i = 0; i < M; i++)
            {
                int k = 0;
                int c = maxLen - numbers[floor, i].ToString().Length;
                for (int j = 0; j < c / 2 + 1; j++)
                {
                    Console.Write(" ");
                    k++;
                }

                c = c - k + 1;
                Console.Write(numbers[floor, i]);
                for (int j = 0; j < c + 1; j++) Console.Write(" ");
                Console.Write("|");
            }

            Console.WriteLine("|");
        }

        public static int GetMaxLen(int[,] numbers, int N, int M)
        {
            int maxLen = 0;
            foreach (int item in numbers)
            {
                if (item > maxLen) maxLen = item;
            }

            return maxLen.ToString().Length;
        }

    }

}