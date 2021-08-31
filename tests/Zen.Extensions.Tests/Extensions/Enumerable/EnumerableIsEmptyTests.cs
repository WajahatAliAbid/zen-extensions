using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Zen.Extensions.Tests.Extensions.Enumerable
{
    public class EnumerableIsEmptyTests
    {
        [Fact]
        public void CanCheckEnumerableEmpty()
        {
            IEnumerable<int> list = new List<int>();
            list.IsEmpty()
                .Should()
                .BeTrue(because: "Provided enumerable has no elements");
        }

        [Fact]
        public void ReturnsFalseIfArraySizeIsGreaterThan0()
        {
            IEnumerable<int> array = new int[1];
            array.IsEmpty()
                .Should()
                .BeFalse(because: "Array is initialized with size of 1");
        }

        [Fact]
        public void ReturnsFalseIfEnumerableHasItems()
        {
            IEnumerable<int> array = new List<int>
            {
                3
            };
            array.IsEmpty()
                .Should()
                .BeFalse(because: "List has one item");
        }
    }
}