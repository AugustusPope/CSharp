using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public static class CareerCup
    {
        //1.1Implement an algorithm to determine if a string has all unique characters.
        //What if you can not use additional data structures?
        public static bool IsUniqueString(string obj)
        {
            bool[] charSet = new bool[256];
            foreach (char item in obj)
            {
                int index = Convert.ToInt16(item);
                if (charSet[index] == true) return false;
                else charSet[index] = true;
            }
            return true;

        }

        //1.2 Write code to reverse a C-Style String. (C-String means that “abcd” is represented as five characters, including the null character.)

        // 1.3 Design an algorithm and write code to remove the duplicate characters in a string without using any additional buffer. 
        //NOTE: One or two additional variables are fine. An extra copy of the array is not.
        //FOLLOW UP     Write the test cases for this method.


        //1.4 Write a method to decide if two strings are anagrams or not.
        //public static bool IsAnagram(string leftString, string rightString)
        //{
        //    char[] leftArray = leftString.ToArray();
        //    char[] rightArray = rightString.ToArray();
        //    System.Array.Sort(leftArray);
        //    System.Array.Sort(rightArray);
        //    return Enumerable.SequenceEqual(leftArray, rightArray);
        //}

        public static bool IsAnagram(string leftString, string rightString)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in leftString)
            {
                if (charCount.ContainsKey(c)) charCount[c]++;
                else charCount.Add(c,1);
            }

            foreach (char c in rightString)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]--;
                    if (charCount[c] < 0) return false;
                }
                else return false;
            }

            return true;
        }

        //1.5 Write a method to replace all spaces in a string with ‘%20’.


        //1.6 Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, 
        //write a method to rotate the image by 90 degrees. Can you do this in place?
        public static void RotateMatrix<T>(T[,] matrix)
        {
            //int dimensional = matrix[];
            //int totalLayer = dimensional / 2;
            //int rotateTimes = dimensional - 1;
            //for (int layer = 1; layer < totalLayer; layer++) {
            //    for (int offset = 0; offset < rotateTimes; offset++) { 

            //       // int top = matrix[][];
            //    }

            //}
        }


        //1.7 Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column is set to 0.
        //Solution:At first glance, this problem seems easy: just iterate through the matrix and every time we see a 0, 
        //set that row and column to 0. There’s one problem with that solution though: 
        //we will “recognize” those 0s later on in our iteration and then set their row and column to zero. 
        //Pretty soon, our entire matrix is 0s!
        //One way around this is to keep a second matrix which flags the 0 locations. We would then do a second pass through the matrix to set the zeros. 
        //This would take O(MN) space.Do we really need O(MN) space? No. Since we’re going to set the entire row and column to zero, 
        //do we really need to track which cell in a row is zero? No. We only need to know that row 2, for example, has a zero.
        //The code below implement this algorithm. We keep track in two arrays all the rows with zeros and all the columns with zeros.
        //We then make a second pass of the matrix and set a cell to zero if its row or column is zero.
        public static void SetZeros(int[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);
            bool[] zeroRow = new bool[rowCount];
            bool[] zeroColumn = new bool[columnCount];

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    if (matrix[row, column] == 0)
                    {
                        zeroRow[row] = true;
                        zeroColumn[column] = true;
                    }
                }
            }


            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    if (zeroRow[row] == true || zeroColumn[column] == true)
                    {
                        matrix[row, column] = 0;
                    }
                }
            }

        }


        

        public static bool IsSubstring(string parentString, string childString)
        {

            if (parentString == null || parentString.Count() < 1) return false;
            if (childString == null || childString.Count() < 1) return false;
            if (parentString.Count() < childString.Count()) return false;

            int parentIndex = 0;
            int childIndex = 0;

            while (parentIndex < parentString.Count())
            {
                if (parentString[parentIndex] == childString[childIndex])
                {
                    parentIndex++;
                    childIndex++;

                    if (childIndex == childString.Count()) return true;
                }
                else
                {
                    parentIndex++;
                    childIndex = 0;
                }
            }

            return false;

        }

        //   Just do the following checks
        //1. Check if length(s1) == length(s2). If not, return false.
        //2. Else, concatenate s1 with itself and see whether s2 is substring of the result.
        //input: s1 = apple, s2 = pleap ==> apple is a substring of pleappleap
        //input: s1 = apple, s2 = ppale ==> apple is not a substring of ppaleppale
        public static bool IsRotationString(string leftString, string rightString) {
            if (leftString==null||rightString==null||leftString.Count()<1||rightString.Count()<1||leftString.Count() != rightString.Count()) return false;

            string doubleLeft = leftString + leftString;
            return IsSubstring(doubleLeft,rightString);
        }



        //2.1 Write code to remove duplicates from an unsorted linked list.
        //FOLLOW UP
        //How would you solve this problem if a temporary buffer is not allowed?



        //2.2 Implement an algorithm to find the nth to last element of a singly linked list.
        //datastr


        //        2.3 Implement an algorithm to delete a node in the middle of a single linked list, given only access to that node.
        //EXAMPLE
        //Input: the node ‘c’ from the linked list a->b->c->d->e
        //Result: nothing is returned, but the new linked list looks like a->b->d->e





    }
}
