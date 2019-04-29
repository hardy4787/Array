using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MyArray<T> : IList<T>
    {

        private T[] _elements;
        private int _correctionIndex;
        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                index += _correctionIndex;
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                return _elements[index];
            }
            set
            {
                index += _correctionIndex;
                if (value == null) throw new NullReferenceException();
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                _elements[index] = value;
            }
        }


        public MyArray(int leftBorder, int rightBorder)
        {
            if (leftBorder > rightBorder) throw new ArgumentException("The left border must be less than the right");
            _elements = new T[rightBorder - leftBorder + 1];
            _correctionIndex = leftBorder * -1;
        }

        public MyArray(ICollection<T> Collection)
        {
            if (Collection == null) throw new NullReferenceException();
            _elements = new T[Collection.Count];
            foreach (var el in Collection)
                _elements[Count++] = el;
        }
        


        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_elements[i].Equals(item))
                    return i - _correctionIndex;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            index += _correctionIndex;
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            if (_elements.Length == Count) GrowArray();
            Count++;    
            for (int i = Count - 1; i > index; i--)
            {
                _elements[i] = _elements[i - 1];
            }
            _elements[index] = item;
        }

        public void RemoveAt(int index)
        {
            index += _correctionIndex;
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            for (int i = index; i < Count - 1; i++)
                _elements[i] = _elements[i + 1];
            Count--;
        }
        public void Add(T value)
        {
            if (value == null) throw new NullReferenceException();
            if (Count == _elements.Length) GrowArray();
            _elements[Count] = value;
            Count++;
        }

        public void GrowArray()
        {
            int newLength = _elements.Length == 0 ? 4 : _elements.Length << 1;
            T[] newArray = new T[newLength];
            for (int i = 0; i < Count; i++)
            {
                newArray[i] = _elements[i];
            }
            _elements = newArray;
        }

        public void Clear()
        {
            Count = 0;
            _elements = new T[0];
        }


        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_elements[i].Equals(item))
                    return true;
            }
            return false;
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("Not enough elements after arrayIndex in the destination array.");
            for (int i = 0; i < Count; i++)
                array[i + arrayIndex] = this[i - _correctionIndex];
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item) + _correctionIndex;
            if (index != -1)
            {
                RemoveAt(index - _correctionIndex);
                return true;
            }
            else return false;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return _elements[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}

