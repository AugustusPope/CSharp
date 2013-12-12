using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public static class DynamicProgramming
    {

        //1.Given a matrix consisting of 0's and 1's, find the maximum size sub-matrix consisting of only 1's.
        public static void MaxSubmatrix(int[][] matrix)
        {


        }
        //2.Given an array containing both positive and negative integers, find the contiguous array with the maximum sum.

        private static int SumOfArray(int[] arr, int start, int end)
        {
            int sum = 0;

            for (int i = start; i < end; i++)
            {
                sum += arr[i];
            }

            return sum;
        }
        public static int MaximumContiguousArray(int[] arr,int startIndex,int endIndex)
        {

            int currentMax=arr[startIndex];
            int maxSumSofar=arr[startIndex];
            int start ;
            int end ;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (arr[i] >= currentMax + arr[i]) { start = i; end = i; currentMax = arr[i]; }
                else { currentMax += arr[i];  }

                if (currentMax > maxSumSofar) { maxSumSofar = currentMax; end = i; }

                //    currentMax = Math.Max(arr[i], currentMax + arr[i]);//currentMax may be negative
                //maxSumSofar = Math.Max(maxSumSofar, currentMax);
            }
            return maxSumSofar;
        }


        //3.Longest Increasing Subsequence - Find the length of the longest subsequence of a given sequence such that all the elements are sorted in increasing/non-decreasing order.
        //public static int Recursive_LongestIncreasingSubsequence<T>(List<T> list,int endIndex,int max_end_index) where T : IComparable<T>
        //{
        //    if (endIndex == 0) return 1;
        //    else 
        //    {
        //        int max_end_here = 1;

        //        if(list[endIndex]>=list[max_end_index])return 1+Recursive_LongestIncreasingSubsequence(list,endIndex-1,);
        //        else
        //    }
        //        return Recursive_LongestIncreasingSubsequence(list,endIndex-1)


        //}
        

        public static void LongestIncreasingSubsequence<T>(List<T> list) where T : IComparable<T>
        {
            bool[] lis_mark = new bool[list.Count];//used to mark the lis elements 
            int[] lis_arr = new int[list.Count];
            lis_arr[0] = 1;

            
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (list[i].CompareTo(list[j]) > 0)
                    {
                        if (lis_arr[i] < lis_arr[j] + 1)
                            lis_arr[i] = lis_arr[j] + 1;
                    }
                    else
                    {
                        if (lis_arr[i] < lis_arr[j])
                        lis_arr[i] = lis_arr[j];
                    }
                }
            }
           
        }


        //4.Edit Distance - Given two strings and a set of operations Change (C), insert (I) and delete (D) , find minimum number of edits (operations) required to transform one string into another.
        public static int Minimum(int a,int b,int c)
        {
            return Math.Min(Math.Min(a,b),c);
        }
        //Top down recursive 
        public static int LevenshteinDistance(string s,int index_s,string  t, int index_t)
        {
            if (index_s < 0) return index_t+1;
            if (index_t < 0) return index_s+1;
            int cost = 0;
            if (s[index_s] == t[index_t]) cost = 0;
            else cost = 1;

            return Minimum(
                LevenshteinDistance(s, index_s - 1, t, index_t) + 1,
                LevenshteinDistance(s, index_s, t, index_t - 1) + 1,
                LevenshteinDistance(s, index_s - 1, t, index_t - 1) + cost
                );     
        }

        //Bottom up iterative
        public static int LevenshteinDistance(string s, string t)
        {
            int[,] distance = new int[s.Length+1, t.Length+1];

            for (int i = 1; i <= s.Length; i++) distance[i, 0] = i;
            for (int j = 1; j <= t.Length; j++) distance[0, j] = j;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < t.Length; j++)
                {
                    if (s[i] == t[j]) distance[i+1, j+1] = distance[i+1 - 1, j+1 - 1];
                    else
                    {
                        distance[i+1, j+1] = Minimum(distance[i+1-1,j+1],distance[i+1,j+1-1],distance[i+1-1,j+1-1])+1;
                        
                    }
                    
                }
                
            }

            //for (int i = 0; i <= s.Length; i++)
            //{
            //    for (int j = 0; j <= t.Length; j++)
            //    {
            //        Console.Write(distance[i,j]+",");
            //    }
            //    Console.WriteLine(";");
            //}



                return distance[s.Length - 1, t.Length - 1];
        }




        //5.0/1 Knapsack Problem - A thief robbing a store and can carry a maximal weight of W 
        //into their knapsack. There are n items and ith item weigh wi and is worth vi dollars.
        //What items should thief take?
        //public static int Knapsack(int maxWeight,int maxItems,int[] items, int[] itemWeights)
        //{
        //    if (maxWeight == 0 || maxItems == 0) return 0;
        //    else
        //    { 

        //    }
        //}

    }
}
