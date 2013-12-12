using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{


    public class TreeNode<T> where T : IComparable 
    {
        //Constructor
        public TreeNode(T value,TreeNode<T> parent = null, 
            TreeNode<T> leftchild = null,TreeNode<T> rightchild = null) 
        {
            Value = value;
            Parent = parent;
            LeftChild = leftchild;
            RightChild = rightchild;
        }

        public T Value { get; internal set; }
        public TreeNode<T> Parent { get; internal set; }
        public TreeNode<T> LeftChild { get; internal set; }
        public TreeNode<T> RightChild { get; internal set; }
    }



    public class BinarySearchTree<T> where T:IComparable
    {
        public BinarySearchTree() {
            Root = null;
        }

        #region METHODS
            public bool IsEmpty(){
                return Root == null? true:false;
            }

           public void Insert(TreeNode<T> node)
            {
                if(IsEmpty()){
                    Root = node;
                }
                else{
                    TreeNode<T> parent = null;
                    TreeNode<T> cur = Root;

                    while (cur!=null) {

                        parent = cur;
                        if (node.Value.CompareTo(cur.Value) < 0)
                        {
                            cur = cur.LeftChild;
                        }
                        else
                        {
                            cur = cur.RightChild;
                        }
                    
                    }


                    node.Parent = parent;
                    if (node.Value.CompareTo(parent.Value) < 0)
                    {
                        parent.LeftChild = node;
                    }
                    else 
                    {
                        parent.RightChild = node; 
                    }


                }
        
            }

           public TreeNode<T> Search(T value) {
                TreeNode<T> curNode = this.Root;
                while (curNode != null) {
                    if (curNode.Value.CompareTo(value) == 0) break;
                    else if (curNode.Value.CompareTo(value) > 0) curNode = curNode.LeftChild;
                    else curNode = curNode.RightChild;
                }
                return curNode;
            }

            public TreeNode<T> Maximum()
            {
                TreeNode<T> curNode = this.Root;
                while (curNode != null && curNode.RightChild != null)
                {
                    curNode = curNode.RightChild;
                }
                return curNode;
            }

           public TreeNode<T> Maximum(TreeNode<T> root) {
                while (root != null && root.RightChild != null) {
                    root = root.RightChild;
                }
                return root;
            }

           public TreeNode<T> Minimum()
           {
               TreeNode<T> curNode = this.Root;
               while (curNode != null && curNode.LeftChild != null)
               {
                   curNode = curNode.LeftChild;
               }
               return curNode;
           }

           public TreeNode<T> Minimum(TreeNode<T> root)
           {
               while (root != null && root.LeftChild != null)
               {
                   root = root.LeftChild;
               }
               return root;
           }

           public TreeNode<T> Successor(TreeNode<T> node) {
               if (node == null) throw new ArgumentNullException("TreeNode could not be null!");
               else {
                   if (node.RightChild != null)
                   {
                       return Minimum(node.RightChild);
                   }
                   else
                   {
                       TreeNode<T> parent = node.Parent;
                       while (parent != null && parent.RightChild == node) {
                           node = parent;
                           parent = parent.Parent;
                       }
                       return parent;
                   }
               }
               
           }

           public TreeNode<T> Predecessor(TreeNode<T> node)
           {
               if (node == null) throw new ArgumentNullException("TreeNode could not be null!");
               else
               {
                   if (node.LeftChild != null)
                   {
                       return Maximum(node.LeftChild);
                   }
                   else
                   {
                       TreeNode<T> parent = node.Parent;
                       while (parent != null && parent.LeftChild== node)
                       {
                           node = parent;
                           parent = parent.Parent;
                       }
                       return parent;
                   }
               }

           }

           public List<TreeNode<T>> PreOrderTraversal()
           {
               List<TreeNode<T>> list = new List<TreeNode<T>>();
               PreOrderTraversal(Root, list);
               return list;
           }
           public void PreOrderTraversal(TreeNode<T> root, List<TreeNode<T>> list)
           {
               if (root != null)
               {
                   list.Add(root);
                   PreOrderTraversal(root.LeftChild, list);                   
                   PreOrderTraversal(root.RightChild, list);
               }
           }

            public List<TreeNode<T>> InOrderTraversal()
            {
                List<TreeNode<T>> list = new List<TreeNode<T>>();
                InOrderTraversal(Root,list);
                return list;
            }
            public void InOrderTraversal(TreeNode<T> root, List<TreeNode<T>> list)
            {
                if (root != null) {
                    InOrderTraversal(root.LeftChild,list);
                    list.Add(root);
                    InOrderTraversal(root.RightChild, list);
                }    
            }

            public List<TreeNode<T>> PostOrderTraversal()
            {
                List<TreeNode<T>> list = new List<TreeNode<T>>();
                PostOrderTraversal(Root, list);
                return list;
            }
            public void PostOrderTraversal(TreeNode<T> root, List<TreeNode<T>> list)
            {
                if (root != null)
                {
                    
                    PostOrderTraversal(root.LeftChild, list);
                    PostOrderTraversal(root.RightChild, list);
                    list.Add(root);
                }
            }
        #endregion

        #region PROPERTIES
            public TreeNode<T> Root { get; set; }
        #endregion

    }
}
