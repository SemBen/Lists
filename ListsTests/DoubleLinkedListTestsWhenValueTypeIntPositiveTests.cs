
namespace Lists.Tests
{
    class DoubleLinkedListTestsWhenValueTypeIntPositiveTests : AbstractBaseTestsWhenValueTypeIntPositiveTests
    {
        public override void CreateLists(int[] actualArray = null, int[] expectedArray = null, int[] addedArray = null)
        {
            if (actualArray != null)
            {
                actual = DoubleLinkedList<int>.Create(actualArray);
            }
            if (expectedArray != null)
            {
                expected = DoubleLinkedList<int>.Create(expectedArray);
            }
            if (addedArray != null)
            {
                addedList = DoubleLinkedList<int>.Create(addedArray);
            }
        }

        public override void CreateLists(int actualValue, int[] expectedArray)
        {
            actual = DoubleLinkedList<int>.Create(actualValue);

            if (expectedArray != null)
            {
                expected = DoubleLinkedList<int>.Create(expectedArray);
            }
        }
    }
}
