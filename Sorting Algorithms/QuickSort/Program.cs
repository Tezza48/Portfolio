using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    // 234ms for 1,000,000 ints
    class Program
    {
        public static int gArrayLength = 1000000;
        public static int gMaxNumber = 1000000;
        public static Random gRand;

        static void Main(string[] args)
        {
            int[] numbers;

            gRand = new Random();

            FillArrayWithRandom(gArrayLength,gMaxNumber, out numbers);

            //numbers = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 10};

            Console.WriteLine("Unsorted");
            //PrintArray(numbers, 0, numbers.Length, 0, numbers.Length);

            Console.WriteLine("Sorting");

            QuickSort(ref numbers);

            Console.WriteLine("Sorted");

            PrintArray(numbers, 0, numbers.Length, 0, numbers.Length);

            Console.WriteLine("Done");

            if (!CheckSorted(numbers))
            {
                Console.WriteLine("Not Sorted");
            }
            else
            {
                Console.WriteLine("Sorted");
            }

            Console.Read();
        }

        private static bool CheckSorted(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (i > i + 1) return false;
            }
            return true;
        }

        private static void QuickSort(ref int[] buffer)
        {
            Partition(ref buffer, 0, buffer.Length - 1);
        }
        private static void Partition(ref int[] buffer, int start, int end)
        {
            if (end - start < 2)
            {
                return;
            }

            int low = start;
            int high = end;

            int pivot = buffer[gRand.Next(start, end)];

            //PrintArray(buffer, start, end, low, high, pivot);
            
            while (high >= low)
            {
                while (buffer[low] < pivot)
                {
                    low++;
                }
                while (buffer[high] > pivot)
                {
                    high--;
                }

                if (low <= high)
                {
                    Swap(low, high, ref buffer);
                    //int holder = buffer[low];
                    //buffer[low] = buffer[high];
                    //buffer[high] = holder;

                    low++;
                    high--;
                }
            }

            //Console.WriteLine("Left");
            Partition(ref buffer, start, low-1);

            //Console.WriteLine("Right");
            Partition(ref buffer, high+1, end);

            return;

        }

        private static void PrintArray(int[] numbers, int start = 0, int end = 0, int low = 0, int high = 0, int pivot = -1)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if (i < start || i > end)
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                else
                    Console.ForegroundColor = ConsoleColor.White;

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

        //private static int[] ElementsFromAToB(int a, int b, int[] buffer)
        //{
        //    int[] output = new int[b-a];
        //    for (int i = 0; i < output.Length; i++)
        //    {
        //        output[i] = buffer[a + i];
        //    }
        //    return output;
        //}

    }
}
