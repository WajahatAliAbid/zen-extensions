using System;
using FluentAssertions;
using Xunit;

namespace Zen.Extensions.Tests
{
    public class SafeStringTests
    {
        [Fact]
        public void CanImplicitlyCastToString()
        {
            var safeString = new SafeString("Test Value");
            string val = safeString;
            val.Should()
                .Be("Test Value");
        }
        
        [Fact]
        public void ThrowsExceptionWhenSetAsNull()
        {
            Action act = () => 
            {
                var safeString = new SafeString(null);
            };
            act.Should()
                .Throw<ArgumentException>(because: "Safe String cannot have null value");
        }

        [Fact]
        public void ThrowsExceptionWhenSetAsEmpty()
        {
            Action act = () => 
            {
                var safeString = new SafeString("");
            };
            act.Should()
                .Throw<ArgumentException>(because: "Safe String cannot have empty value");
        }

        [Fact]
        public void ThrowsExceptionWhenSetAsWhiteSpace()
        {
            Action act = () => 
            {
                var safeString = new SafeString("  ");
            };
            act.Should()
                .Throw<ArgumentException>(because: "Safe String cannot have whitespace value");
        }

        [Fact]
        public void ToStringShouldHaveUnderlyingStringValue()
        {
            var safeString = new SafeString("Testing");
            safeString.ToString()
                .Should()
                .Be("Testing");
        }
    }
}