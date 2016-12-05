using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        public static int gArrayLength = 10;
        public static int gMaxNumber = 100;
        public static Random gRand;

        static void Main(string[] args)
        {
            int[] numbers;

            gRand = new Random();

            FillArrayWithRandom(gArrayLength,gMaxNumber, out numbers);

            //numbers = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 10};

            Console.WriteLine("Unsorted");
            PrintArray(numbers);

            Console.WriteLine("Sorting");

            QuickSort(ref numbers, 0, numbers.Length - 1);

            Console.WriteLine("Sorted");

            PrintArray(numbers);

            //int[] x = { 0, 1, 2, 3, 4, 5 };
            //PrintArray(x);
            //Swap(1, 4, ref x);
            //PrintArray(x);

            Console.ReadKey();
        }

        private static void QuickSort(ref int[] _numbers, int low, int high)
        {
            if (high - low < 2)
            {
                Console.WriteLine("Sorted partition\n");
                return;
            }

            Console.WriteLine("Partitioning");

            int lowSel = low;
            int highSel = high;

            int pivot = _numbers[gRand.Next(lowSel, highSel)];
            PrintArray(_numbers, lowSel, highSel, pivot);

            // pick random pivot
            // low selector = 0, high selector = length
            // if low val < pivot, ++
            // if high val > pivot, --

            while (lowSel <= highSel)
            {
                while (_numbers[lowSel] < pivot)
                {
                    lowSel++;
                    PrintArray(_numbers, lowSel, highSel, pivot);
                }
                while (_numbers[highSel] > pivot)
                {
                    highSel--;
                    PrintArray(_numbers, lowSel, highSel, pivot);
                }

                if (lowSel <= highSel)
                {
                    Swap(lowSel, highSel, ref _numbers);
                    lowSel++;
                    highSel--;
                }

                PrintArray(_numbers, lowSel, highSel, pivot);
            }

            // At this point, both lowSel and highSel point to the pivot
            // i'm using highSel to refer to the pivot but it dosnt matter which i use
            Console.WriteLine("Left");
            QuickSort(ref _numbers, low, highSel);
            Console.WriteLine("Right");
            QuickSort(ref _numbers, lowSel, high);
                        
        }

        private static void PrintArray(int[] numbers, int low = 0, int high = 0, int pivot = -1)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if (i == low || i == high)
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                else if (numbers[i] == pivot)
                    Console.BackgroundColor = ConsoleColor.DarkCyan;

                Console.Write(numbers[i].ToString());

                Console.BackgroundColor = ConsoleColor.Black;

                Console.Write("\t");
            }
            Console.WriteLine();
        }

        private static void FillArrayWithRandom(int length, int max, out int[] numbers)
        {
            numbers = new int[length];
            for (int i = 0; i < length; i++)
            {
                numbers[i] = gRand.Next(max);
            }
        }

        private static void Swap (int a, int b, ref int[] buffer)
        {
            int holder = buffer[b];
            buffer[b] = buffer[a];
            buffer[a] = holder;

        }
    }
}
