using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public static class TestUtility
    {
        public static void TestQueue()
        {
            try
            {

                DataStructure.ArrayQueue<string> queue = new DataStructure.ArrayQueue<string>(5);
                queue.Enqueue("A");
                queue.Enqueue("B");
                queue.Enqueue("C");
                //queue.Enqueue("D");
                // queue.Enqueue("E");
                //queue.Dequeue();
                //queue.Dequeue();
                queue.Enqueue("A"); 
                queue.Enqueue("B");
                List<string> alist = queue.Where(node => node.ToString() == "A").ToList();
                foreach (var item in queue)
                {
                    Console.WriteLine(item.ToString());
                }
                //queue.Enqueue("F");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TestLinkedList()
        {
            try
            {
                DataStructure.SingleLinkedList<string> list = new DataStructure.SingleLinkedList<string>();
                DataStructure.SingleLinkedListNode<string> a = new DataStructure.SingleLinkedListNode<string>("a");
                DataStructure.SingleLinkedListNode<string> b = new DataStructure.SingleLinkedListNode<string>("b");
                DataStructure.SingleLinkedListNode<string> c = new DataStructure.SingleLinkedListNode<string>("c");
                DataStructure.SingleLinkedListNode<string> d = new DataStructure.SingleLinkedListNode<string>("d");
                list.AddBack(a);
                list.AddBack(b);
                list.AddBack(c);
                list.AddBack(d);
              //  list.AddBack(e);
                foreach(string item in list)
                {
                    Console.WriteLine(item);
                }
                Interview.GoldmanSachs.ReverseSingleLinkedList(list);
                foreach (string item in list)
                {
                    Console.WriteLine(item);
                }
                //DataStructure.DoubleLinkedList<string> list = new DataStructure.DoubleLinkedList<string>();
                //DataStructure.DoubleLinkedListNode<string> a = new DataStructure.DoubleLinkedListNode<string>("a");
                //DataStructure.DoubleLinkedListNode<string> b = new DataStructure.DoubleLinkedListNode<string>("b");
                //DataStructure.DoubleLinkedListNode<string> c = new DataStructure.DoubleLinkedListNode<string>("c");
                //list.AddFront(a);
                //list.AddFront(b);
                //list.AddTail(c);

                //foreach (string item in list)
                //{
                //    Console.WriteLine(item.ToString());
                //}


                //list.RemoveFront();
                //list.RemoveTail();
                //DataStructure.DoubleLinkedListNode<string> d = new DataStructure.DoubleLinkedListNode<string>("d");
                //DataStructure.DoubleLinkedListNode<string> e = new DataStructure.DoubleLinkedListNode<string>("e");
                //list.AddTail(d);
                //list.AddTail(e);
                //foreach (string item in list)
                //{
                //    Console.WriteLine(item.ToString());
                //}
            }
            catch (Exception ex)
            {
            }
        }

        public static void TestBinarySearchTree()
        {
            DataStructure.BinarySearchTree<int> bst = new DataStructure.BinarySearchTree<int>();
            bst.Insert(new DataStructure.TreeNode<int>(15));
            bst.Insert(new DataStructure.TreeNode<int>(6));
            bst.Insert(new DataStructure.TreeNode<int>(18));
            bst.Insert(new DataStructure.TreeNode<int>(3));
            bst.Insert(new DataStructure.TreeNode<int>(7));
            bst.Insert(new DataStructure.TreeNode<int>(17));
            bst.Insert(new DataStructure.TreeNode<int>(20));
            bst.Insert(new DataStructure.TreeNode<int>(2));
            DataStructure.TreeNode<int> node4 = new DataStructure.TreeNode<int>(4);
            bst.Insert(node4);
            DataStructure.TreeNode<int> node13 = new DataStructure.TreeNode<int>(13);
            bst.Insert(node13);
            bst.Insert(new DataStructure.TreeNode<int>(9));

            DataStructure.TreeNode<int> lca = (DataStructure.TreeNode<int>)Interview.GoldmanSachs.LowestCommonAncester(bst.Root, node4, node13);
            //Console.WriteLine("Pre order traversal:");
            //List<DataStructure.TreeNode<int>> pre_list = bst.PreOrderTraversal();
            //foreach (DataStructure.TreeNode<int> node in pre_list)
            //{
            //    Console.WriteLine(node.Value);
            //}

            //Console.WriteLine("In order traversal:");
            //List<DataStructure.TreeNode<int>> in_list = bst.InOrderTraversal();
            //foreach (DataStructure.TreeNode<int> node in in_list)
            //{
            //    Console.WriteLine(node.Value);
            //}

            //Console.WriteLine("Post order traversal:");
            //List<DataStructure.TreeNode<int>> post_list = bst.PostOrderTraversal();
            //foreach (DataStructure.TreeNode<int> node in post_list)
            //{
            //    Console.WriteLine(node.Value);
            //}

            //DataStructure.TreeNode<int> cur_node = bst.Search(20);
            //DataStructure.TreeNode<int> successor = bst.Successor(cur_node);
            //DataStructure.TreeNode<int> Predecessor = bst.Predecessor(cur_node);

            //Interview.GoldmanSachs.LevelByLevel(bst.Root);
           Console.WriteLine( Interview.GoldmanSachs.DepthOfBinaryTree(bst.Root)  );
            
        }


        public static void TestGraph()
        {
            #region test undirected graph
            DataStructure.Graph undirectedGraph = new DataStructure.Graph(DataStructure.Graph.GraphType.IsUndirected);
            DataStructure.GraphVertex r = new DataStructure.GraphVertex("r");
            DataStructure.GraphVertex s = new DataStructure.GraphVertex("s");
            DataStructure.GraphVertex t = new DataStructure.GraphVertex("t");
            DataStructure.GraphVertex u = new DataStructure.GraphVertex("u");
            DataStructure.GraphVertex v = new DataStructure.GraphVertex("v");
            DataStructure.GraphVertex w = new DataStructure.GraphVertex("w");
            DataStructure.GraphVertex x = new DataStructure.GraphVertex("x");
            DataStructure.GraphVertex y = new DataStructure.GraphVertex("y");
            DataStructure.GraphVertex z = new DataStructure.GraphVertex("z");

            undirectedGraph.AddVertex(new List<DataStructure.GraphVertex> { r, s, t, u, v, w, x, y, z });

            undirectedGraph.AddEdge(r, v);
            undirectedGraph.AddEdge(r, s);
            undirectedGraph.AddEdge(s, w);
            undirectedGraph.AddEdge(w, t);
            undirectedGraph.AddEdge(w, x);
            undirectedGraph.AddEdge(t, x);
            undirectedGraph.AddEdge(t, u);
            undirectedGraph.AddEdge(x, u);
            undirectedGraph.AddEdge(x, y);
            undirectedGraph.AddEdge(u, y);


            foreach (DataStructure.GraphEdge edge in undirectedGraph.Edges)
            {
                System.Console.WriteLine(edge.FromVertex.Label + "----->" + edge.ToVertex.Label);
            }

            List<DataStructure.GraphVertex> list = DataStructure.GraphAlgorithm.BreadthFirstSearch(undirectedGraph, s);

            foreach (DataStructure.GraphVertex vertex in list)
            {
                System.Console.WriteLine(vertex.Label);
            }

            #endregion


            #region test directed graph
                
            #endregion
        }
    }
}
