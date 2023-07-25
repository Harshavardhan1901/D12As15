using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment15_QuickSort_Analysis
{
    internal class Program
    {
        //Quick sort implementation
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }
        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                QuickSort(arr, left, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, right);
            }
        }
        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, right);
            return i + 1;
        }
        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        //Merge sort implementation
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }
        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                    arr[k++] = leftArray[i++];
                else
                    arr[k++] = rightArray[j++];
            }
            while (i < n1)
                arr[k++] = leftArray[i++];
            while (j < n2)
                arr[k++] = rightArray[j++];
        }
        
        public static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next(1, 1000);
            }
            return arr;
        }
        public static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
        static void Main(string[] args)
        {
            int[] arraySizes = { 20, 30, 50 };
            foreach (int size in arraySizes)
            {
                int[] randomArray = GenerateRandomArray(size);
                int[] quickSortArray = (int[])randomArray.Clone();
                int[] mergeSortArray = (int[])randomArray.Clone();

                Console.WriteLine($"\nSorting {size} elements with QuickSort");
                Stopwatch stopwatch1 = new Stopwatch();
                stopwatch1.Start();
                QuickSort(quickSortArray);
                stopwatch1.Stop();
                Console.WriteLine("Quick sorted array:");
                PrintArray(quickSortArray);
                Console.WriteLine($"QuickSort time taken: {stopwatch1.Elapsed.TotalMilliseconds} ms");

                Console.WriteLine($"Sorting {size} elements with MergeSort");
                Stopwatch stopwatch2 = new Stopwatch();
                stopwatch2.Start();
                MergeSort(mergeSortArray);
                stopwatch2.Stop();
                Console.WriteLine("Merge sorted array:");
                PrintArray(mergeSortArray);
                Console.WriteLine($"MergeSort time taken: {stopwatch2.Elapsed.TotalMilliseconds} ms");

            }
            Console.ReadKey();
        }
    }
}