using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public static class SortingAlgorithm
    {

        public static void Swap<T>(ref T left, ref T right)
        {
            T Temp = left;
            left = right;
            right = Temp;
        }

        public static void Swap(ref System.Object left, ref System.Object right)
        {
            System.Object Temp = left;
            left = right;
            right = Temp;
        }

        public static void Swap<T>(List<T> list, int leftIndex, int rightIndex)
        {
            T temp = list[leftIndex];
            list[leftIndex] = list[rightIndex];
            list[rightIndex] = temp;

        }

        public static void InsertionSort<T>(List<T> list) where T : IComparable<T>
        {

            for (int i = 1; i < list.Count; i++)
            {
                int j = i - 1;
                T key = list[i];
                while (j >= 0 && list[j].CompareTo(key) > 0)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j] = key;
            }
        }


        

        //bubble sort
        public static void BubbleSort<T>(List<T> list) where T : IComparable<T>
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = list.Count - 1; j > i; j--)
                {
                    if (list[j].CompareTo(list[j - 1]) < 0) Swap(list, j, j - 1);
                }
            }
        }

        #region Merge Sort
        //merge function
        private static void Merge<T>(List<T> list, int beginIndex, int middleIndex, int endIndex)
            where T : IComparable<T>
        {
            int leftSize = middleIndex - beginIndex + 1;
            int rightSize = endIndex - middleIndex;

            T[] leftArray = new T[leftSize];
            T[] rightArray = new T[rightSize];

            for (int i = 0; i < leftSize; i++)
            {
                leftArray[i] = list[beginIndex + i];
            }

            for (int i = 0; i < rightSize; i++)
            {
                rightArray[i] = list[middleIndex + 1 + i];
            }

            int leftIndex = 0;
            int rightIndex = 0;

            for (int i = beginIndex; i <= endIndex; i++)
            {

                if (leftIndex < leftSize && rightIndex < rightSize && leftArray[leftIndex].CompareTo(rightArray[rightIndex]) <= 0)
                {
                    list[i] = leftArray[leftIndex];
                    leftIndex++;
                }
                else if (leftIndex < leftSize && rightIndex < rightSize && leftArray[leftIndex].CompareTo(rightArray[rightIndex]) > 0)
                {
                    list[i] = rightArray[rightIndex];
                    rightIndex++;
                }
                else if (leftIndex < leftSize && rightIndex >= rightSize)
                {
                    list[i] = leftArray[leftIndex];
                    leftIndex++;
                }
                else if (leftIndex >= leftSize && rightIndex < rightSize)
                {
                    list[i] = rightArray[rightIndex];
                    rightIndex++;
                }
                else { }
            }
        }

        //MergeSort function
        public static void MergeSort<T>(List<T> list, int beginIndex, int endIndex)
            where T : IComparable<T>
        {

            if (beginIndex < endIndex)
            {
                int middleIndex = (beginIndex + endIndex) / 2;
                MergeSort(list, beginIndex, middleIndex);
                MergeSort(list, middleIndex + 1, endIndex);
                Merge(list, beginIndex, middleIndex, endIndex);
            }


        }

        #endregion

        #region  Heap Sort
        private static class HeapProperty
        {
            static internal int Parent(int i) { return i / 2 - 1; }
            static internal int LeftChild(int i) { return 2 * i + 1; }
            static internal int RightChild(int i) { return 2 * i + 2; }
        }

        // MaxHeapify function
        private static void MaxHeapify<T>(List<T> list, int index) where T : IComparable<T>
        {
            int leftChild = HeapProperty.LeftChild(index);
            int rightChild = HeapProperty.RightChild(index);

            int largest = index;
            if (leftChild < list.Count && list[leftChild].CompareTo(list[index]) > 0)
            {
                largest = leftChild;
            }
            if (rightChild < list.Count && list[rightChild].CompareTo(list[index]) > 0)
            {
                largest = rightChild;
            }

            if (largest != index)
            {
                Swap(list, index, largest);
                MaxHeapify(list, largest);
            }

        }

        private static void BuildMaxHeap<T>(List<T> list) where T : IComparable<T>
        {
            int middleIndex = (list.Count - 1) / 2;
            for (int i = middleIndex; i >= 0; i--)
            {
                MaxHeapify(list, i);
            }
        }

        public static void HeapSort<T>(List<T> list) where T : IComparable<T>
        {
            BuildMaxHeap(list);
            for (int i = list.Count - 1; i > 0; i--)
            {
                T temp = list[i];
                list[i] = list[0];
                list[0] = temp;
                MaxHeapify(list, 0);
            }
        }
        #endregion

        #region QuickSort
            private static int Partition<T>(List<T> list, int beginIndex, int endIndex) where T : IComparable<T>
            {

                T key = list[endIndex];

                int i = beginIndex - 1;
                for (int j = beginIndex; j <= endIndex; j++)
                {
                    if (list[j].CompareTo(key) < 0)
                    {
                        i++;
                        Swap(list, i, j);
                    }
                }

                Swap(list, i + 1, endIndex);

                return i + 1;


            }
            public static void QuickSort<T>(List<T> list, int beginIndex, int endIndex) where T : IComparable<T>
            {
                if (beginIndex < endIndex)
                {
                    int middleIndex = Partition(list, beginIndex, endIndex);
                    QuickSort(list, beginIndex, middleIndex - 1);
                    QuickSort(list, middleIndex + 1, endIndex);
                }

            }
        #endregion
    }
}
