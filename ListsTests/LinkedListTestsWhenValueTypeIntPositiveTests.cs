
namespace Lists.Tests
{
    class LinkedListTestsWhenValueTypeIntPositiveTests : AbstractBaseTestsWhenValueTypeIntPositiveTests
    {
        public override void CreateLists(int[] actualArray, int[] expectedArray, int[] addedArray)
        {
            if (actualArray != null)
            {
                actual = LinkedList<int>.Create(actualArray);
            }
            if (expectedArray != null)
            {
                expected = LinkedList<int>.Create(expectedArray);
            }
            if (addedArray != null)
            {
                addedList = LinkedList<int>.Create(addedArray);
            }
        }

        public override void CreateLists(int actualValue, int[] expectedArray)
        {
            actual = LinkedList<int>.Create(actualValue);

            if (expectedArray != null)
            {
                expected = LinkedList<int>.Create(expectedArray);
            }
        }
    }
}
