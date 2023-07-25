using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assesment_15
{
    internal class Program
    {
       
            static void Main()
            {
                int[] array20 = GenerateRandomArray(20);
                int[] array30 = GenerateRandomArray(30);
                int[] array50 = GenerateRandomArray(50);

                Console.WriteLine("Unsorted array (size 20):");
                PrintArray(array20);
                MeasureAndSort(array20);
                Console.WriteLine("Sorted array:");
                PrintArray(array20);

                Console.WriteLine("Unsorted array (size 30):");
                PrintArray(array30);
                MeasureAndSort(array30);
                Console.WriteLine("Sorted array:");
                PrintArray(array30);

                Console.WriteLine("Unsorted array (size 50):");
                PrintArray(array50);
                MeasureAndSort(array50);
                Console.WriteLine("Sorted array:");
                PrintArray(array50);
            }

            static void QuickSort(int[] arr)
            {
                QuickSort(arr, 0, arr.Length - 1);
            }

            static void QuickSort(int[] arr, int low, int high)
            {
                if (low < high)
                {
                    int pivot = Partition(arr, low, high);

                    QuickSort(arr, low, pivot - 1);
                    QuickSort(arr, pivot + 1, high);
                }
            }

            static int Partition(int[] arr, int low, int high)
            {
                int pivot = arr[high];
                int i = low - 1;

                for (int j = low; j < high; j++)
                {
                    if (arr[j] < pivot)
                    {
                        i++;
                        Swap(ref arr[i], ref arr[j]);
                    }
                }

                Swap(ref arr[i + 1], ref arr[high]);
                return i + 1;
            }

            static void Swap(ref int a, ref int b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            static bool IsSorted(int[] arr)
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        return false;
                    }
                }
                return true;
            }

            static int[] GenerateRandomArray(int size)
            {
                Random random = new Random();
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next(1, 100); // Generate random integers between 1 and 100
                }
                return array;
            }

            static void PrintArray(int[] arr)
            {
                foreach (int num in arr)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }

            static void MeasureAndSort(int[] arr)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                QuickSort(arr);
                stopwatch.Stop();
                Console.WriteLine($"Time taken to sort: {stopwatch.Elapsed.TotalMilliseconds} ms");
            }
        }
    }
    
