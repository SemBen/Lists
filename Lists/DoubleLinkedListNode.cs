
namespace Lists
{
    public class DoubleLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }
        public DoubleLinkedListNode<T> Previous { get; set; }

        public DoubleLinkedListNode(T value)
        {
            Value = value;
        }
    }
}
