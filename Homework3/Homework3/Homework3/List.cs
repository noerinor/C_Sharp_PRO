using System;

namespace ListLibrary
{
    public class List
    {
        private object[] _items;
        private int _count;

        public List() : this(4) { }

        public List(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Ємність має бути більше або дорівнювати 0.");

            _items = new object[capacity];
            _count = 0;
        }

        public int Count => _count;

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Індекс виходить за межі діапазону.");
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Індекс виходить за межі діапазону.");
                _items[index] = value;
            }
        }

        public void Add(object item)
        {
            EnsureCapacity(_count + 1);
            _items[_count++] = item;
        }

        public void Insert(int index, object item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс виходить за межі діапазону.");

            EnsureCapacity(_count + 1);

            for (int i = _count; i > index; i--)
                _items[i] = _items[i - 1];

            _items[index] = item;
            _count++;
        }

        public void Remove(object item)
        {
            int index = IndexOf(item);
            if (index != -1)
                RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс виходить за межі діапазону.");

            for (int i = index; i < _count - 1; i++)
                _items[i] = _items[i + 1];

            _items[--_count] = null;
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
                _items[i] = null;

            _count = 0;
        }

        public bool Contains(object item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(object item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_items[i], item))
                    return i;
            }
            return -1;
        }

        public object[] ToArray()
        {
            var result = new object[_count];
            for (int i = 0; i < _count; i++)
                result[i] = _items[i];
            return result;
        }

        public void Reverse()
        {
            for (int i = 0, j = _count - 1; i < j; i++, j--)
            {
                var temp = _items[i];
                _items[i] = _items[j];
                _items[j] = temp;
            }
        }

        private void EnsureCapacity(int minimum)
        {
            if (_items.Length < minimum)
            {
                int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
                if (newCapacity < minimum)
                    newCapacity = minimum;

                var newItems = new object[newCapacity];
                for (int i = 0; i < _count; i++)
                    newItems[i] = _items[i];

                _items = newItems;
            }
        }
    }
}
