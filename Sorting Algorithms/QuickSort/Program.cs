using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        public static int gArrayLength = 10000;
        public static int gMaxNumber = 100000000;
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

            QuickSort(ref numbers);

            Console.WriteLine("Sorted");

            PrintArray(numbers);

            //int[] x = { 0, 1, 2, 3, 4, 5 };
            //PrintArray(x);
            //Swap(1, 4, ref x);
            //PrintArray(x);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static void QuickSort(ref int[] buffer)
        {
            buffer = Partition(buffer);
        }
        private static int[] Partition(int[] buffer)
        {
            if (buffer.Length < 2)
            {
                //Console.WriteLine("Sorted partition\n");
                return buffer;
            }

            //Console.WriteLine("Partitioning");

            int low = 0;
            int high = buffer.Length - 1;

            int pivot = buffer[gRand.Next(low, high)];
            //PrintArray(buffer, low, high, pivot);

            // pick random pivot
            // low selector = 0, high selector = length
            // if low val < pivot, ++
            // if high val > pivot, --

            while (low < high)
            {
                while (buffer[low] < pivot)
                {
                    low++;
                    //PrintArray(buffer, low, high, pivot);
                }
                while (buffer[high] > pivot)
                {
                    high--;
                    //PrintArray(buffer, low, high, pivot);
                }

                Swap(low, high, ref buffer);

                //PrintArray(buffer, low, high, pivot);
            }
            
            int[] left = ElementsFromAToB(0, low+1, buffer);
            int[] right = ElementsFromAToB(high+1, buffer.Length, buffer);

            //Console.WriteLine("Left");
            left = Partition(left);

            //Console.WriteLine("Right");
            right = Partition(right);

            int[] output = left.Concat(right).ToArray();

            return output;

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

        private static int[] ElementsFromAToB(int a, int b, int[] buffer)
        {
            int[] output = new int[b-a];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = buffer[a + i];
            }
            return output;
        }

    }
}
