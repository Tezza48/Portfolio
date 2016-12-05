using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        private static int[] randomBuffer;
        private static Random random = new Random();
        private static int arrayLength = 10000;
        private static int maxNumber = 1000000;

        static void Main(string[] args)
        {
            FillArrayWithRandom(arrayLength, out randomBuffer);

            Console.WriteLine("Unsorted");

            PrintArray(randomBuffer);

            Console.WriteLine("\nSorted");

            SelectionSort(ref randomBuffer);

            PrintArray(randomBuffer);

            Console.ReadKey();
        }

        private static void SelectionSort(ref int[] buffer)
        {
            //x = 0
            //for i = 0 to array length
            //
            //  for j = i to array length
            //      if array[j] < x
            //          x = array[j]
            //  swap(array[i], array[x])
            for (int i = 0; i < buffer.Length; i++)
            {
                int smallest = i;
                for (int j = i + 1; j < buffer.Length; j++)
                {
                    if (buffer[j] < buffer[smallest]) smallest = j;
                }
                Swap(i, smallest, ref buffer);
            }

        }

        private static void PrintArray(int[] randomBuffer)
        {
            for (int i = 0; i < randomBuffer.Length; i++)
            {
                Console.Write(randomBuffer[i] + "\t");
            }
        }

        private static void FillArrayWithRandom(int length, out int[] buffer)
        {
            buffer = new int[length];
            for (int i = 0; i < buffer.Length; i++)//fill array with random numbers 0 - 90
            {
                buffer[i] = random.Next(maxNumber);
            }
        }

        private static void Swap(int firstInt, int secondInt, ref int[] buffer)//swap two values in an array
        {
            int swapBuffer = 0;
            //put v1 in buffer
            swapBuffer = buffer[firstInt];
            //v2 in v1's spot
            buffer[firstInt] = buffer[secondInt];
            //put v1 in v2's spot
            buffer[secondInt] = swapBuffer;
        }
    }
}
