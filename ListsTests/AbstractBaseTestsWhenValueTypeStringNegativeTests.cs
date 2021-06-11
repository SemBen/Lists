using System;
using NUnit.Framework;

namespace Lists.Tests
{
    public abstract class AbstractBaseTestsWhenValueTypeStringNegativeTests
    {
        protected IList<string> actual;
        protected IList<string> addedList;

        public abstract void CreateList(string[] actualArray);

        public abstract void CreateList(string[] actualArray, string[] addedArray);

        [TestCase(-1, new string[] { })]
        [TestCase(0, new string[] { })]
        [TestCase(1, new string[] { "0" })]
        [TestCase(2, new string[] { "0", "1" })]
        [TestCase(3, new string[] { "0", "1", "2" })]
        [TestCase(4, new string[] { "0", "1", "2", "3" })]
        [TestCase(5, new string[] { "0", "1", "2", "3", "4" })]
        [TestCase(6, new string[] { "0", "1", "2", "3", "4", "5" })]
        public void Indexator_whenInvalidSetPassed_ShouldReturnIndexOutOfRangeException(int index, string[] actualArray)
        {
            CreateList(actualArray);

            string x = string.Empty;

            Assert.Throws<IndexOutOfRangeException>(() => actual[index] = x);
        }

        [TestCase(-1, new string[] { })]
        [TestCase(0, new string[] { })]
        [TestCase(1, new string[] { "0" })]
        [TestCase(2, new string[] { "0", "1" })]
        [TestCase(3, new string[] { "0", "1", "2" })]
        [TestCase(4, new string[] { "0", "1", "2", "3" })]
        [TestCase(5, new string[] { "0", "1", "2", "3", "4" })]
        [TestCase(6, new string[] { "0", "1", "2", "3", "4", "5" })]
        public void Indexator_whenInvalidGetPassed_ShouldReturnIndexOutOfRangeException(int index, string[] actualArray)
        {
            CreateList(actualArray);

            string x = string.Empty;

            Assert.Throws<IndexOutOfRangeException>(() => x = actual[index]);
        }

        [TestCase(null)]
        public void CreateArray_WhenIvalinPassed_SholdReturnArgumentException(string value)
        {
            Assert.Throws<ArgumentException>(() => LinkedList<string>.Create(value));
        }

        [TestCase(null)]
        public void CreateArray_WhenIvalinPassed_SholdReturnArgumentException(string[] array)
        {
            Assert.Throws<ArgumentException>(() => LinkedList<string>.Create(array));
        }

        [TestCase(null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(null, new string[] { "0" })]
        [TestCase(null, new string[] { })]
        public void Add_WhenInvalidPassed_ShouldReturnArgumentException(string value, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<ArgumentException>(() => actual.Add(value));
        }

        [TestCase(null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(null, new string[] { "0" })]
        [TestCase(null, new string[] { })]
        public void AddFirst_WhenInvalidPassed_ShouldReturnArgumentException(string value, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<ArgumentException>(() => actual.AddFirst(value));
        }

        [TestCase(0, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(1, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(2, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(3, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(4, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(5, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(6, null, new string[] { "0" })]
        [TestCase(7, null, new string[] { })]
        public void AddByIndex_WhenInvalidPassed_ShouldReturnArgumentException(int index, string value, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<ArgumentException>(() => actual.AddByIndex(index, value));
        }

        [TestCase(7, " ", new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(8, " ", new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(9, " ", new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-1, " ", new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-2, " ", new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-10, " ", new string[] { "0" })]
        [TestCase(10, " ", new string[] { })]
        public void AddByIndex_WhenInvalidPassed_ShouldReturnIndexOutOfRangeException(int index, string value, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));
        }

        [TestCase(null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(null, new string[] { "0" })]
        [TestCase(null, new string[] { })]
        public void AddRange_WhenInvalidPassed_ShouldReturnNullReferenceException(IList<string> value, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<NullReferenceException>(() => actual.AddRange(value));
        }

        [TestCase(null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(null, new string[] { "0" })]
        [TestCase(null, new string[] { })]
        public void AddRangeFirst_WhenInvalidPassed_ShouldReturnNullReferenceException(IList<string> value, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<NullReferenceException>(() => actual.AddRangeFirst(value));
        }

        [TestCase(0, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(1, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(2, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(3, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(4, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(5, null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(0, null, new string[] { "0" })]
        [TestCase(0, null, new string[] { })]
        public void AddRangeByIndex_WhenInvalidPassed_ShouldReturnNullReferenceException(int index, IList<string> value, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<NullReferenceException>(() => actual.AddRangeByIndex(index, value));
        }


        [TestCase(7, new string[] { "0", "1", "2", "3", "4", "5" }, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(8, new string[] { "0", "1", "2", "3", "4", "5" }, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(9, new string[] { "0", "1", "2", "3", "4", "5" }, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-1, new string[] { "0", "1", "2", "3", "4", "5" }, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-2, new string[] { "0", "1", "2", "3", "4", "5" }, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-100, new string[] { "0", "1", "2", "3", "4", "5" }, new string[] { "0" })]
        [TestCase(100, new string[] { "0", "1", "2", "3", "4", "5" }, new string[] { })]
        [TestCase(1, new string[] { "0", "1", "2", "3", "4", "5" }, new string[] { })]
        public void AddRangeByIndex_WhenInvalidPassed_ShouldReturnIndexOutOfRangeException(int index, string[] addedArray, string[] actualArray)
        {
            CreateList(actualArray, addedArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddRangeByIndex(index, addedList));
        }

        [TestCase(6, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(7, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(8, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(9, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-1, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-2, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-100, new string[] { "0" })]
        [TestCase(100, new string[] { })]
        [TestCase(0, new string[] { })]
        public void RemoveByIndex_WhenInvalidPassed_ShouldReturnIndexOutOfRangeException(int index, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));
        }

        [TestCase(-1, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-2, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-100, new string[] { "0" })]
        [TestCase(-1, new string[] { })]
        public void RemoveRange_WhenInvalidPassed_ShouldReturnArgumentException(int count, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveRange(count));
        }

        [TestCase(-1, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-2, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-100, new string[] { "0" })]
        [TestCase(-1, new string[] { })]
        public void RemoveRangeFirst_WhenInvalidPassed_ShouldReturnArgumentException(int count, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFirst(count));
        }

        [TestCase(-1, 1, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(-2, 2, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(6, 3, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(10, 4, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(100, 5, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(1, 6, new string[] { "0" })]
        [TestCase(-1, 7, new string[] { "0" })]
        public void RemoveRangeByIndex_WhenInvalidPassed_ShouldReturnIndexOutOfRangeException(int index, int count, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveRangeByIndex(index, count));
        }

        [TestCase(1, -1, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(2, -2, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(3, -3, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(4, -4, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(5, -5, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(0, -4, new string[] { "0" })]
        [TestCase(0, -3, new string[] { "0" })]
        public void RemoveRangeByIndex_WhenInvalidPassed_ShouldReturnArgumentException(int index, int count, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeByIndex(index, count));
        }

        [TestCase(null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(null, new string[] { "0", "1", "2", "3", "4", null })]
        [TestCase(null, new string[] { "0", "1", "2", "3", null, null })]
        [TestCase(null, new string[] { "0", "1", "2", null, null, null })]
        [TestCase(null, new string[] { "0", "1", null, null, null, null })]
        [TestCase(null, new string[] { "0", null, null, null, null, null })]
        [TestCase(null, new string[] { null, null, null, null, null, null })]
        [TestCase(null, new string[] { "0" })]
        [TestCase(null, new string[] { })]
        public void RemoveByValue_WhenInvalidPassed_ShouldReturnArgumentException(string value, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<NullReferenceException>(() => actual.RemoveByValue(value));
        }

        [TestCase(null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(null, new string[] { "0", "1", "2", "3", "4", null })]
        [TestCase(null, new string[] { "0", "1", "2", "3", null, null })]
        [TestCase(null, new string[] { "0", "1", "2", null, null, null })]
        [TestCase(null, new string[] { "0", "1", null, null, null, null })]
        [TestCase(null, new string[] { "0", null, null, null, null, null })]
        [TestCase(null, new string[] { null, null, null, null, null, null })]
        [TestCase(null, new string[] { "0" })]
        [TestCase(null, new string[] { })]
        public void RemoveAllByValue_WhenInvalidPassed_ShouldReturnArgumentException(string value, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<NullReferenceException>(() => actual.RemoveAllByValue(value));
        }

        [TestCase(null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(null, new string[] { "0", "1", "2", "3", "4", null })]
        [TestCase(null, new string[] { "0", "1", "2", "3", null, null })]
        [TestCase(null, new string[] { "0", "1", "2", null, null, null })]
        [TestCase(null, new string[] { "0", "1", null, null, null, null })]
        [TestCase(null, new string[] { "0", null, null, null, null, null })]
        [TestCase(null, new string[] { null, null, null, null, null, null })]
        [TestCase(null, new string[] { "0" })]
        [TestCase(null, new string[] { })]
        public void GetIndex_WhenInvalidPassed_ShouldReturnArgumentException(string value, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<NullReferenceException>(() => actual.GetIndex(value));
        }

        [TestCase(null, new string[] { "0", "1", "2", "3", "4", "5" })]
        [TestCase(null, new string[] { "0", "1", "2", "3", "4", null })]
        [TestCase(null, new string[] { "0", "1", "2", "3", null, null })]
        [TestCase(null, new string[] { "0", "1", "2", null, null, null })]
        [TestCase(null, new string[] { "0", "1", null, null, null, null })]
        [TestCase(null, new string[] { "0", null, null, null, null, null })]
        [TestCase(null, new string[] { null, null, null, null, null, null })]
        [TestCase(null, new string[] { "0" })]
        [TestCase(null, new string[] { })]
        public void Equals_WhenInvalidPassed_ShouldReturnArgumentNullException(string value, string[] actualArray)
        {
            CreateList(actualArray);

            Assert.Throws<ArgumentNullException>(() => actual.Equals(value));
        }

    }
}
