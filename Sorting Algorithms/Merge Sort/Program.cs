using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            int length = 100;
            int maxNumberSize = 1000;
            List<int> list = new List<int>();

            for (int i = 0; i < length; i++)
            {
                list.Add(rand.Next(maxNumberSize));
            }

            List<int> sortedList = MergeSort(list);

            Console.WriteLine("Unsorted");
            foreach (int i in list) Console.Write(i.ToString() + "\t");
            Console.WriteLine();
            Console.WriteLine("Sorted");

            foreach (int i in sortedList) Console.Write(i.ToString() + "\t");

            Console.ReadKey();
        }

        private static List<int> MergeSort(List<int> list)
        {
            if (list.Count < 2)
            {
                return list;
            } else
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

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> mergedList = new List<int>();
            while (left.Any() && right.Any())
            {
                if (left[0] > right[0])
                {
                    mergedList.Add(right[0]);
                    right.RemoveAt(0);
                } else 
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
    }
}
