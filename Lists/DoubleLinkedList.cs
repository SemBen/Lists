using System;
using System.Text;

namespace Lists
{
    public class DoubleLinkedList<T> : IList<T> where T : IComparable<T>
    {
        private int _length;
        private DoubleLinkedListNode<T> _root;
        private DoubleLinkedListNode<T> _tail;

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value >= 0 ? value : 0;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < Length)
                {
                    DoubleLinkedListNode<T> currentNode = GetNodeByIndex(index);

                    return currentNode.Value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < Length)
                {
                    DoubleLinkedListNode<T> currentNode = GetNodeByIndex(index);

                    currentNode.Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = _root;
        }

        private DoubleLinkedList(T value)
        {
            Length = 1;
            _root = new DoubleLinkedListNode<T>(value);
            _tail = _root;
        }

        private DoubleLinkedList(T[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new DoubleLinkedListNode<T>(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    DoubleLinkedListNode<T> tempNode = _tail;
                    _tail.Next = new DoubleLinkedListNode<T>(values[i]);
                    _tail = _tail.Next;
                    _tail.Previous = tempNode;
                }
            }
            else
            {
                _root = null;
                _tail = _root;
            }
        }

        public static DoubleLinkedList<T> Create(T value)
        {
            if (value != null)
            {
                DoubleLinkedList<T> list = new DoubleLinkedList<T>(value);

                return list;
            }
            else
            {
                throw new NullReferenceException("Value is null");
            }
        }

        public static DoubleLinkedList<T> Create(T[] array)
        {
            if (array != null)
            {
                DoubleLinkedList<T> list = new DoubleLinkedList<T>(array);

                return list;
            }
            else
            {
                throw new NullReferenceException("Array is null");
            }
        }

        public void Add(T value)
        {
            if (value != null)
            {
                if (_tail is null)
                {
                    _root = new DoubleLinkedListNode<T>(value); ;
                    _tail = _root;
                }
                else
                {
                    _tail.Next = new DoubleLinkedListNode<T>(value);
                    _tail.Next.Previous = _tail;
                    _tail = _tail.Next;
                }

                ++Length;
            }
            else
            {
                throw new ArgumentException("Value is null");
            }
        }

        public void AddFirst(T value)
        {
            if (value != null)
            {
                DoubleLinkedListNode<T> insertNode = new DoubleLinkedListNode<T>(value);

                if (Length == 0)
                {
                    _root = insertNode;
                    _tail = _root;
                    ++Length;
                }
                else
                {
                    insertNode.Next = _root;
                    _root = insertNode;
                    _root.Next.Previous = insertNode;
                    ++Length;
                }
            }
            else
            {
                throw new ArgumentException("Value is null");
            }
        }

        public void AddByIndex(int index, T value)
        {
            if (value != null)
            {
                if (index >= 0 && index <= Length)
                {
                    if (index == 0)
                    {
                        AddFirst(value);
                    }
                    else if (index == Length)
                    {
                        Add(value);
                    }
                    else
                    {
                        DoubleLinkedListNode<T> insertNode = new DoubleLinkedListNode<T>(value);
                        DoubleLinkedListNode<T> currentNode = GetNodeByIndex(index - 1);

                        insertNode.Next = currentNode.Next;
                        currentNode.Next = insertNode;
                        insertNode.Previous = currentNode;
                        insertNode.Next.Previous = insertNode;
                        ++Length;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentException("Value is null");
            }
        }

        public void AddRange(IList<T> list)
        {
            if (list != null)
            {
                DoubleLinkedList<T> doubleList = new DoubleLinkedList<T>(list.ToArray());

                if (doubleList.Length != 0)
                {
                    if (_tail is null)
                    {
                        _root = doubleList._root;
                    }
                    else
                    {
                        doubleList._root.Previous = _tail;
                        _tail.Next = doubleList._root;
                        _tail = doubleList._tail;
                    }

                    Length += doubleList.Length;
                }
            }
            else
            {
                throw new NullReferenceException("List is null");
            }
        }

        public void AddRangeFirst(IList<T> list)
        {
            if (list != null)
            {
                DoubleLinkedList<T> doubleList = DoubleLinkedList<T>.Create(list.ToArray());

                if (Length == 0)
                {
                    _root = doubleList._root;
                    _tail = doubleList._tail;
                    Length = doubleList.Length;
                }
                else if (doubleList.Length != 0)
                {
                    _root.Previous = doubleList._tail;
                    doubleList._tail.Next = _root;
                    _root = doubleList._root;
                    Length += doubleList.Length;
                }
            }
            else
            {
                throw new NullReferenceException("List is null");
            }
        }

        public void AddRangeByIndex(int index, IList<T> list)
        {
            if (list != null)
            {
                DoubleLinkedList<T> doubleList = DoubleLinkedList<T>.Create(list.ToArray());

                if (index >= 0 && index <= Length)
                {
                    if (index == 0)
                    {
                        AddRangeFirst(list);
                    }
                    else if (index == Length)
                    {
                        AddRange(list);
                    }
                    else
                    {
                        DoubleLinkedListNode<T> currentNode = GetNodeByIndex(index - 1);
                        doubleList._root.Previous = currentNode;
                        currentNode.Next.Previous = doubleList._tail;
                        doubleList._tail.Next = currentNode.Next;
                        currentNode.Next = doubleList._root;
                        Length += doubleList.Length;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new NullReferenceException("List is null");
            }
        }

        public void Remove()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = GetNodeByIndex(index: Length - 1);

                _tail = current;
                _tail.Next = null;
                --Length;
            }
            else if (Length == 1)
            {
                RemoveFirst();
            }
            else
            {
                throw new ArgumentException("List is empty");
            }
        }

        public void RemoveFirst()
        {
            if (Length == 1)
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
            else if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root.Next;

                _root = current;
                _root.Previous = null;
                --Length;
            }
            else
            {
                throw new ArgumentException("List is empty");
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (Length > 0)
                {
                    if (index == 0)
                    {
                        RemoveFirst();
                    }
                    else if (index == Length - 1)
                    {
                        Remove();
                    }
                    else
                    {
                        DoubleLinkedListNode<T> current = GetNodeByIndex(index - 1);

                        current.Next = current.Next.Next;
                        current.Next.Previous = current;

                        --Length;
                    }
                }
                else
                {
                    throw new ArgumentException("List is empty");
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveRange(int count)
        {
            if (Length > 0 && count >= 0)
            {
                if (count >= Length)
                {
                    _root = null;
                    _tail = null;
                    Length = 0;
                }
                else
                {
                    DoubleLinkedListNode<T> current = GetNodeByIndex(index: Length - count - 1);

                    current.Next = null;
                    _tail = current;
                    Length -= count;
                }
            }
            else if (count < 0)
            {
                throw new ArgumentException("Invalid count");
            }
            else
            {
                throw new ArgumentException("List is empty");
            }
        }

        public void RemoveRangeFirst(int count)
        {
            if (Length > 0 && count >= 0)
            {
                if (count >= Length)
                {
                    _root = null;
                    _tail = null;
                    Length = 0;
                }
                else if (count == 0)
                {
                    return;
                }
                else
                {
                    DoubleLinkedListNode<T> current = GetNodeByIndex(index: count - 1);

                    _root = current.Next;
                    _root.Previous = null;
                    Length -= count;
                }
            }
            else if (count < 0)
            {
                throw new ArgumentException("Invalid count");
            }
            else
            {
                throw new ArgumentException("List is empty");
            }
        }

        public void RemoveRangeByIndex(int index, int count)
        {
            if (index >= 0 && index < Length)
            {
                if (index == 0)
                {
                    RemoveRangeFirst(count);
                }
                else if (count == Length - 1)
                {
                    RemoveRange(count);
                }
                else if (count > 0)
                {
                    if (count + index >= Length)
                    {
                        DoubleLinkedListNode<T> current = GetNodeByIndex(index - 1);

                        current.Next = null;
                        _tail = current;
                        Length = index;
                    }
                    else
                    {
                        DoubleLinkedListNode<T> startRemoveRangeNode = GetNodeByIndex(index - 1);
                        DoubleLinkedListNode<T> finishRemoveRangeNode = GetNodeByIndex(index + count - 1);

                        startRemoveRangeNode.Next = finishRemoveRangeNode.Next;
                        finishRemoveRangeNode.Next.Previous = startRemoveRangeNode;
                        Length -= count;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid count");
                }
            }
            else if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                throw new ArgumentException("List is empty");
            }
        }

        public int RemoveByValue(T value)
        {
            if (value != null)
            {
                DoubleLinkedListNode<T> current = _root;
                int index = 0;

                while (!(current is null))
                {
                    if (current.Value.CompareTo(value) == 0)
                    {
                        RemoveByIndex(index);

                        return index;
                    }
                    else
                    {
                        ++index;
                        current = current.Next;
                    }
                }

                return -1;
            }
            else
            {
                throw new NullReferenceException("Value if null");
            }
        }

        public int RemoveAllByValue(T value)
        {
            if (value != null)
            {
                int count = 0;

                if (Length == 1 && _root.Value.CompareTo(value) == 0)
                {
                    RemoveFirst();
                    ++count;
                }
                else if (Length > 1)
                {
                    DoubleLinkedListNode<T> current = _root.Next;

                    for (int i = 1; i < Length - 1; i++)
                    {
                        if (current.Value.CompareTo(value) == 0)
                        {
                            current.Previous.Next = current.Next;
                            current.Next.Previous = current.Previous;
                            ++count;
                            --Length;
                            --i;
                        }

                        current = current.Next;
                    }

                    if (_tail.Value.CompareTo(value) == 0)
                    {
                        _tail = _tail.Previous;
                        _tail.Next = null;
                        ++count;
                        --Length;
                    }

                    if (_root.Value.CompareTo(value) == 0)
                    {
                        _root.Previous = null;
                        _root = _root.Next;
                        ++count;
                        --Length;
                    }
                }
                else
                {
                    throw new ArgumentException("List is empty");
                }

                return count;
            }
            else
            {
                throw new NullReferenceException("Value is null");
            }
        }

        public void Reverse()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root;

                while (!(current is null!))
                {
                    var tempNode = current.Next;
                    current.Next = current.Previous;
                    current.Previous = tempNode;
                    current = current.Previous;
                }

                current = _root;
                _root = _tail;
                _tail = current;
            }
            else
            {
                throw new ArgumentException("List is empty");
            }
        }

        public int GetIndex(T value)
        {
            if (value != null)
            {
                if (Length > 0)
                {
                    DoubleLinkedListNode<T> current = _root;
                    int index = 0;

                    while (!(current is null))
                    {
                        if (current.Value.CompareTo(value) == 0)
                        {
                            return index;
                        }
                        else
                        {
                            ++index;
                            current = current.Next;
                        }
                    }

                    return -1;
                }

                return -1;
            }
            else
            {
                throw new NullReferenceException("Value is null");
            }
        }

        public int GetMinIndex()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root;
                T minValue = current.Value;
                int indexMinValue = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value.CompareTo(minValue) == -1)
                    {
                        minValue = current.Value;
                        indexMinValue = i;
                    }

                    current = current.Next;
                }

                return indexMinValue;
            }
            else
            {
                throw new ArgumentException("List is empty");
            }
        }

        public int GetMaxIndex()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root;
                T maxValue = current.Value;
                int indexMaxValue = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value.CompareTo(maxValue) == 1)
                    {
                        maxValue = current.Value;
                        indexMaxValue = i;
                    }

                    current = current.Next;
                }

                return indexMaxValue;
            }
            else
            {
                throw new ArgumentException("List is empty");
            }
        }

        public T GetMin()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root;
                T MinValue = current.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value.CompareTo(MinValue) == -1)
                    {
                        MinValue = current.Value;
                    }

                    current = current.Next;
                }

                return MinValue;
            }
            else
            {
                throw new ArgumentException("List is empty");
            }

        }

        public T GetMax()
        {
            if (Length > 0)
            {
                DoubleLinkedListNode<T> current = _root;
                T maxValue = current.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value.CompareTo(maxValue) == 1)
                    {
                        maxValue = current.Value;
                    }

                    current = current.Next;
                }

                return maxValue;
            }
            else
            {
                throw new ArgumentException("List is empty");
            }
        }

        public IList<T> Sort(bool isDescending)
        {
            DoubleLinkedList<T> list = new DoubleLinkedList<T>();
            list._root = this._root;
            list._tail = this._tail;
            list.Length = this.Length;
            int coef = isDescending ? 1 : -1;

            return MergeSort(list, coef);
        }

        public T[] ToArray()
        {
            if (Length > 0)
            {
                T[] result = new T[Length];
                DoubleLinkedListNode<T> currentR = _root;
                DoubleLinkedListNode<T> currentT = _tail;

                for (int i = 0; i <= Length / 2; i++)
                {
                    result[i] = currentR.Value;
                    result[Length - i - 1] = currentT.Value;
                    currentR = currentR.Next;
                    currentT = currentT.Previous;
                }

                return result;
            }
            else
            {
                return new T[] { };
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is null))
            {
                DoubleLinkedList<T> list = (DoubleLinkedList<T>)obj;

                if (this.Length == list.Length)
                {
                    if (this.Length == 0 && list.Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        DoubleLinkedListNode<T> currentThisNode = this._root;
                        DoubleLinkedListNode<T> currentListNode = list._root;

                        do
                        {
                            if (!(currentListNode.Next is null) || !(currentThisNode.Next is null))
                            {
                                if (currentThisNode.Value.CompareTo(currentListNode.Value) != 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    currentListNode = currentListNode.Next;
                                    currentThisNode = currentThisNode.Next;
                                }
                            }
                        }
                        while (!(currentThisNode.Next is null));

                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(string.Empty);

            if (Length != 0)
            {
                DoubleLinkedListNode<T> currentNode = _root;

                result.Append($"{ currentNode.Value} ");
                while (!(currentNode.Next is null))
                {
                    currentNode = currentNode.Next;
                    result.Append($"{ currentNode.Value} ");
                }
            }

            return result.ToString().Trim();
        }

        private DoubleLinkedList<T> MergeSort(DoubleLinkedList<T> list, int coef)
        {
            if (list.Length <= 1)
            {
                return list;
            }
            else
            {
                DoubleLinkedList<T> leftList = new DoubleLinkedList<T>();
                DoubleLinkedList<T> rightList = new DoubleLinkedList<T>();

                int mid = list.Length / 2;

                for (int i = 0; i < list.Length; i++)
                {
                    if (i < mid)
                    {
                        leftList.Add(list[i]);
                    }
                    else
                    {
                        rightList.Add(list[i]);
                    }
                }

                leftList = MergeSort(leftList, coef);
                rightList = MergeSort(rightList, coef);

                return Merge(leftList, rightList, coef);
            }
        }

        private DoubleLinkedList<T> Merge(DoubleLinkedList<T> leftList, DoubleLinkedList<T> rightList, int coef)
        {
            DoubleLinkedList<T> result = new DoubleLinkedList<T>();

            while (leftList.Length != 0 || rightList.Length != 0)
            {
                if (leftList.Length != 0 && rightList.Length != 0)
                {
                    if (leftList[0].CompareTo(rightList[0]) == coef || leftList[0].CompareTo(rightList[0]) == 0)
                    {
                        result.Add(leftList[0]);
                        leftList.RemoveFirst();
                    }
                    else
                    {
                        result.Add(rightList[0]);
                        rightList.RemoveFirst();
                    }
                }
                else if (leftList.Length != 0)
                {
                    result.Add(leftList[0]);
                    leftList.RemoveFirst();
                }
                else if (rightList.Length != 0)
                {
                    result.Add(rightList[0]);
                    rightList.RemoveFirst();
                }
            }

            return result;
        }

        private DoubleLinkedListNode<T> GetNodeByIndex(int index)
        {
            DoubleLinkedListNode<T> currentNode = null;

            if (index < Length / 2 + 1)
            {
                currentNode = _root;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
            }
            else
            {
                currentNode = _tail;

                for (int i = Length - 1; i > index; i--)
                {
                    currentNode = currentNode.Previous;
                }
            }

            return currentNode;
        }
    }
}
