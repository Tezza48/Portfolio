using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void HorizontalLine(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            Sorting sorting = new Sorting();

            int arrayLength = 1000;
            int maxNumber = 10000000;
            int numIterations = 10;

            Dictionary<string, List<double>> times = new Dictionary<string, List<double>>() {
                { "quicksort", new List<double>() },
                { "selection", new List<double>() },
                { "bubble", new List<double>() },
                { "insertion", new List<double>() },
                { "merge", new List<double>() }
            };

            Console.WriteLine("Sorting " + arrayLength + " elements, Ranging from 0 to " + (maxNumber - 1) + "...");

            for (int i = 0; i < numIterations; i++)
            {
                Console.WriteLine("Iteration " + i.ToString());
                int[] unsortedBuffer;
                sorting.FillArrayWithRandom(arrayLength, maxNumber, out unsortedBuffer);

                //Sorting.PrintArray(unsortedBuffer);

                int[] quickSorted, selectionSorted, bubbleSorted, insertionSorted;
                List<int> mergeSorted;

                quickSorted = (int[])unsortedBuffer.Clone();
                selectionSorted = (int[])unsortedBuffer.Clone();
                bubbleSorted = (int[])unsortedBuffer.Clone();
                insertionSorted = (int[])unsortedBuffer.Clone();
                mergeSorted = unsortedBuffer.ToList();

                timer.Start();
                sorting.QuickSort(ref quickSorted, 0, quickSorted.Length - 1);
                timer.Stop();
                times["quicksort"].Add(timer.ElapsedMilliseconds);

                timer.Restart();
                sorting.SelectionSort(ref selectionSorted);
                timer.Stop();
                times["selection"].Add(timer.ElapsedMilliseconds);

                timer.Restart();
                sorting.BubbleSort(ref bubbleSorted);
                timer.Stop();
                times["bubble"].Add(timer.ElapsedMilliseconds);

                timer.Restart();
                sorting.InsertionSort(ref insertionSorted);
                timer.Stop();
                times["insertion"].Add(timer.ElapsedMilliseconds);

                mergeSorted = sorting.MergeSort(mergeSorted);
                timer.Stop();
                times["merge"].Add(timer.ElapsedMilliseconds);

                timer.Reset();

            }

            // Write a results table out to the Console
            {
                int tableWidth = 97;
                string vertRule = "\t| ";
                Console.WriteLine("Results in ms");
                HorizontalLine(tableWidth);

                Console.Write("Algorithm" + vertRule);
                Console.WriteLine("Quicksort" + vertRule + "Selection" + vertRule + "Bubble" + vertRule + "Insertion" + vertRule + "Merge\t" + vertRule);
                HorizontalLine(tableWidth);
                for (int i = 0; i < numIterations; i++)
                {
                    Console.Write("\t" + vertRule);
                    foreach (string key in times.Keys)
                    {
                        //current key's time
                        Console.Write(times[key][i] + "\t");
                        Console.Write(vertRule);
                    }
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
