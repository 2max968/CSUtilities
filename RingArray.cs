using System;
using System.Collections;
using System.Collections.Generic;

namespace Utilities
{
    public class RingArray<T> : IEnumerable<T>, ICollection<T>, IReadOnlyCollection<T>, IList<T>, IEnumerable
    {
        private const string ERRORCAPZERO = "Capacity must be larger than zero.";

        T[] buffer;
        int startPointer = 0;
        int count = 0;

        public int Capacity => buffer.Length;
        public int Count => count;
        public bool IsReadOnly => false;
        public int Position => startPointer;

        public T this[int index]
        {
            get => buffer[getIndex(index)];
            set => buffer[getIndex(index)] = value;
        }

        public RingArray(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(ERRORCAPZERO);
            buffer = new T[capacity];
        }

        private int getIndex(int i)
        {
            if (i < 0 || i >= Capacity)
                throw new IndexOutOfRangeException();
            int index = (startPointer + i) % Capacity;
            return index;
        }

        public void AddEnd(T value)
        {
            if (count < Capacity)
                this[count++] = value;
            else
            {
                buffer[startPointer] = value;
                startPointer++;
                if (startPointer >= Capacity)
                    startPointer = 0;
            }
        }

        public void AddBegin(T value)
        {
            startPointer--;
            if (startPointer < 0)
                startPointer = Capacity - 1;
            buffer[startPointer] = value;
            if (count < Capacity)
                count++;
        }

        public void RemoveEnd()
        {
            if (count > 0)
                count--;
        }

        public void RemoveBegin()
        {
            if (count > 0)
            {
                count--;
                startPointer++;
                if (startPointer >= Capacity)
                    startPointer = 0;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = this[i];
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            CopyTo(array, 0);
            return array;
        }

        public void Add(T item)
        {
            AddEnd(item);
        }

        public void Clear()
        {
            startPointer = 0;
            count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
                if (this[i].Equals(item))
                    return true;
            return false;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0)
                return false;
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Capacity)
                throw new IndexOutOfRangeException();
            if (count <= 0)
                return;
            T[] newBuffer = new T[Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                if (i < index)
                    newBuffer[i] = this[i];
                else if (i > index)
                    newBuffer[i - 1] = this[i];
            }
            startPointer = 0;
            count--;
            buffer = newBuffer;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
                if (this[i].Equals(item))
                    return i;
            return -1;
        }

        public void ReAlloc(int newCapacity)
        {
            if (newCapacity <= 0)
                throw new ArgumentOutOfRangeException(ERRORCAPZERO);
            T[] newBuffer = new T[newCapacity];
            int newCount = Math.Min(newCapacity, Count);
            for (int i = 0; i < newCount; i++)
            {
                newBuffer[i] = this[i];
            }
            startPointer = 0;
            count = newCount;
            buffer = newBuffer;
        }

        /// <summary>
        /// Not Implemented
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Range(int start, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return this[start + i];
            }
        }
    }
}
