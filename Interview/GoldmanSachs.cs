using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public static class GoldmanSachs
    {
        //Find Common Ancestor of given two nodes A and B 
        //Condition :Node does not have the parent pointer and data value. 

        //So its is like class Node { 
        //Node L; 
        //Node R; 
        //} 

        private static int MatchTreeNode(DataStructure.TreeNode<int> root, DataStructure.TreeNode<int> p, DataStructure.TreeNode<int> q)
        {
            if (root == null) return 0;
            int matchs = MatchTreeNode(root.LeftChild,p,q) + MatchTreeNode(root.RightChild,p,q);
            if (root == p || root == q) return 1 + matchs;
            else return matchs;
        }
        public static System.Object LowestCommonAncester(DataStructure.TreeNode<int> root,DataStructure.TreeNode<int> p,DataStructure.TreeNode<int> q)
        {

            if (root == null || p == null || q == null) return null;

            int leftMatchs = MatchTreeNode(root.LeftChild,p,q);

            switch(leftMatchs)
            {
                case 0: return LowestCommonAncester(root.RightChild,p,q);
                case 1: return root;
                case 2: return LowestCommonAncester(root.LeftChild,p,q);
                default: return null;
            }

            

        
        }


        //Given an integer, return all sequences of numbers that sum to it. 
        public static List<List<int>> SequenceSum(int sum) {
           
            List<List<int>> result = new List<List<int>>();

            if (sum == 0) {result.Add(new List<int> {  }); return result; }
            //if (sum == 1) { result.Add(new List<int> { 0, 1 }); result.Add(new List<int> { 1, 0 }); return result; }
            else
            {
                for (int i = 1; i <= sum;i++ )
                {
                    List<List<int>> subSum = SequenceSum(sum - i);

                    foreach (List<int> list in subSum)
                    {   
                            list.Add(i);
                            result.Add(list);       
                    }
                }        
            }
           
            return result;
        }

        //Give me a level by level output of a binary tree. (BFS)
        public static void LevelByLevel(DataStructure.TreeNode<int> root){

            if(root==null)return;

            List<DataStructure.TreeNode<int>> result = new List<DataStructure.TreeNode<int>>();

            Queue<DataStructure.TreeNode<int>> queue = new Queue<DataStructure.TreeNode<int>>();

            queue.Enqueue(root);

            while(queue.Count>0){
                DataStructure.TreeNode<int> cur = queue.Dequeue();
                result.Add(cur);
                if(cur.LeftChild!=null)queue.Enqueue(cur.LeftChild);
                if(cur.RightChild!=null)queue.Enqueue(cur.RightChild);           
            }

            foreach (DataStructure.TreeNode<int> node in result)
            {
                Console.WriteLine(node.Value);
            }
       }

        //Reverse a linked-list.
        public static void ReverseSingleLinkedList(DataStructure.SingleLinkedList<string> list)
        {
            if (list == null) throw new ArgumentNullException("list","list can not be null!");

            DataStructure.SingleLinkedListNode<string> pre = null;
            DataStructure.SingleLinkedListNode<string> cur = list.Head;
            DataStructure.SingleLinkedListNode<string> next = null;
           

            while (cur != null)
            {
                next = cur.Next;
                cur.Next = pre;
                pre = cur;
                cur = next;
               // pnext = pnext.Next;

            }

            

            list.Head = pre;



        }


        //Given hour and minute, write a function to calculate an angle between hour/minute hand.
        public static double GetAngleOfWatch(int hour,int minute) 
        {
            if (hour < 1 || hour > 12) throw new ArgumentOutOfRangeException("hour","hour must be integer within [1,12]");
            if (minute < 1 || minute > 59) throw new ArgumentOutOfRangeException("minute","minute must be integer within [1,59]");

            double minuteAngle = 360  * minute/60.0;
            double hourAngle = 360 * (hour / 12.0) + 30 * (minute / 60.0);

            double absAngle = Math.Abs(minuteAngle - hourAngle);

            return Math.Min(absAngle,360-absAngle);

            
        }

        //Find depth of the binary tree?
        public static int DepthOfBinaryTree(DataStructure.TreeNode<int> root)
        {
            if (root == null) return 0;
            else return 1 + Math.Max(DepthOfBinaryTree(root.LeftChild),DepthOfBinaryTree(root.RightChild));
        }


        //write a program to determine if a number can be expressed as 2^x.for example 4 is 2^2. 

        public static bool IsPowerOf2(int num)
        {
            //if (num < 1) return false;

            //if (num == 1 || num == 2) return true;

            //if (num % 2 > 0) return false;
            //else return IsPowerOf2(num/2);

            if(num<1)return false;

            return (num & (num - 1)) == 0;
        }


        //Traverse an N*M matrix clockwise. Start from the out most layers, and move to the inner most layer in a spiral fashion. For example, if the matrix is
        //1 3 4 2 1
        //2 2 3 1 1
        //4 1 2 1 4
        //the out put is 1 3 4 2 1 1 4 1 2 1 4 2 2 3 1
        public static void MatrixClockwiseTraversal(int[,] matrix)
        {

            int startRowIndex = 0;
            int endRowIndex = matrix.GetLength(0) - 1;
            int startColumnIndex = 0;
            int endColumnIndex = matrix.GetLength(1) - 1;

            while(startRowIndex<=endRowIndex&&startColumnIndex<=endColumnIndex)
            {
                //traverse the top row
                for (int col = startColumnIndex; col <= endColumnIndex; col++)
                {
                    Console.Write(matrix[startRowIndex, col]);
                }
                startRowIndex++;//cut top row off

                //traverse the rightmost column
                for (int row = startRowIndex; row <= endRowIndex; row++)
                {
                    Console.Write(matrix[row, endColumnIndex]);
                }
                endColumnIndex--;//cut rightmost column off

                //traverse the bottom row
                for (int col = endColumnIndex; col >= startColumnIndex; col--)
                {
                    Console.Write(matrix[endRowIndex, col]);
                }
                endRowIndex--;// cut bottom row off

                //traverse the bottom row
                for (int row = endRowIndex; row >= startRowIndex; row--)
                {
                    Console.Write(matrix[row, startColumnIndex]);
                }
                startColumnIndex++;// cut leftmostcolumn off
            
            }
        }



        //write a function to swap integers not using third int?  
        public static void SwapInteger(ref int left,ref int right)
        {
            left = left + right;
            right = left - right;
            left = left - right;

        }


        //how to find square root of integer
        //public static int PositiveSquareRoot(int num)
        //{
        //    if (num < 0) throw new ArgumentException("num","num must >= 0 !");

        //    if (num == 0) return 0;
        //    if (num == 1) return 1;

        //    int i = 0;
        //    int square;
        //    do
        //    {
        //        square = i*i;
        //    }
        //    while（square<num）


        //}



    }
}
