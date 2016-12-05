using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        private static int[] randomBuffer;
        private static Random random = new Random();
        private static int arrayLength = 100;
        private static int maxNumber = 1000;

        static void Main(string[] args)
        {
            FillArrayWithRandom(arrayLength, out randomBuffer);

            Console.WriteLine("Unsorted");

            PrintArray(randomBuffer);

            Console.WriteLine("\nSorted");

            BubbleSort(ref randomBuffer);

            PrintArray(randomBuffer);

            Console.ReadKey();
        }

        private static void BubbleSort(ref int[] buffer)
        {
            //while not swapped
            //  swapped = false
            //      for i < array length
            //          if buffer[i] > buffer[i+1]
            //              swap(buffer[i], buffer[i+1]
            //              swapped = true

            bool swapped = false;
            while (!swapped)
            {
                swapped = true;
                for (int i = 1; i < buffer.Length; i++)
                {
                    if (buffer[i - 1] > buffer[i])
                    {
                        Swap(i - 1, i, ref buffer);
                        swapped = false;
                    }
                }
                //Console.WriteLine(swapped);
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

        private static void FillArrayWithRandom(int length, out int[] buffer)
        {
            buffer = new int[length];
            for (int i = 0; i < buffer.Length; i++)//fill array with random numbers 0 - 90
            {
                buffer[i] = random.Next(maxNumber);
            }
        }

        private static void PrintArray(int[] randomBuffer)
        {
            for (int i = 0; i < randomBuffer.Length; i++)
            {
                Console.Write(randomBuffer[i] + "\t");
            }
        }
    }
}
