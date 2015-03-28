using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CustomCollections
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private T[] queue;

        #region Properties
        private int Head { get; set; }
        private int Tail { get; set; }
        public int Size { get; private set; } 
        #endregion

        #region Indexer
        private T this[int index]
        {
            get { return queue[index]; }
        } 
        #endregion
        public CustomQueue()
        {
            this.queue = new T[4];
            Head = 0;
            Tail = -1;
            Size = 0;
        }

        public void Enqueue(T item)
        {
            if (queue.Length == Size)
            {
                SetCapacity();
            }

            if (Tail == queue.Length - 1)
            {
                Tail = 0;
            }

            else
            {
                Tail++;
            }

            queue[Tail] = item;
            Size++;
        }

        public T Dequeue()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
            T result = queue[Head];
            if(Head == queue.Length)
            {
                Head = 0;
            }
            else
            {
                Head++;
            }
            Size--;
            return result;
        }

        public T Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            return queue[Head];
        }

        private void SetCapacity()
        {
            T[] temp = new T[Size * 2];
            int currentIndex = 0;
            foreach(var x in this)
            {
                temp[currentIndex++] = x;
            }
            queue = temp;
            Head = 0;
            Tail = currentIndex - 1;
        }

        #region IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region IEnumerator<T>
        private class QueueIterator : IEnumerator<T>
        {
            private readonly CustomQueue<T> queue;
            private int currentIndex;

            public QueueIterator(CustomQueue<T> enumerable)
            {
                this.currentIndex = enumerable.Head - 1;
                this.queue = enumerable;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == queue.Size)
                    {
                        throw new InvalidOperationException();
                    }
                    return queue[currentIndex];
                }
            }

            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public void Reset()
            {
                currentIndex = queue.Head - 1;
            }

            public bool MoveNext()
            {
                if (queue.Head < queue.Tail) return ++currentIndex <= queue.Tail;
                else
                {
                    if (currentIndex == queue.queue.Length - 1) currentIndex = -1;
                    return ++currentIndex != queue.Tail + 1;
                }
            }

            public void Dispose() { }
        } 
        #endregion
    }
}
