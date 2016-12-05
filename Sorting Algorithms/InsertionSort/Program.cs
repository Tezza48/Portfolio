using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
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

            InsertionSort(ref randomBuffer);

            PrintArray(randomBuffer);

            Console.ReadKey();
        }

        private static void InsertionSort(ref int[] buffer)
        {
            //for i=1 to buffer length - 1
            //  //consider i - 1 is sorted
            //  x = buffer[i]
            //  j = i
            //  while j > 0 and buffer[j-1] > x
            //      buffer[j] = buffer[j-1]
            //      j--
            //  buffer[j] = x

            for (int i = 1; i < buffer.Length; i++)
            {
                int x = buffer[i];
                int j = i;
                while (j > 0 && buffer[j - 1] > x)
                {
                    buffer[j] = buffer[j - 1];
                    j--;
                }
                buffer[j] = x;
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
    }
}
