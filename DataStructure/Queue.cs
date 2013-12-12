

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Security.Permissions;
namespace DataStructure
{
    // Generic queue based on array structure
    public class ArrayQueue<T>: IEnumerable<T>,IEnumerable
    {
        //Constructor
        public ArrayQueue(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException("Invalid capacity value");
            else {
                _Items = new T[capacity];
                Capacity = capacity;
                Count = 0;
                _Head = -1;
                _Tail = -1;
            }
                      
        }

        public T this[int index] {
            get {
                if (index < 0 || index >= Capacity) throw new IndexOutOfRangeException();
                else return _Items[index];
            }
        }

        public void Enqueue(T item) {
            if (IsFull()) throw new System.InvalidOperationException("Queue has reach its capacity, please increase the capacity before you add new item.");
            else {
                
                _Tail = (_Tail + 1) % Capacity;
                _Items[_Tail] = item;
                if (_Head == -1) _Head = 0;
                Count++;
               // _Tail = (_Tail + 1) % Capacity;
            }
        }

        public void Dequeue() {
            if (IsEmpty()) throw new System.InvalidOperationException("This is an empty Queue!");
            else {
                Count -- ;
                _Items[_Head] = default(T);
                _Head = (_Head + 1) % Capacity;
            }
        }

        private void Reset() {
            _Head = 0;
            _Tail = 0;
            Count = 0;
        }
        public bool IsEmpty() {
            if (Count == 0) return true;
            else return false;
        }

        public bool IsFull() {
            if (Count == Capacity) return true;
            else return false;
        }


        public ArrayQueueEnumerator GetEnumerator()
        {
            return new ArrayQueueEnumerator(this);
        }

        //implement GetEnumerator() of System.Collections.Generic.IEnumerable<T>.
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            return new ArrayQueueEnumerator(this);
        }


        //implement GetEnumerator() of System.Collections.IEnumerable
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new ArrayQueueEnumerator(this);
        }

        #region  Properties and Fields
            public int Capacity { get; private set; }
            public int Count { get; private set;}
            private T[] _Items { get; set; }
            private int _Head {get;set;}
            private int _Tail { get; set; }
            
        #endregion

        [Serializable]
        public struct ArrayQueueEnumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private ArrayQueue<T> _currentQueue;
            private int _currentIndex;
            private T _currentElement;
            private int _traversedCount;

            //Constructor
            internal ArrayQueueEnumerator(ArrayQueue<T> queue)
            {
                _currentQueue = queue;
                _currentIndex = queue._Head - 1;
                _traversedCount = 0;
                _currentElement = default(T);
            }

            // Summary:
            //     Releases all resources used by the System.Collections.Generic.Stack<T>.Enumerator.
            public void Dispose() {
                _currentIndex = -2;
                _currentElement = default(T);
            }

            //
            // Summary:
            //     Advances the enumerator to the next element of the System.Collections.Generic.Stack<T>.
            //
            // Returns:
            //     true if the enumerator was successfully advanced to the next element; false
            //     if the enumerator has passed the end of the collection.
            //
            // Exceptions:
            //   System.InvalidOperationException:
            //     The collection was modified after the enumerator was created.
            public bool MoveNext() {
                if (_traversedCount >= _currentQueue.Count) return false;
                else {
                    _currentIndex = (_currentIndex + 1) % _currentQueue.Capacity;
                    _currentElement = _currentQueue[_currentIndex];
                    _traversedCount++;
                    return true;
                }
                             
            }
            // Summary:
            //     Gets the element at the current position of the enumerator.
            //
            // Returns:
            //     The element in the System.Collections.Generic.Stack<T> at the current position
            //     of the enumerator.
            //
            // Exceptions:
            //   System.InvalidOperationException:
            //     The enumerator is positioned before the first element of the collection or
            //     after the last element.
            public T Current {
                get {
                    if (_currentIndex < 0) throw new InvalidOperationException();
                    if (_currentIndex > _currentQueue.Capacity-1) throw new IndexOutOfRangeException();
                    return _currentQueue[_currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (_currentIndex < 0 || _currentIndex >= _currentQueue.Capacity) throw new IndexOutOfRangeException();
                    return _currentElement;
                }
            }



            void System.Collections.IEnumerator.Reset()
            {
                _currentIndex = -1;              
                _currentElement = default(T);
            }
        }

    }


    
    

}

