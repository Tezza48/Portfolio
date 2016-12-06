using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorting sorting = new Sorting();

            int arrayLength = 1000;
            int maxNumber = 1000;
            
            int[] sortedBuffer;
            sorting.FillArrayWithRandom(arrayLength, maxNumber, out sortedBuffer);

            Sorting.PrintArray(sortedBuffer);

            //sorting.QuickSort(ref sortedBuffer, 0, sortedBuffer.Length-1);
            //sorting.SelectionSort(ref sortedBuffer);
            //sorting.BubbleSort(ref sortedBuffer);
            sorting.InsertionSort(ref sortedBuffer);

            List<int> MergeSortedList = sorting.MergeSort(sortedBuffer.ToList());

            Sorting.PrintArray(sortedBuffer);
            //Sorting.PrintArray(MergeSortedList.ToArray());

            Console.ReadKey();
        }
    }
}
