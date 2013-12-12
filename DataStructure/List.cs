using System;
using System.Collections.Generic;
//using System.Collections;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class SingleLinkedListNode<T>
    {
        public SingleLinkedListNode(T value,SingleLinkedListNode<T> next = null) 
        {
            Value = value;
            Next = next;
        }
        public SingleLinkedListNode<T> Next { get; set; }
        public T Value { get; set; }
    }

    public class SingleLinkedList<T>:IEnumerable<T>
    {
        //property
        public SingleLinkedListNode<T> Head { get; set; }
        public int Count { get; private set; }

        public SingleLinkedList()
        {
            Head = null;
        }

        public void AddFront(SingleLinkedListNode<T> obj) 
        {
            if (Head== null) Head = obj;
            else {
                obj.Next = Head;
                Head = obj;
            }
            Count++;
        }

        public void AddBack(SingleLinkedListNode<T> obj)
        {
            if (Head == null) Head = obj;
            else {
                SingleLinkedListNode<T> temp = Head;
                while (temp.Next!=null) {
                    temp = temp.Next;
                }
                temp.Next = obj;
            }
            Count++;
        }


        public void AddAfter(SingleLinkedListNode<T> node, SingleLinkedListNode<T> newNode) 
        {
            if (node == null) throw new ArgumentNullException("node","node can not be null!");
            if (newNode == null) throw new ArgumentNullException("newNode", "newNode can not be null!");
            else node.Next = newNode;
            Count++;
        }

        System.Collections.Generic.IEnumerator<T>   System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            return new SingleLinkedListEnumberator(this);
        }

        System.Collections.IEnumerator   System.Collections.IEnumerable.GetEnumerator()
        {
            return new SingleLinkedListEnumberator(this);
        }




        #region IEnumerator
        internal struct SingleLinkedListEnumberator : IEnumerator<T>, IDisposable, System.Collections.IEnumerator
        {
               public SingleLinkedListEnumberator(SingleLinkedList<T> list) {
                    _currentList = list;
                    _currentNode = list.Head;
                    _count = 0;
                }
            private SingleLinkedListNode<T> _currentNode;
            private SingleLinkedList<T> _currentList;
            private int _count;
            T System.Collections.Generic.IEnumerator<T>.Current
            {
                get
                {
                    if (_currentNode == null) throw new NullReferenceException("Current node is null!");
                    else return _currentNode.Value;
                }
            }
             object System.Collections.IEnumerator.Current
            {
                get
                {
                    if (_currentNode == null) throw new NullReferenceException("Current node is null!");
                    else return _currentNode;
                }
            }
            public bool MoveNext()
            {
                if (_count == 0)
                {
                    _currentNode = _currentList.Head;
                    _count++;
                    return true;
                }
                else
                {
                    if (_currentNode.Next != null)
                    {
                        _currentNode = _currentNode.Next;
                        _count++;
                        return true;
                    }
                    else return false;
                
                }

                
            }

            void System.Collections.IEnumerator.Reset()
            {
                _currentNode = _currentList.Head;
            }

            void System.IDisposable.Dispose()
            {
                _currentList = null;
                _currentNode = null;
                _count = 0;
            }


        }
        #endregion



    }


    #region DoubleLinkedListNode<T> Defination
    public class DoubleLinkedListNode<T>
    {

        public DoubleLinkedListNode(T value, DoubleLinkedListNode<T> pre = null, DoubleLinkedListNode<T> next = null)
        {
            Value = value;
            Pre = pre;
            Next = next;
        }
        internal void Invalidate()
        {
            Pre = null;
            Next = null;
        }


        public T Value { get; set; }
        public DoubleLinkedListNode<T> Pre { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }

    }
    #endregion

    #region DoubleLinkedList
        public class DoubleLinkedList<T> : IEnumerable<T>
    {


        public DoubleLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void AddFront(DoubleLinkedListNode<T> node)
        {
            if (IsEmpty())
            {
                Head = node;
                Tail = Head;
            }
            else
            {
                node.Next = Head;
                Head.Pre = node;
                Head = node;
            }
            Count++;

        }


        public DoubleLinkedListNode<T> Find(T value)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            DoubleLinkedListNode<T> curNode = this.Head;
            while (curNode != null)
            {
                if (comparer.Equals(curNode.Value, value)) return curNode;
                else curNode = curNode.Next;
            }
            return curNode;
        }

        public bool RemoveNode(T value)
        {
            DoubleLinkedListNode<T> node = Find(value);
            if (node != null)
            {
                RemoveNode(node);
                return true;
            }
            return false;
        }

        internal void RemoveNode(DoubleLinkedListNode<T> node)
        {

            if (node == this.Head)
            {
                this.RemoveFront();
            }
            else if (node == this.Tail)
            {
                this.RemoveTail();
            }
            else
            {
                DoubleLinkedListNode<T> preNode = node.Pre;
                DoubleLinkedListNode<T> nextNode = node.Next;

                preNode.Next = nextNode;
                nextNode.Pre = preNode;

                node.Invalidate();

                this.Count--;

            }

        }


        public void RemoveFront()
        {
            if (IsEmpty())
            {
                throw new System.InvalidOperationException("Can't remove item from empty list! ");
            }
            else
            {
                DoubleLinkedListNode<T> cur = Head;
                Head = Head.Next;
                Head.Pre = null;
                cur.Invalidate();
                Count--;
            }
        }

        public void AddTail(DoubleLinkedListNode<T> node)
        {
            if (IsEmpty())
            {
                Head = node;
                Tail = Head;
            }
            else
            {
                node.Pre = Tail;
                Tail.Next = node;
                Tail = node;
            }

            Count++;
        }

        public void RemoveTail()
        {
            if (IsEmpty())
            {
                throw new System.InvalidOperationException("Can't remove item from empty list! ");
            }
            else
            {
                Tail = Tail.Pre;
                Tail.Next = null;
                Count--;
            }
        }

        public bool IsEmpty()
        {
            return Count <= 0 ? true : false;
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new DoubleLinkedListEnumerator(this);
        }


        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            return new DoubleLinkedListEnumerator(this);
        }


        protected int Count { get; set; }
        protected DoubleLinkedListNode<T> Head { get; set; }
        protected DoubleLinkedListNode<T> Tail { get; set; }


        [Serializable()]
        public struct DoubleLinkedListEnumerator : IEnumerator<T>, IDisposable, System.Collections.IEnumerator
        {
            private DoubleLinkedList<T> _currentList;
            private DoubleLinkedListNode<T> _currentNode;
            private int _count;

            internal DoubleLinkedListEnumerator(DoubleLinkedList<T> list)
            {
                _currentList = list;
                _currentNode = null;
                _count = 0;
            }

            public bool MoveNext()
            {
                if (_count == _currentList.Count) return false;
                else
                {
                    if (_count == 0) _currentNode = _currentList.Head;
                    else _currentNode = _currentNode.Next;
                    _count++;
                    return true;
                }
            }

            object System.Collections.IEnumerator.Current
            {
                get
                {
                    if (_currentNode == null) throw new NullReferenceException("Current node is null!");
                    else return _currentNode;
                }
            }

            T System.Collections.Generic.IEnumerator<T>.Current
            {
                get
                {
                    if (_currentNode == null) throw new NullReferenceException("Current node is null!");
                    else return _currentNode.Value;
                }
            }


            void System.Collections.IEnumerator.Reset()
            {
                _currentNode = _currentList.Head;
            }

            void System.IDisposable.Dispose()
            {
                _currentList = null;
                _currentNode = null;
            }

        }
    }
    #endregion
}
