using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Sorting
    {
        Random mRandom;

        public Sorting()
        {
            mRandom = new Random();
        }

        // Static Functions
        public static void PrintArray(int[] numbers)
        {
            foreach (int element in numbers)
            {
                Console.Write(element + "\t");
            }
            Console.WriteLine();
        }

        public static void PrintArray(int[] numbers, int start = 0, int end = 0, int low = 0, int high = 0, int pivot = -1)
        {
            // Includes Formatting for debugging.
            // numbers -> the buffer, start & end -> the bounds you are working with,
            // low & high -> Selectors for Quicksort, pivot -> Quicksort pivot.
            for (int i = 0; i < numbers.Length; i++)
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

        // Sorting Methods
        public void QuickSort(ref int[] buffer, int start, int end)
        {
            if (end - start < 2)
            {
                return;
            }

            int low = start;
            int high = end;

            int pivot = buffer[mRandom.Next(start, end)];

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
            QuickSort(ref buffer, start, low - 1);

            //Console.WriteLine("Right");
            QuickSort(ref buffer, high + 1, end);

            return;

        }

        public void SelectionSort(ref int[] buffer)
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

        public void BubbleSort(ref int[] buffer)
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

        public void InsertionSort(ref int[] buffer)
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

        // TODO: Convert this to use an array like Quicksort does
        public  List<int> MergeSort(List<int> list)
        {
            if (list.Count < 2)
            {
                return list;
            }
            else
            {
                // put left and right into separate variables
                List<int> left = new List<int>();
                List<int> right = new List<int>();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i < list.Count / 2)
                        left.Add(list[i]);
                    else if (i >= list.Count / 2)
                        right.Add(list[i]);
                }
                // sort left side
                left = MergeSort(left);
                // sort right side
                right = MergeSort(right);
                // merge sorted halves
                return Merge(left, right);
            }
        }
        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> mergedList = new List<int>();
            while (left.Any() && right.Any())
            {
                if (left[0] > right[0])
                {
                    mergedList.Add(right[0]);
                    right.RemoveAt(0);
                }
                else
                {
                    mergedList.Add(left[0]);
                    left.RemoveAt(0);
                }
            }

            while (left.Any())
            {
                mergedList.Add(left[0]);
                left.RemoveAt(0);
            }

            while (right.Any())
            {
                mergedList.Add(right[0]);
                right.RemoveAt(0);
            }

            return mergedList;
        }

        // Helper Methods
        public void FillArrayWithRandom(int length, int max, out int[] numbers)
        {
            numbers = new int[length];
            for (int i = 0; i < length; i++)
            {
                numbers[i] = mRandom.Next(max);
            }
        }

        private void Swap(int a, int b, ref int[] buffer)
        {
            int holder = buffer[b];
            buffer[b] = buffer[a];
            buffer[a] = holder;
        }
    }
}
