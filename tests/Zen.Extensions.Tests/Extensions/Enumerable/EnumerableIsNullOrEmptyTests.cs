using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Zen.Extensions.Tests.Extensions.Enumerable
{
    public class EnumerableIsNullOrEmptyTests
    {
        [Fact]
        public void CanCheckEnumerableIsNullOrEmpty()
        {
            IEnumerable<int> list = new List<int>();
            list.IsNullOrEmpty()
                .Should()
                .BeTrue(because: "Provided enumerable has no elements");
        }

        [Fact]
        public void ReturnsFalseIfArraySizeIsGreaterThan0()
        {
            IEnumerable<int> array = new int[1];
            array.IsNullOrEmpty()
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
            array.IsNullOrEmpty()
                .Should()
                .BeFalse(because: "List has one item");
        }

        [Fact]
        public void ReturnsTrueIfEnumerableIsNull()
        {
            IEnumerable<int> enumerable = null;
            enumerable.IsNullOrEmpty()
                .Should()
                .BeTrue(because:"Enumerable is null");
        }
    }
}