
namespace Lists
{
    public interface IList<T>
    {
        T this[int index] { get; set; }

        void Add(T value);

        void AddFirst(T value);

        void AddByIndex(int index, T value);

        void AddRange(IList<T> list);

        void AddRangeFirst(IList<T> list);

        void AddRangeByIndex(int index, IList<T> list);

        void Remove();

        void RemoveFirst();

        void RemoveByIndex(int index);

        void RemoveRange(int count);

        void RemoveRangeFirst(int count);

        void RemoveRangeByIndex(int index, int count);

        int RemoveByValue(T value);

        int RemoveAllByValue(T value);

        void Reverse();

        int GetIndex(T value);

        T GetMin();

        T GetMax();

        int GetMinIndex();

        int GetMaxIndex();

        IList<T> Sort(bool isDescending);

        T[] ToArray();
    }
}
